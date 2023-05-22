using AplixaTools.PDFEdit.Models;
using AplixaTools.PDFEdit.Services;
using AplixaTools.PDFEdit.Shared;
using AplixaTools.Shared.Components;
using Microsoft.AspNetCore.Components;

namespace AplixaTools.PDFEdit.Components;

public partial class OutputPages : IDisposable {
    [Inject] public JsInteropService JsInterop { get; set; }

    [Parameter] public InputPages InputPages { get; set; }
    [Parameter] public PageSettingsModal PageSettingsModal { get; set; }
    [Parameter] public Modal ConfirmClearModal { get; set; }

    public int SelectedPage;

    private string _outputDocumentFileName = "merge.pdf";
    private readonly List<PreviewPage> _outputDocumentPreviewPages = new();
    private CancellationTokenSource _previewCancellationTokenSource = new();
    private PdfFile _outputDocument = new();
    private bool _loading = false;    

    private async Task OutputPreviewOnItemDrop(PreviewPage page)
    {
        if (InputPages is not {}) 
        {
            return;
        }

        StartLoading();
        
        var order = _outputDocumentPreviewPages.Select(i => i.Index).ToList();

        _outputDocumentPreviewPages.Clear();
        StateHasChanged();

        InputPages.InputDocuments = order.Select(i => InputPages.InputDocuments?[i]).ToList();

        await UpdateMerge();
    }

    public async Task UpdateMerge()
    {
        if (InputPages is not {}) 
        {
            return;
        }

        _previewCancellationTokenSource.Cancel();
        _previewCancellationTokenSource = new();
        if (InputPages.InputDocuments.Count == 0)
        {
            _outputDocument = null;
            _outputDocumentPreviewPages.Clear();
            return;
        }

        _outputDocument = PdfUtils.MergePdfFiles(InputPages.InputDocuments, _outputDocumentFileName);
        _outputDocumentPreviewPages.Clear();
        await UpdatePreview();
    }

    private void FileNameOnValueChanged(string fileName)
    {
        _outputDocumentFileName = fileName;

        if (_outputDocument is { })
        {
            _outputDocument.Name = fileName;
        }
    }

    public async Task UpdatePreview()
    {
        for (int i = 0; i < _outputDocument.PageCount; i++)
        {
            try
            {
                var preview = await JsInterop.PDFtoJPEGAsync(_outputDocument.Content, i, _previewCancellationTokenSource.Token);
                if (preview is not { })
                {
                    break;
                }
                _outputDocumentPreviewPages.Add(new PreviewPage {
                    Index = i,
                    Image = preview
                });
            }
            catch (TaskCanceledException)
            {
                break;
            }
            catch
            {
                throw;
            }
        }
        _loading = false;
        StateHasChanged();
    }

    private async Task OnPageRemoved(int pageIndex)
    {
        StartLoading();
        InputPages.InputDocuments?.RemoveAt(pageIndex);
        await UpdateMerge();
    }

    private void OnSettings(int pageIndex)
    {
        SelectedPage = pageIndex;
        var transform = InputPages.InputDocuments?[pageIndex].GetPageTransform(0);
        PageSettingsModal.Show(transform.Angle);
    }

    private async Task MergeButtonOnClick()
    {
        if (_outputDocument is not { } || _outputDocument.Content.Length == 0)
        {
            return;
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