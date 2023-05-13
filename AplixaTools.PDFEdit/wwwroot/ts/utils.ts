namespace org.site.utils {
    export async function downloadByteArray(fileName: string, bytes: Uint8Array) {
        console.log(fileName);
        console.log(bytes.length);
        const blob = new Blob([bytes]);
        const url = URL.createObjectURL(blob);
        const anchorElement = document.createElement('a');
        anchorElement.href = url;
        anchorElement.download = fileName ?? '';
        anchorElement.click();
        anchorElement.remove();
        URL.revokeObjectURL(url);
    }
}