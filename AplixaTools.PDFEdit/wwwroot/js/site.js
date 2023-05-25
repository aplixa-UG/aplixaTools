var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var org;
(function (org) {
    var site;
    (function (site) {
        function PDFtoJPEG(bytes, pageIdx) {
            return __awaiter(this, void 0, void 0, function* () {
                let canvas = document.createElement("canvas");
                let pdf = yield pdfjsLib.getDocument({ data: bytes }).promise;
                let page = yield pdf.getPage(pageIdx + 1);
                let viewport = page.getViewport({ scale: 1 });
                canvas.height = viewport.height;
                canvas.width = viewport.width;
                let ctx = canvas.getContext('2d');
                let renderContext = { canvasContext: ctx, viewport: viewport };
                yield page.render(renderContext).promise;
                return canvas.toDataURL();
            });
        }
        site.PDFtoJPEG = PDFtoJPEG;
    })(site = org.site || (org.site = {}));
})(org || (org = {}));
var org;
(function (org) {
    var site;
    (function (site) {
        site.mousePosition = {
            x: 0,
            y: 0
        };
        site.mouseMoveEventCallback = (x, y) => { };
        function run() {
            org.site.tooltip.register("");
            document.onmousemove = e => {
                site.mousePosition = {
                    x: e.clientX,
                    y: e.clientY
                };
                site.mouseMoveEventCallback(e.clientX, e.clientY);
            };
        }
        site.run = run;
    })(site = org.site || (org.site = {}));
})(org || (org = {}));
var org;
(function (org) {
    var site;
    (function (site) {
        var utils;
        (function (utils) {
            function downloadByteArray(fileName, bytes) {
                return __awaiter(this, void 0, void 0, function* () {
                    const blob = new Blob([bytes]);
                    const url = URL.createObjectURL(blob);
                    const anchorElement = document.createElement('a');
                    anchorElement.href = url;
                    anchorElement.download = fileName !== null && fileName !== void 0 ? fileName : '';
                    anchorElement.click();
                    anchorElement.remove();
                    URL.revokeObjectURL(url);
                });
            }
            utils.downloadByteArray = downloadByteArray;
            function getMousePosInContainer(query) {
                var container = document.querySelector(query);
                var rect = container.getBoundingClientRect();
                var x = org.site.mousePosition.x + container.scrollLeft - rect.left;
                var y = org.site.mousePosition.y + container.scrollTop - rect.top;
                return [x, y];
            }
            utils.getMousePosInContainer = getMousePosInContainer;
            function getElementSize(elem) {
                var rect = document.querySelector(elem).getBoundingClientRect();
                return [rect.x, rect.y];
            }
            utils.getElementSize = getElementSize;
            function getElementDimensions(containerQuery, elementQuery) {
                var container = document.querySelector(containerQuery);
                var elem = container.querySelector(elementQuery);
                var containerRect = container.getBoundingClientRect();
                var elemRect = elem.getBoundingClientRect();
                var x = elemRect.left - containerRect.left;
                var y = elemRect.top - containerRect.top;
                return [x, y, elemRect.width, elemRect.height];
            }
            utils.getElementDimensions = getElementDimensions;
            function getCssProperty(elem, property) {
                return $(elem).css(property);
            }
            utils.getCssProperty = getCssProperty;
            var elementStuckToCursor = null;
            function stickElementToCursor(query) {
                var elem = document.querySelector(query);
                var rect = elem.getBoundingClientRect();
                var relativePos = {
                    x: site.mousePosition.x - rect.left,
                    y: site.mousePosition.y - rect.top,
                };
                elementStuckToCursor = document.body.appendChild(elem.cloneNode(true));
                elementStuckToCursor.style.position = "fixed";
                elementStuckToCursor.style.pointerEvents = "none";
                elementStuckToCursor.style.opacity = ".3";
                elementStuckToCursor.animate({
                    left: site.mousePosition.x - relativePos.x + "px",
                    top: site.mousePosition.y - relativePos.y + "px",
                }, { duration: 500, fill: "forwards" });
                site.mouseMoveEventCallback = (x, y) => {
                    elementStuckToCursor.animate({
                        left: x - relativePos.x + "px",
                        top: y - relativePos.y + "px",
                    }, { duration: 500, fill: "forwards" });
                };
            }
            utils.stickElementToCursor = stickElementToCursor;
            function unstickElementsFromCursor() {
                elementStuckToCursor.remove();
                site.mouseMoveEventCallback = () => { };
            }
            utils.unstickElementsFromCursor = unstickElementsFromCursor;
        })(utils = site.utils || (site.utils = {}));
    })(site = org.site || (org.site = {}));
})(org || (org = {}));
var org;
(function (org) {
    var site;
    (function (site) {
        var modal;
        (function (modal) {
            function show(id) {
                $(id).modal('show');
            }
            modal.show = show;
            function hide(id) {
                $(id).modal('hide');
            }
            modal.hide = hide;
        })(modal = site.modal || (site.modal = {}));
    })(site = org.site || (org.site = {}));
})(org || (org = {}));
var org;
(function (org) {
    var site;
    (function (site) {
        var tooltip;
        (function (tooltip) {
            function register(parentSelector) {
                $(`${parentSelector} [data-bs-toggle="tooltip"]`).tooltip();
            }
            tooltip.register = register;
            function hideAll(parentSelector) {
                $(`${parentSelector} [data-bs-toggle="tooltip"]`).tooltip("hide");
            }
            tooltip.hideAll = hideAll;
        })(tooltip = site.tooltip || (site.tooltip = {}));
    })(site = org.site || (org.site = {}));
})(org || (org = {}));
//# sourceMappingURL=site.js.map