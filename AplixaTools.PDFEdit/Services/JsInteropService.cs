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

    /// <summary>
    /// Initialize the JS Backend
    /// </summary>
    public void Startup()
    {
        JsRuntime.InvokeVoid(
            Prefix + "run"
        );
    }

    /// <summary>
    /// Register all popper.js/bootstrap tooltips in a container
    /// </summary>
    /// <param name="container">The CSS-Style selector of the container</param>
    public void RegisterTooltips(string container)
    {
        JsRuntime.InvokeVoid(
            Prefix + "tooltip.register",
            container
        );
    }

	/// <summary>
	/// Hide all popper.js/bootstrap tooltips in a container
	/// </summary>
	/// <param name="container">The CSS-Style selector of the container</param>
	public void HideAllTooltips(string container)
    {
        JsRuntime.InvokeVoid(
            Prefix + "tooltip.hideAll",
            container
        );
    }

    /// <summary>
    /// Convert a PDF to JPEG using pdf.js
    /// </summary>
    /// <param name="pdf">The PDF File as a byte array</param>
    /// <param name="i">The page index</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The Base64-Encoded JPEG of the page in the PDF</returns>
    public async Task<PdfPreview> PDFtoJPEGAsync(byte[] pdf, int i, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return null;
        }

        return await JsRuntime.InvokeAsync<PdfPreview>(
            Prefix + "pdfUtils.PDFtoJPEG",
            cancellationToken,
            pdf,
            i
        );
    }

    /// <summary>
    /// Request the download of a file onto the client's machine
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="bytes"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

	/// <summary>
	/// Get the position of the mouse cursor relative to a DOM element
	/// </summary>
	/// <param name="container">The CSS-Style selector of the container</param>
	/// <returns>The position of the cursor relative to the container</returns>
	public Pos2 GetMousePosInContainer(string container)
    {
        var mousePos = JsRuntime.Invoke<float[]>(Prefix + "utils.getMousePosInContainer", container);
        return new Pos2
        {
            X = mousePos[0],
            Y = mousePos[1]
        };
    }

	/// <summary>
	/// Get the dimensions of a DOM element
	/// </summary>
	/// <param name="container">The CSS-Style selector of the container</param>
	/// <param name="element">The element to retreive the dimensions from</param>
	/// <returns>The dimensions of a DOM element as ElementDimensions</returns>
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

	public Pos2 GetImageSize(string image)
	{
		var dim = JsRuntime.Invoke<float[]>(
			Prefix + "utils.getImageSize",
			image
		);

		return new Pos2
		{
			X = dim[0],
			Y = dim[1],
		};
	}

	/// <summary>
	/// Copy a DOM element and make it follow the mouse cursor
	/// </summary>
	/// <param name="element"></param>
	public void StickElementToCursor(string element)
    {
        JsRuntime.InvokeVoid(Prefix + "utils.stickElementToCursor", element);
    }

    /// <summary>
    /// Detaches all the copied elements from the cursor and deletes the copies
    /// </summary>
	public void UnstickElementsFromCursor()
	{
		JsRuntime.InvokeVoid(Prefix + "utils.unstickElementsFromCursor");
	}

    /// <summary>
    /// Gets an attribute on the nearest parent of type "div" on the currently hovered element
    /// </summary>
    /// <param name="attr">The attribute to get</param>
    /// <returns>The attribute's value as a string</returns>
    public string GetHoveredItemAttribute(string attr)
    {
        return JsRuntime.Invoke<string>(Prefix + "utils.getHoveredItemAttribute", attr);
    }
}