async function PDFtoJPEG(bytes, pageIdx) {
    let canvas = document.createElement("canvas");

    let pdf = await pdfjsLib.getDocument({ data: bytes }).promise
    let page = await pdf.getPage(pageIdx + 1);
    let viewport = page.getViewport({ scale: 1 });

    canvas.height = viewport.height;
    canvas.width = viewport.width;

    let ctx = canvas.getContext('2d');
    let renderContext = { canvasContext: ctx, viewport: viewport };

    await page.render(renderContext).promise
    return canvas.toDataURL();
}