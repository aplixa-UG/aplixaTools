using Microsoft.JSInterop;
using AplixaTools.Shared.Services;
using AplixaTools.PDFEdit.Models;

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
            Prefix + "run"
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
            Prefix + "pdfUtils.PDFtoJPEG",
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

    public Pos2 GetMousePosInContainer(string container)
    {
        var mousePos = JsRuntime.Invoke<float[]>(Prefix + "utils.getMousePosInContainer", container);
        return new Pos2
        {
            X = mousePos[0],
            Y = mousePos[1]
        };
    }

	public ElementDimensions GetElementDimensions(string container, string element)
	{
		var dim = JsRuntime.Invoke<float[]>(
            Prefix + "utils.getElementDimensions",
            container,
            element
        );

		return new ElementDimensions
		{
			Position = new Pos2
            {
                X = dim[0],
                Y = dim[1],
			},
            Size = new Pos2
			{
				X = dim[2],
				Y = dim[3],
			}
		};
	}

    public void StickElementToCursor(string element)
    {
        JsRuntime.InvokeVoid(Prefix + "utils.stickElementToCursor", element);
    }

	public void UnstickElementFromCursor()
	{
		JsRuntime.InvokeVoid(Prefix + "utils.unstickElementsFromCursor");
	}
}