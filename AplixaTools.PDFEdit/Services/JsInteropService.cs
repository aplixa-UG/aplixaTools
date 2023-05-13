using Microsoft.JSInterop;
using AplixaTools.Shared.Services;

namespace AplixaTools.PDFEdit.Services;

public class JsInteropService : DefaultJsInteropService
{
    public JsInteropService(IJSInProcessRuntime jsRuntime)
        : base(jsRuntime)
    {
    }

    public void Startup()
    {
        JsRuntime.InvokeVoid(
            Prefix + "startup.run"
        );
    }

    public void RegisterTooltips(string parentSelector)
    {
        JsRuntime.InvokeVoid(
            Prefix + "tooltip.register",
            parentSelector
        );
    }

    public void HideAllTooltips(string parentSelector)
    {
        JsRuntime.InvokeVoid(
            Prefix + "tooltip.hideAll",
            parentSelector
        );
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
}