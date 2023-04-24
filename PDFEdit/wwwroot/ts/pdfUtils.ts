namespace org.site.pdfUtils {

    export async function PDFtoJPEG(bytes: Uint8Array, pageNum: number): Promise<string> {

        let canvas = document.createElement("canvas");
        let doc = await pdfjs.getDocument({ data: bytes }).promise;

        let page = await doc.getPage(pageNum);

        var viewport = page.getViewport({
            scale: 1
        });

        var render_context = {
            canvasContext: canvas.getContext('2d'),
            viewport: viewport
        };

        await page.render(render_context);

        return canvas.toDataURL();

    }

}