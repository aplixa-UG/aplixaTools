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
        var startup;
        (function (startup) {
            function run() {
                org.site.tooltip.register("");
            }
            startup.run = run;
        })(startup = site.startup || (site.startup = {}));
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
                    console.log(fileName);
                    console.log(bytes.length);
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