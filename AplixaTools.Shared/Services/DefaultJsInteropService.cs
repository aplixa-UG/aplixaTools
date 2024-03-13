using Microsoft.JSInterop;

namespace AplixaTools.Shared.Services;

public class DefaultJsInteropService
{
    protected const string Prefix = "org.site.";
    protected readonly IJSInProcessRuntime JsRuntime;

    public DefaultJsInteropService(IJSInProcessRuntime jsRuntime)
    {
        JsRuntime = jsRuntime;
    }

    public async Task ShowModal(string id)
    {
        await JsRuntime.InvokeVoidAsync(
            Prefix + "modal.show",
            id
        );
    }

    public async Task HideModal(string id)
    {
        await JsRuntime.InvokeVoidAsync(
            Prefix + "modal.hide",
            id
        );
    }
}