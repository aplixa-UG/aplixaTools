namespace org.site.pdfUtils {

    declare var pdfjsLib: any;

    export async function PDFtoJPEG(bytes: Uint8Array, pageIdx: number): Promise<PdfPreview> {
        let canvas = document.createElement("canvas");

        let pdf = await pdfjsLib.getDocument({ data: bytes }).promise
        let page = await pdf.getPage(pageIdx + 1);
        let viewport = page.getViewport({ scale: 1 });

        canvas.height = viewport.height;
        canvas.width = viewport.width;

        let ctx = canvas.getContext('2d');
        let renderContext = { canvasContext: ctx, viewport: viewport };

        await page.render(renderContext).promise

        const width = canvas.width;
        const height = canvas.height;

        const deg0 = canvas
            .toDataURL();

        const deg90 = rotateCanvas(canvas, 90)
            .toDataURL();

        const deg180 = rotateCanvas(canvas, 180)
            .toDataURL();

        const deg270 = rotateCanvas(canvas, 270)
            .toDataURL();


        return {
            Rot0deg: deg0,
            Rot90deg: deg90,
            Rot180deg: deg180,
            Rot270deg: deg270,
            Width: width,
            Height: height
        } as PdfPreview;
    }

    function rotateCanvas(canvas: HTMLCanvasElement, angle: number): HTMLCanvasElement {
        let rcanvas = document.createElement("canvas");
        let rctx = rcanvas.getContext('2d');

        let width = angle == 90 || angle == 270
            ? canvas.height
            : canvas.width
            ;
        let height = angle == 90 || angle == 270
            ? canvas.width
            : canvas.height
            ;

        rcanvas.width = width;
        rcanvas.height = height;

        rctx.translate(width / 2, height / 2);
        rctx.rotate(angle * Math.PI / 180);
        rctx.drawImage(canvas, -1 * canvas.width / 2, -1 * canvas.height / 2);
        return rcanvas;
    }

    export class PdfPreview {
        Rot0deg: string;
        Rot90deg: string;
        Rot180deg: string;
        Rot270deg: string;
        Width: number;
        Height: number;
    }
}