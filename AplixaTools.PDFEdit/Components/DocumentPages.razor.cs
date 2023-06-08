using Microsoft.AspNetCore.Components;
using AplixaTools.PDFEdit.Services;
using AplixaTools.PDFEdit.Models;

namespace AplixaTools.PDFEdit.Components;

public partial class DocumentPages
{
    [Inject] public PdfMutationQueueService MutationService { get; set; }
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
    [Parameter] public EventCallback OnUpdate { get; set; }
    /// <summary>
    /// Fires when the user removes the document
    /// </summary>
    [Parameter] public EventCallback<int> OnDocumentRemoved { get; set; }

    public readonly List<string> PageRenders = new();

    private bool _pagesRendered = false;
    private bool _addDocument = false;

    protected override async Task OnInitializedAsync()
    {
        for (int i = 0; i < Document.PageCount; i++)
        {
            PageRenders.Add(await JsInterop.PDFtoJPEGAsync(Document.Content, i, CancellationToken.None));
            StateHasChanged();
        }
        _pagesRendered = true;
        StateHasChanged();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            JsInterop.RegisterTooltips($"div#document-pages-{GetHashCode()}");
        }

        if (_addDocument && _pagesRendered)
        {
            _addDocument = false;

            for (int i = 0; i < Document.PageCount; i++)
            {
                var page = Document.ExtractPages(i, i + 1);

                MutationService.RequestStartLoading();

                MutationService.QueueMutation(
                new PdfAddFileMutation(
                    page,
                    new PreviewPage
                    {
                        Image = PageRenders[i]
                    }
                )
            );
            }
            await OnUpdate.InvokeAsync();
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task Remove()
    {
        JsInterop.HideAllTooltips($"div#document-pages-{GetHashCode()}");
        await OnDocumentRemoved.InvokeAsync(Index);
    }

    public void DocumentAdded()
    {
        _addDocument = true;
    }


    private async Task PageAdded(int index)
    {
        var page = Document.ExtractPages(index, index + 1);

        MutationService.RequestStartLoading();

        MutationService.QueueMutation(
            new PdfAddFileMutation(
                page,
                new PreviewPage
                {
                    Image = PageRenders[index]
                }
            )
        );
        await OnUpdate.InvokeAsync();
    }
}