#!/usr/bin/env python3

from __future__ import annotations

import json
import re
import sys
from abc import ABC, abstractmethod
from collections.abc import Iterable, Sequence
from dataclasses import dataclass
from enum import IntFlag, StrEnum
from io import TextIOWrapper
from typing import Literal, cast

type HeaderLevel = Literal[1, 2, 3]
type AnchorRef = Literal["homepage", "repository", "bugs"]


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
            return Header(cast(HeaderLevel, int(element[1])), content, context=context)
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
        return ""

    def should_render(self, context: Context) -> bool:
        return (self.context & context) != 0

    @abstractmethod
    def render_readme(self, mod: ModSchema) -> str: ...

    @abstractmethod
    def render_description(self, mod: ModSchema) -> str: ...

    @abstractmethod
    def render_workshop(self, mod: ModSchema) -> str: ...


class Header(Element):
    level: HeaderLevel

    def __init__(
        self, level: HeaderLevel, content: str, *, context: Context = Context.ALL
    ):
        if level < 1 or level > 3:
            raise RuntimeError(f"unknown header level: {level!r}")

        super().__init__(context=context)

        self.level = level
        self.content = content

    def render_readme(self, mod: ModSchema) -> str:
        return f"{'#' * (self.level + 1)} {self.content}"

    def render_description(self, mod: ModSchema) -> str:
        return f"===={self.content.upper()}===="

    def render_workshop(self, mod: ModSchema) -> str:
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

    def render_readme(self, mod: ModSchema) -> str:
        return self.content

    def render_description(self, mod: ModSchema) -> str:
        return self.content

    def render_workshop(self, mod: ModSchema) -> str:
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

    def render_readme(self, mod: ModSchema) -> str:
        return "\n".join(
            [
                f"{idx + 1}. {content}" if self.ordered else f"- {content}"
                for idx, content in enumerate(self.contents)
            ]
        )

    def render_description(self, mod: ModSchema) -> str:
        return self.render_readme(mod)

    def render_workshop(self, mod: ModSchema) -> str:
        tag = "olist" if self.ordered else "list"

        contents = "\n".join(
            f"{INDENT_MAP[Context.WORKSHOP] * ' '}[*]{content}"
            for content in self.contents
        )
        return f"[{tag}]\n{contents}\n[/{tag}]"


class Anchor(Element):
    content: str
    link: str | None
    ref: AnchorRef | None

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
        if ref and ref not in {"homepage", "repository", "bugs"}:
            raise ValueError(f"invalid anchor ref: {ref!r}")

        super().__init__(context=context)

        self.content = content
        self.link = link
        self.ref = cast(AnchorRef | None, ref)

    def render_readme(self, mod: ModSchema) -> str:
        if (self.ref is None and self.link is None) or (self.ref and self.link):
            raise ValueError("anchor tag requires one of: link, ref")
        link = self.link or getattr(mod, cast(AnchorRef, self.ref))
        return f"[{self.content}]({link})"

    def render_description(self, mod: ModSchema) -> str:
        raise RuntimeError("anchors are not supported in the description Context")

    def render_workshop(self, mod: ModSchema) -> str:
        if (self.ref is None and self.link is None) or (self.ref and self.link):
            raise ValueError("anchor tag requires one of: link, ref")
        link = self.link or getattr(mod, cast(AnchorRef, self.ref))
        return f"[url={link}]{self.content}[/url]"


class Elements:
    elements: Sequence[Element]

    @staticmethod
    def from_dict(elements) -> Elements:
        return Elements(*map(Element.from_dict, elements))

    def __init__(self, *elements: Element):
        self.elements = elements

    def get_renderable_elements(
        self, context: Context, *, add_title: bool = True
    ) -> Iterable[Element]:
        return filter(
            lambda el: el.should_render(context),
            (Title(context=Context.NON_WORKSHOP), *self.elements)
            if add_title
            else self.elements,
        )

    def render(
        self, context: Context, mod: ModSchema, *, add_title: bool = True
    ) -> str:
        return (
            "\n\n".join(
                [
                    el.render(context, mod)
                    for el in self.get_renderable_elements(context, add_title=add_title)
                ]
            )
            + "\n"
        )

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

    def render(self) -> str:
        build: list[str] = [f"author = {self.author}", f"version = {self.version}"]
        if self.dll_references:
            build.append(f"dllReferences = {', '.join(self.dll_references)}")
        if self.mod_references:
            build.append(f"modReferences = {', '.join(self.mod_references)}")
        if self.weak_references:
            build.append(f"weakReferences = {', '.join(self.weak_references)}")
        if self.sort_before:
            build.append(f"sortBefore = {', '.join(self.sort_before)}")
        if self.sort_after:
            build.append(f"sortAfter = {', '.join(self.sort_after)}")
        if self.display_name:
            build.append(f"displayName = {self.display_name}")
        if self.homepage:
            build.append(f"homepage = {self.homepage}")
        if self.no_compile is not None:
            build.append(f"noCompile = {str(self.no_compile).lower()}")
        if self.playable_on_preview is not None:
            build.append(f"playableOnPreview = {str(self.playable_on_preview).lower()}")
        if self.translation_mod is not None:
            build.append(f"translationMod = {str(self.translation_mod).lower()}")
        if self.hide_code is not None:
            build.append(f"hideCode = {str(self.hide_code).lower()}")
        if self.hide_resources is not None:
            build.append(f"hideResources = {str(self.hide_resources).lower()}")
        if self.include_source is not None:
            build.append(f"includeSource = {str(self.include_source).lower()}")
        if self.build_ignore:
            build.append(f"buildIgnore = {', '.join(self.build_ignore)}")
        if self.side:
            build.append(f"side = {self.side}")

        return "\n".join(build)

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
    if len(sys.argv) == 3 and sys.argv[1] == "tag":
        tag = sys.argv[-1]
        with open("tmod.json", encoding="utf-8") as file:
            tmod = json.load(file)
        tmod["version"] = tag
        with open("tmod.json", "w", encoding="utf-8") as file:
            json.dump(tmod, file, indent=2)
            file.write("\n")

    with open("tmod.json", encoding="utf-8") as tmod_json:
        tmod = ModSchema.load(tmod_json)

    if tmod.description:
        for path in ("description.txt", "description_workshop.txt"):
            ctx = Context.from_path(path)
            with open(path, "w", encoding="utf-8") as file:
                file.write(tmod.description.render(ctx, tmod))

        readme_header_contents: str | None = None
        with open("README.md", encoding="utf-8") as file:
            contents = file.read()
            header_content_start = contents.find("<!-- #region README Header -->")
            header_content_end = contents.find("<!-- #endregion -->")
            if header_content_start != -1 and header_content_end != -1:
                readme_header_contents = contents[
                    header_content_start : header_content_end
                    + len("<!-- #endregion -->")
                ]

        with open("README.md", "w", encoding="utf-8") as file:
            ctx = Context.README
            if readme_header_contents:
                file.write(Title().render(ctx, tmod) + "\n\n")
                file.write(readme_header_contents + "\n\n")
                file.write(tmod.description.render(ctx, tmod, add_title=False))
            else:
                file.write(tmod.description.render(ctx, tmod))

    with open("build.txt", "w", encoding="utf-8") as file:
        file.write(tmod.render())


if __name__ == "__main__":
    main()
