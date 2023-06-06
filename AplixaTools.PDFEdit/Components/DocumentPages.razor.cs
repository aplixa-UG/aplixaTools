using Microsoft.AspNetCore.Components;
using AplixaTools.PDFEdit.Services;
using AplixaTools.PDFEdit.Models;

namespace AplixaTools.PDFEdit.Components;

public partial class DocumentPages
{
    [Inject] public JsInteropService JsInterop { get; set; }

    /// <summary>
    /// The document of which the pages should be displayed
    /// </summary>
    [Parameter] public PdfFile Document { get; set; }
    /// <summary>
    /// The index of the DocumentPages element (Used as an identifier for the events)
    /// </summary>
    [Parameter] public int Index { get; set; }
    /// <summary>
    /// Fires when the user clicks on a page to add it
    /// </summary>
    [Parameter] public EventCallback<(int, int)> OnPageAdded { get; set; }
    /// <summary>
    /// Fires when the user adds the entire document
    /// </summary>
    [Parameter] public EventCallback<int> OnDocumentAdded { get; set; }
    /// <summary>
    /// Fires when the user removes the document
    /// </summary>
    [Parameter] public EventCallback<int> OnDocumentRemoved { get; set; }

    private readonly List<string> _pageRenders = new();

    protected override async Task OnInitializedAsync()
    {
        for (int i = 0; i < Document.PageCount; i++)
        {
            _pageRenders.Add(await JsInterop.PDFtoJPEGAsync(Document.Content, i, CancellationToken.None));
            StateHasChanged();
        }
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            JsInterop.RegisterTooltips($"div#document-pages-{GetHashCode()}");
        }
        base.OnAfterRender(firstRender);
    }

    private async Task Remove()
    {
        JsInterop.HideAllTooltips($"div#document-pages-{GetHashCode()}");
        await OnDocumentRemoved.InvokeAsync(Index);
    }
}