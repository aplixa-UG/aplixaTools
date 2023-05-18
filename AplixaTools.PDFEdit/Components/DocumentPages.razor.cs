using Microsoft.AspNetCore.Components;
using AplixaTools.PDFEdit.Services;
using AplixaTools.PDFEdit.Shared;

namespace AplixaTools.PDFEdit.Components;

public partial class DocumentPages
{
    [Inject] public JsInteropService JsInterop { get; set; }

    [Parameter] public PdfFile Document { get; set; }
    [Parameter] public int Index { get; set; }
    [Parameter] public EventCallback<(int, int)> OnPageAdded { get; set; }
    [Parameter] public EventCallback<int> OnDocumentAdded { get; set; }
    [Parameter] public EventCallback<int> OnDocumentRemoved { get; set; }

    private List<string> _pageRenders = new();

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