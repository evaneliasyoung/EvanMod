#!/usr/bin/env python3

from __future__ import annotations

import json
import re
from abc import ABC, abstractmethod
from dataclasses import dataclass
from enum import IntFlag, StrEnum
from io import TextIOWrapper
from typing import Literal


class Context(IntFlag):
    NONE = 0b000
    README = 0b001
    DESCRIPTION = 0b010
    WORKSHOP = 0b100

    ALL = README | DESCRIPTION | WORKSHOP
    NON_README = ALL ^ README
    NON_WORKSHOP = ALL ^ WORKSHOP

    @staticmethod
    def from_str(ctx: str) -> Context:
        for key, val in (
            ("NONE", Context.NONE),
            ("README", Context.README),
            ("DESCRIPTION", Context.DESCRIPTION),
            ("WORKSHOP", Context.WORKSHOP),
            ("ALL", Context.ALL),
            ("NON_README", Context.NON_README),
            ("NON_WORKSHOP", Context.NON_WORKSHOP),
        ):
            if ctx == key:
                return val
        raise RuntimeError(f"unknown context: {ctx!r}")

    @staticmethod
    def from_path(path: str) -> Context:
        if path == "README.md":
            return Context.README
        if path == "description.txt":
            return Context.DESCRIPTION
        if path == "description_workshop.txt":
            return Context.WORKSHOP
        raise RuntimeError(f"unknown contextual file: {path!r}")


INDENT_MAP: dict[Context, int] = {
    Context.README: 2,
    Context.DESCRIPTION: 2,
    Context.WORKSHOP: 4,
}

GIT_REPO = "https://github.com/evaneliasyoung/EvanMod"


class ModSide(StrEnum):
    CLIENT = "Client"
    SERVER = "Server"
    BOTH = "Both"


class Element(ABC):
    context: Context

    @staticmethod
    def from_dict(kwds) -> Element:
        if (element := kwds.get("element")) is None or (
            content := kwds.get("content")
        ) is None:
            raise ValueError("invalid element schema")

        context = Context[kwds.get("context", "ALL")]
        if re.match(r"(^h[123]$)", element):
            return Header(int(element[1]), content, context=context)
        elif element == "p":
            return Text(content, context=context)
        elif re.match(r"(^[ou]l$)", element):
            return List(element[0] == "o", content, context=context)
        elif element == "a":
            link, ref = kwds.get("link"), kwds.get("ref")
            return Anchor(content, link, ref=ref, context=context)
        else:
            raise ValueError("unknown element: {element!r}")

    def __init__(self, *, context: Context = Context.ALL):
        self.context = context

    def render(self, context: Context, mod: ModSchema) -> str:
        if self.context & context:
            if context == Context.README:
                return self.render_readme(mod)
            elif context == Context.DESCRIPTION:
                return self.render_description(mod)
            elif context == Context.WORKSHOP:
                return self.render_workshop(mod)
        else:
            return ""

    def should_render(self, context: Context) -> bool:
        return self.context & context

    @abstractmethod
    def render_readme(self, mod: ModSchema) -> str: ...

    @abstractmethod
    def render_description(self, mod: ModSchema) -> str: ...

    @abstractmethod
    def render_workshop(self, mod: ModSchema) -> str: ...


class Header(Element):
    level: Literal[1, 2, 3]

    def __init__(
        self, level: Literal[1, 2, 3], content: str, *, context: Context = Context.ALL
    ):
        if level < 1 or level > 3:
            raise RuntimeError(f"unknown header leve: {level!r}")

        super().__init__(context=context)

        self.level = level
        self.content = content

    def render_readme(self, _mod: ModSchema) -> str:
        return f"{"#"*(self.level+1)} {self.content}"

    def render_description(self, _mod: ModSchema) -> str:
        return f"===={self.content.upper()}===="

    def render_workshop(self, _mod: ModSchema) -> str:
        return f"[h{self.level}]{self.content.upper()}[/h{self.level}]"


class Title(Element):
    def __init__(self, *, context: Context = Context.ALL):
        super().__init__(context=context)

    def render_readme(self, mod: ModSchema) -> str:
        return f"# {mod.display_name or 'Title'}"

    def render_description(self, mod: ModSchema) -> str:
        return mod.display_name or "Title"

    def render_workshop(self, mod: ModSchema) -> str:
        return mod.display_name or "Title"


class Text(Element):
    def __init__(self, content: str, *, context: Context = Context.ALL):
        super().__init__(context=context)

        self.content = content

    def render_readme(self, _mod: ModSchema) -> str:
        return self.content

    def render_description(self, _mod: ModSchema) -> str:
        return self.content

    def render_workshop(self, _mod: ModSchema) -> str:
        return self.content


class List(Element):
    ordered: bool
    contents: list[str]

    def __init__(
        self, ordered: bool, contents: list[str], *, context: Context = Context.ALL
    ):
        super().__init__(context=context)

        self.ordered = ordered
        self.contents = contents

    def render_readme(self, _mod: ModSchema) -> str:
        return "\n".join(
            [
                f"{idx+1}. {content}" if self.ordered else f"- {content}"
                for idx, content in enumerate(self.contents)
            ]
        )

    def render_description(self, mod: ModSchema) -> str:
        return self.render_readme(mod)

    def render_workshop(self, _mod: ModSchema) -> str:
        tag = "olist" if self.ordered else "list"

        contents = "\n".join(
            f"{INDENT_MAP[Context.WORKSHOP]*" "}[*]{content}"
            for content in self.contents
        )
        return f"[{tag}]\n{contents}\n[/{tag}]"


class Anchor(Element):
    content: str
    link: str | None
    ref: Literal["homepage", "repository", "bugs"] | None

    def __init__(
        self,
        content: str,
        link: str | None,
        *,
        ref: str | None = None,
        context: Context = Context.ALL ^ Context.DESCRIPTION,
    ):
        if (ref is None and link is None) or (ref and link):
            raise ValueError("anchor tag requires one of: link, ref")
        if ref and ref != "homepage" and ref != "repository" and ref != "bugs":
            raise ValueError(f"invalid anchor ref: {ref!r}")

        super().__init__(context=context)

        self.content = content
        self.link = link
        self.ref = ref

    def render_readme(self, mod: ModSchema) -> str:
        link = self.link or getattr(mod, self.ref)
        return f"[{self.content}]({link})"

    def render_description(self, _mod: ModSchema) -> str:
        raise RuntimeError("anchors are not supported in the description Context")

    def render_workshop(self, mod: ModSchema) -> str:
        link = self.link or getattr(mod, self.ref)
        return f"[url={link}]{self.content}[/url]"


class Elements:
    elements: list[Element]

    @staticmethod
    def from_dict(elements) -> Elements:
        return Elements(*map(Element.from_dict, elements))

    def __init__(self, *elements: list[Element]):
        self.elements = elements

    def get_renderable_elements(self, context: Context) -> list[Element]:
        return list(
            filter(
                lambda el: el.should_render(context),
                (Title(context=Context.NON_WORKSHOP), *self.elements),
            )
        )

    def render(self, context: Context, mod: ModSchema) -> str:
        contents = ""
        for el in (*(to_render := self.get_renderable_elements(context)),):
            contents += el.render(context, mod) + "\n"
            if el != to_render[-1]:
                contents += "\n"

        return contents

    def __len__(self) -> int:
        return len(self.elements)

    def __repr__(self) -> str:
        return f"Elements[{len(self)}]"


@dataclass
class ModSchema:
    author: str
    version: str
    dll_references: list[str] | None = None
    mod_references: list[str] | None = None
    weak_references: list[str] | None = None
    sort_before: list[str] | None = None
    sort_after: list[str] | None = None
    display_name: str | None = None
    homepage: str | None = None
    no_compile: bool | None = None
    playable_on_preview: bool | None = None
    translation_mod: bool | None = None
    hide_code: bool | None = None
    hide_resources: bool | None = None
    include_source: bool | None = None
    build_ignore: list[str] | None = None
    side: ModSide | None = None
    bugs: str | None = None
    repository: str | None = None
    description: Elements | None = None

    @staticmethod
    def load(fp: TextIOWrapper) -> ModSchema:
        return json.load(fp, object_hook=custom_decoder)

    def __getitem__(self, key: str) -> None:
        return getattr(self, key)


def custom_decoder(dct):
    if "author" in dct and "version" in dct:
        return ModSchema(
            author=dct.get("author"),
            version=dct.get("version"),
            dll_references=dct.get("dllReferences"),
            mod_references=dct.get("modReferences"),
            weak_references=dct.get("weakReferences"),
            sort_before=dct.get("sortBefore"),
            sort_after=dct.get("sortAfter"),
            display_name=dct.get("displayName"),
            homepage=dct.get("homepage"),
            no_compile=dct.get("noCompile"),
            playable_on_preview=dct.get("playableOnPreview"),
            translation_mod=dct.get("translationMod"),
            hide_code=dct.get("hideCode"),
            hide_resources=dct.get("hideResources"),
            include_source=dct.get("includeSource"),
            build_ignore=dct.get("buildIgnore"),
            side=ModSide(dct["side"]) if dct.get("side") else None,
            bugs=dct.get("bugs"),
            repository=dct.get("repository"),
            description=Elements.from_dict(dct.get("description"))
            if dct.get("description")
            else None,
        )
    return dct


def main() -> None:
    with open("tmod.json", "r", encoding="utf-8") as tmod_json:
        tmod = ModSchema.load(tmod_json)

    if tmod.description:
        for path in ("README.md", "description.txt", "description_workshop.txt"):
            ctx = Context.from_path(path)
            with open(path, "w", encoding="utf-8") as file:
                file.write(tmod.description.render(ctx, tmod))

    with open("build.txt", "w", encoding="utf-8") as file:
        fstr = "author = {author}" + "\n"
        fstr += "version = {version}" + "\n"
        if tmod.dll_references:
            fstr += f"dllReferences = {", ".join(tmod.dll_references)}" + "\n"
        if tmod.mod_references:
            fstr += f"modReferences = {", ".join(tmod.mod_references)}" + "\n"
        if tmod.weak_references:
            fstr += f"weakReferences = {", ".join(tmod.weak_references)}" + "\n"
        if tmod.sort_before:
            fstr += f"sortBefore = {", ".join(tmod.sort_before)}" + "\n"
        if tmod.sort_after:
            fstr += f"sortAfter = {", ".join(tmod.sort_after)}" + "\n"
        if tmod.display_name:
            fstr += "displayName = {display_name}" + "\n"
        if tmod.homepage:
            fstr += "homepage = {homepage}" + "\n"
        if tmod.no_compile is not None:
            fstr += f"noCompile = {str(tmod.no_compile).lower()}" + "\n"
        if tmod.playable_on_preview is not None:
            fstr += (
                f"playableOnPreview = {str(tmod.playable_on_preview).lower()}" + "\n"
            )
        if tmod.translation_mod is not None:
            fstr += f"translationMod = {str(tmod.translation_mod).lower()}" + "\n"
        if tmod.hide_code is not None:
            fstr += f"hideCode = {str(tmod.hide_code).lower()}" + "\n"
        if tmod.hide_resources is not None:
            fstr += f"hideResources = {str(tmod.hide_resources).lower()}" + "\n"
        if tmod.include_source is not None:
            fstr += f"includeSource = {str(tmod.include_source).lower()}" + "\n"
        if tmod.build_ignore:
            fstr += f"buildIgnore = {", ".join(tmod.build_ignore)}" + "\n"
        if tmod.side:
            fstr += f"side = {tmod.side}" + "\n"
        fstr = fstr[:-1]
        file.write(fstr.format_map(tmod))


if __name__ == "__main__":
    main()
