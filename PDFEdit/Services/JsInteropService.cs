using Microsoft.JSInterop;

namespace PDFEdit.Services;

public class JsInteropService : DefaultJsInteropService
{
    public JsInteropService(IJSInProcessRuntime jsRuntime)
        : base(jsRuntime)
    {
    }

    public async Task<string> PDFtoJPEGAsync(byte[] pdf, int i, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return null;
        }

        return await JsRuntime.InvokeAsync<string>(
            "PDFtoJPEG",
            cancellationToken,
            pdf,
            i
        );
    }

    public async Task DownloadByteArrayAsync(string fileName, byte[] bytes, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        await JsRuntime.InvokeVoidAsync(
            Prefix + "utils.downloadByteArray",
            cancellationToken,
            fileName,
            bytes
        );
    }

    public void ShowModal(string id)
    {
        JsRuntime.InvokeVoid(
            Prefix + "modal.show",
            id
        );
    }

    public void HideModal(string id)
    {
        JsRuntime.InvokeVoid(
            Prefix + "modal.hide",
            id
        );
    }
}