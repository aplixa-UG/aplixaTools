namespace org.site {
    export var mousePosition = {
        x: 0,
        y: 0
    };

    export var mouseMoveEventCallback = (x: number, y: number) => { };

    export function run() {
        org.site.tooltip.register("");

        document.onmousemove = e => {
            mousePosition = {
                x: e.clientX,
                y: e.clientY
            };
            mouseMoveEventCallback(e.clientX, e.clientY);
        };
    }
}