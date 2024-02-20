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

    public DragDropArea<PreviewPage> DragDropArea { get; set; }
    public int SelectedPage;

    private string _outputDocumentFileName = "merge.pdf";
    private CancellationTokenSource _previewCancellationTokenSource = new();
    private PdfFile _outputDocument;
    private bool _loading;
    private double _scale = 1.0;

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
    }

    public async void MutationServiceOnMergeUpdateRequested(object sender, EventArgs e)
    {
        MutationService.RequestStartLoading();

        _previewCancellationTokenSource.Cancel();
        _previewCancellationTokenSource = new CancellationTokenSource();

        var inputDocuments = await Task.Run(MutationService.ProcessMutations);

        if (inputDocuments.Count == 0)
        {
            _outputDocument = null;
            ChangeLoadingState(false);
            return;
        }

        _outputDocument = await Task.Run(() => PdfUtils.MergePdfFiles(inputDocuments, _outputDocumentFileName));
        ChangeLoadingState(false);
    }

    public void MutationServiceOnStartLoadingRequested(object sender, EventArgs e)
    {
        ChangeLoadingState(true);
    }

    private void ZoomSliderOnValueChanged(double value)
    {
        _scale = value;
    }

    private void FileNameOnValueChanged(string fileName)
    {
        _outputDocumentFileName = fileName;

        if (_outputDocument is not null)
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
        var angle = MutationService.Previews[pageIndex].Rotation;
        PageSettingsModal.Show(angle);
    }

    private async Task MergeButtonOnClick()
    {
        if (_outputDocument is null)
        {
            MutationService.RequestMergeUpdate();
            if (_outputDocument is null)
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

    public void ChangeLoadingState(bool value)
    {
        _loading = value;
        StateHasChanged();
        JsInterop.RegisterTooltips("#output-options");
    }
}