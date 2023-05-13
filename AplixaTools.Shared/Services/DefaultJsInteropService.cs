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