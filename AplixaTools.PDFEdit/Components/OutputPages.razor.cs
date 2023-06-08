using AplixaTools.PDFEdit.Models;
using AplixaTools.PDFEdit.Services;
using AplixaTools.PDFEdit.Shared;
using AplixaTools.Shared.Components;
using Microsoft.AspNetCore.Components;

namespace AplixaTools.PDFEdit.Components;

public partial class OutputPages : IDisposable {
    [Inject] public JsInteropService JsInterop { get; set; }
    [Inject] public PdfMutationQueueService MutationService { get; set; }

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
        MutationService.MergeUpdateRequested += MutationServiceOnMergeUpdateRequested;
        MutationService.StartLoadingRequested += MutationServiceOnStartLoadingRequested;
        base.OnInitialized();
    }

    private void MutationServiceOnPreviewUpdated(object sender, MutationQueuedEventArgs e)
    {
        DragDropArea.Update(e.ComputedPreviews);
        StateHasChanged();
        Console.WriteLine("Preview Updated");
    }

    public async void MutationServiceOnMergeUpdateRequested(object sender, EventArgs e)
    {
        MutationService.RequestStartLoading();

        _previewCancellationTokenSource.Cancel();
        _previewCancellationTokenSource = new();

        var inputDocuments = await Task.Run(MutationService.ProcessMutations);

        if (inputDocuments.Count == 0)
        {
            _outputDocument = null;
            _loading = false;
            StateHasChanged();
            return;
        }

        _outputDocument = await Task.Run(() => PdfUtils.MergePdfFiles(inputDocuments, _outputDocumentFileName));
        _loading = false;
        StateHasChanged();
    }

    public void MutationServiceOnStartLoadingRequested(object sender, EventArgs e)
    {
        _loading = true;
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

    private void OnPageRemoved(int pageIndex)
    {
        MutationService.RequestStartLoading();

        MutationService.QueueMutation(new PdfRemovePageMutation(pageIndex));
    }

    private void OutputPreviewOnItemDrop(int[] order)
    {
        MutationService.RequestStartLoading();

        MutationService.QueueMutation(new PdfRearrangementMutation(order));
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
            MutationService.RequestMergeUpdate();
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

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _previewCancellationTokenSource.Dispose();
    }
}