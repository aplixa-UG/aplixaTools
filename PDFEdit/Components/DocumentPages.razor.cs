using Microsoft.AspNetCore.Components;
using PDFEdit.Services;
using PDFEdit.Shared;

namespace PDFEdit.Components;

public partial class DocumentPages
{
    [Inject] public JsInteropService JsInterop { get; set; }

    [Parameter] public PdfFile Document { get; set; }
    [Parameter] public int Index { get; set; }
    [Parameter] public EventCallback<(int, int)> OnPageAdded { get; set; }
    [Parameter] public EventCallback<int> OnDocumentAdded { get; set; }

    private List<string> _pageRenders = new();

    protected override async Task OnInitializedAsync()
    {
        for (int i = 0; i < Document.PageCount; i++)
        {
            _pageRenders.Add(await JsInterop.PDFtoJPEGAsync(Document.Content, i, CancellationToken.None));
            StateHasChanged();
        }
    }
}