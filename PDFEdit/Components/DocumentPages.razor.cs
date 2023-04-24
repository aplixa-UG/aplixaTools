using PDFEdit.Shared;
using Microsoft.AspNetCore.Components;
using PDFEdit.Services;
using PDFEdit.Extensions;

namespace PDFEdit.Components;

public partial class DocumentPages {
    [Inject] public JsInteropService JsInterop { get; set; }

    [Parameter] public PdfFile Document { get; set; }

    private List<string> _pageRenders = new();

    protected override async Task OnInitializedAsync() {
        for (int i = 0; i < Document.PageCount; i++) {
            _pageRenders.Add(await JsInterop.PDFtoJPEG(Document.Content, i, CancellationToken.None));
            StateHasChanged();
        }
    }
}