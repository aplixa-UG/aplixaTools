namespace org.site.utils {
    export async function downloadByteArray(fileName: string, bytes: Uint8Array) {
        const blob = new Blob([bytes]);
        const url = URL.createObjectURL(blob);
        const anchorElement = document.createElement('a');
        anchorElement.href = url;
        anchorElement.download = fileName ?? '';
        anchorElement.click();
        anchorElement.remove();
        URL.revokeObjectURL(url);
    }

    export function getMousePosInContainer(query: string): number[] {
        var container = document.querySelector(query);
        var rect = container.getBoundingClientRect();

        var x = org.site.mousePosition.x + container.scrollLeft - rect.left;
        var y = org.site.mousePosition.y + container.scrollTop - rect.top;

        return [x, y];
    }

    export function getElementSize(elem: string): number[] {
        var rect = document.querySelector(elem).getBoundingClientRect();
        
        return [rect.x, rect.y];
    }

    export function getElementDimensions(containerQuery: string, elementQuery: string): number[] {
        var container = document.querySelector(containerQuery);
        var elem = container.querySelector(elementQuery);

        var containerRect = container.getBoundingClientRect();
        var elemRect = elem.getBoundingClientRect();

        var x = elemRect.left - containerRect.left;
        var y = elemRect.top - containerRect.top;

        return [x, y, elemRect.width, elemRect.height];
    }

    export function getCssProperty(elem: string, property: string): string {
        return $(elem).css(property);
    }

    var elementStuckToCursor: HTMLElement = null;

    export function stickElementToCursor(query: string) {
        var elem = document.querySelector(query);
        var rect = elem.getBoundingClientRect();
        var relativePos = {
            x: mousePosition.x - rect.left,
            y: mousePosition.y - rect.top,
        };
        elementStuckToCursor = document.body.appendChild(elem.cloneNode(true)) as HTMLElement;

        elementStuckToCursor.style.position = "fixed";
        elementStuckToCursor.style.pointerEvents = "none";
        elementStuckToCursor.style.opacity = ".3";

        elementStuckToCursor.animate({
            left: mousePosition.x - relativePos.x + "px",
            top: mousePosition.y - relativePos.y + "px",
        }, { duration: 500, fill: "forwards" })

        mouseMoveEventCallback = (x, y) => {
            elementStuckToCursor.animate({
                left: x - relativePos.x + "px",
                top: y - relativePos.y + "px",
            }, { duration: 500, fill: "forwards" })
        };
    }

    export function unstickElementsFromCursor() {
        elementStuckToCursor.remove();
        mouseMoveEventCallback = () => { }
    }

    export function getHoveredItemAttribute(attr: string): string {
        while (!hoveredItem.is("div")) {
            hoveredItem = hoveredItem.parent();
        }
        return hoveredItem.attr(attr);
    }
}