using AplixaTools.PDFEdit.Models;
using AplixaTools.PDFEdit.Services;
using AplixaTools.PDFEdit.Shared;
using AplixaTools.Shared.Components;
using Microsoft.AspNetCore.Components;

namespace AplixaTools.PDFEdit.Components;

public partial class OutputPages : IDisposable {
    [Inject] public JsInteropService JsInterop { get; set; }
    [Inject] public PdfMutationQueueService MutationService { get; set; }

    [Parameter] public InputPages InputPages { get; set; }
    [Parameter] public PageSettingsModal PageSettingsModal { get; set; }
    [Parameter] public Modal ConfirmClearModal { get; set; }

    public int SelectedPage;

    private string _outputDocumentFileName = "merge.pdf";
    private CancellationTokenSource _previewCancellationTokenSource = new();
    private PdfFile _outputDocument = null;
    private bool _loading = false;
    
    public DragDropArea<PreviewPage> DragDropArea { get; set; }

    protected override void OnInitialized()
    {
        MutationService.PreviewUpdated += MutationServiceOnPreviewUpdated;
        base.OnInitialized();
    }

    private void MutationServiceOnPreviewUpdated(object sender, MutationQueuedEventArgs e)
    {
        DragDropArea.Update(e.ComputedPreviews);
        StateHasChanged();
        Console.WriteLine("Preview Updated");
    }

    public async Task UpdateMerge()
    {
        StartLoading();

        _previewCancellationTokenSource.Cancel();
        _previewCancellationTokenSource = new();

        var inputDocuments = await Task.Run(MutationService.ProcessMutations);

        if (inputDocuments.Count == 0)
        {
            _outputDocument = null;
            return;
        }

        _outputDocument = await Task.Run(() => PdfUtils.MergePdfFiles(inputDocuments, _outputDocumentFileName));
        _loading = false;
        StateHasChanged();
    }

    private void FileNameOnValueChanged(string fileName)
    {
        _outputDocumentFileName = fileName;

        if (_outputDocument is { })
        {
            _outputDocument.Name = fileName;
        }
    }

    private async Task OnPageRemoved(int pageIndex)
    {
        StartLoading();

        MutationService.QuequeMutation(new PdfRemovePageMutation(pageIndex));

        await UpdateMerge();
    }

    private async Task OutputPreviewOnItemDrop(int[] order)
    {
        StartLoading();

        MutationService.QuequeMutation(new PdfRearrangementMutation(order));

        await UpdateMerge();
    }

    private void OnSettings(int pageIndex)
    {
        SelectedPage = pageIndex;
        var transform = MutationService.Previews[pageIndex].Transform;
        PageSettingsModal.Show(transform.Angle);
    }

    private async Task MergeButtonOnClick()
    {
        if (_outputDocument is not { })
        {
            await UpdateMerge();
            if (_outputDocument is not { })
            {
                return;
            }
        }
        await JsInterop.DownloadByteArrayAsync(_outputDocument.Name, _outputDocument.Content, CancellationToken.None);
    }

    private void ClearButtonOnClick()
    {
        ConfirmClearModal.Show();
    }

    public void StartLoading()
    {
        _loading = true;
        StateHasChanged();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _previewCancellationTokenSource.Dispose();
    }
}