﻿namespace org.site {
    export var mousePosition = {
        x: 0,
        y: 0
    };

    export var mouseMoveEventCallback = (x: number, y: number) => { };

    export var hoveredItem: JQuery<Document>;

    export function run() {
        org.site.tooltip.register("");

        $(document).on({
            mouseover: e => {
                hoveredItem = $(e.target);
            },
            mousemove: e => {
                mousePosition = {
                    x: e.clientX,
                    y: e.clientY
                };
                mouseMoveEventCallback(e.clientX, e.clientY);
            }
        });
    }
}