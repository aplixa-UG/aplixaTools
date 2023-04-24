using Microsoft.JSInterop;

namespace PDFEdit.Services;

public class DefaultJsInteropService
{
    protected const string Prefix = "org.site.";
    protected readonly IJSInProcessRuntime JsRuntime;

    public DefaultJsInteropService(IJSInProcessRuntime jsRuntime)
    {
        JsRuntime = jsRuntime;
    }

    public string GetContent(string id, bool remove)
    {
        return JsRuntime.Invoke<string>(
            Prefix + "content.getContent",
            id,
            remove);
    }
}