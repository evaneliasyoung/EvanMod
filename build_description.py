#!/usr/bin/env python3

from __future__ import annotations

from abc import ABC, abstractmethod
from enum import IntFlag
from typing import Literal


class Context(IntFlag):
    NONE = 0b000
    README = 0b001
    DESCRIPTION = 0b010
    WORKSHOP = 0b100
    NON_README = 0b110
    NON_WORKSHOP = 0b011
    ALL = 0b111

    @staticmethod
    def from_path(path: str) -> Context:
        if path == "README.md":
            return Context.README
        if path == "description.txt":
            return Context.DESCRIPTION
        if path == "description_workshop.txt":
            return Context.WORKSHOP
        raise RuntimeError(f"unknown contextual file: {file}")


INDENT_MAP: dict[Context, int] = {
    Context.README: 2,
    Context.DESCRIPTION: 2,
    Context.WORKSHOP: 4,
}

GIT_REPO = "https://github.com/evaneliasyoung/EvanMod"


class Element(ABC):
    context: Context

    def __init__(self, *, context: Context = Context.ALL):
        self.context = context

    def render(self, context: Context) -> str:
        if self.context & context:
            if context == Context.README:
                return self.render_readme()
            elif context == Context.DESCRIPTION:
                return self.render_description()
            elif context == Context.WORKSHOP:
                return self.render_workshop()
        else:
            return ""

    def should_render(self, context: Context) -> bool:
        return self.context & context

    @abstractmethod
    def render_readme(self) -> str: ...

    @abstractmethod
    def render_description(self) -> str: ...

    @abstractmethod
    def render_workshop(self) -> str: ...


class Header(Element):
    level: Literal[1, 2, 3]

    def __init__(
        self, level: Literal[1, 2, 3], content: str, *, context: Context = Context.ALL
    ):
        super().__init__(context=context)

        if level < 1 or level > 3:
            raise RuntimeError(f"unknown header tag: h{level}")
        self.level = level
        self.content = content

    def render_readme(self) -> str:
        return f"{"#"*(self.level+1)} {self.content}"

    def render_description(self) -> str:
        return f"===={self.content.upper()}===="

    def render_workshop(self) -> str:
        return f"[h{self.level}]{self.content.upper()}[/h{self.level}]"


class Title(Element):
    def __init__(self, content: str, *, context: Context = Context.ALL):
        super().__init__(context=context)

        self.content = content

    def render_readme(self) -> str:
        return f"# {self.content}"

    def render_description(self) -> str:
        return self.content

    def render_workshop(self) -> str:
        return self.content


class Text(Element):
    def __init__(self, content: str, *, context: Context = Context.ALL):
        super().__init__(context=context)

        self.content = content

    def render_readme(self) -> str:
        return self.content

    def render_description(self) -> str:
        return self.content

    def render_workshop(self) -> str:
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

    def render_readme(self) -> str:
        return "\n".join(
            [
                f"{idx+1}. {content}" if self.ordered else f"- {content}"
                for idx, content in enumerate(self.contents)
            ]
        )

    def render_description(self) -> str:
        return self.render_readme()

    def render_workshop(self) -> str:
        tag = "olist" if self.ordered else "list"

        contents = "\n".join(
            f"{INDENT_MAP[Context.WORKSHOP]*" "}[*]{content}"
            for content in self.contents
        )
        return f"[{tag}]\n{contents}\n[/{tag}]"


class UL(List):
    def __init__(self, *contents: list[str], context: Context = Context.ALL):
        super().__init__(False, contents, context=context)


class Anchor(Element):
    content: str
    link: str

    def __init__(
        self,
        content: str,
        link: str,
        *,
        context: Context = Context.ALL ^ Context.DESCRIPTION,
    ):
        super().__init__(context=context)

        self.content = content
        self.link = link

    def render_readme(self) -> str:
        return f"[{self.content}]({self.link})"

    def render_description(self) -> str:
        raise RuntimeError("anchors are not not supported in the description Context")

    def render_workshop(self) -> str:
        return f"[url={self.link}]{self.content}[/url]"


class Elements:
    elements: list[Element]

    def __init__(self, *elements: list[Element]):
        self.elements = elements

    def get_renderable_elements(self, context: Context) -> list[Element]:
        return list(filter(lambda el: el.should_render(context), self.elements))

    def render(self, context: Context) -> str:
        contents = ""
        for el in (to_render := self.get_renderable_elements(context)):
            contents += el.render(context) + "\n"
            if el != to_render[-1]:
                contents += "\n"

        return contents


elements = Elements(
    Title("Evan's Mod", context=Context.NON_WORKSHOP),
    Header(1, "Info", context=Context.NON_README),
    Text("Open Source on GitHub. Report issues there.", context=Context.NON_README),
    Text("This mod adds my personal mix of vanilla-like features:"),
    UL(
        "Greater & Super Battle Potion to increase enemy spawn rates and limits.",
        "Yoyo Gauntlet combines the effects of the Yoyo Bag with the Fire Gauntlet.",
        "Defender of Cthulhu permanently grants the ability to dash.",
    ),
    Header(1, "Off By Default", context=Context.ALL),
    UL(
        "Merchant sells Greater Healing Potions post-Mechanicals.",
        "Merchant sells Super Healing Potions post-Cultist.",
        "Wizard sells Super Mana Potions post-Cultist.",
        "Wizard sells voodoo dolls post respective bosses.",
        "Dryad sells Herb Bags post-Skeletron.",
    ),
    Header(1, "Links", context=Context.WORKSHOP),
    Anchor(
        "Open Source Code on Github",
        GIT_REPO,
        context=Context.WORKSHOP,
    ),
    Anchor(
        "Issue Tracker",
        GIT_REPO + "/issues",
        context=Context.WORKSHOP,
    ),
)

for path in ("README.md", "description.txt", "description_workshop.txt"):
    ctx = Context.from_path(path)
    with open(path, "w", encoding="utf-8") as file:
        file.write(elements.render(ctx))
