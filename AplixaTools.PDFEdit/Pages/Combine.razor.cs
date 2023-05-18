using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using AplixaTools.PDFEdit.Components;
using AplixaTools.PDFEdit.Services;
using AplixaTools.PDFEdit.Shared;
using AplixaTools.Shared.Components;
using iText.Kernel.Pdf;

namespace AplixaTools.PDFEdit.Pages;

[Route(Routes.CombineTool)]
public partial class Combine : IDisposable
{
    [Inject] public JsInteropService JsInterop { get; set; }

    public Modal ConfirmClearModal { get; set; }
    public PageSettingsModal PageSettingsModal { get; set; }

    private readonly List<PdfFile> _fileSources = new();
    private readonly List<PreviewPage> _outputDocumentPreviewPages = new();
    private List<PdfFile> _inputDocuments = new();

    private int _selectedPage;
    private PdfFile _outputDocument;
    private string _outputDocumentFileName = "merge.pdf";

    private CancellationTokenSource _previewCancellationTokenSource = new();

    private bool _dragging = false;

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            JsInterop.Startup();
        }
        base.OnAfterRender(firstRender);
    }

    private async Task FileInputOnChange(InputFileChangeEventArgs e)
    {
        foreach (var file in e.GetMultipleFiles(e.FileCount))
        {
            using var inputStream = file.OpenReadStream(int.MaxValue);
            using var inputStreamCopy = new MemoryStream();

            await inputStream.CopyToAsync(inputStreamCopy);
            inputStreamCopy.Position = 0;

            var doc = new PdfDocument(new PdfReader(inputStreamCopy));

            _fileSources.Add(new PdfFile
            {
                Name = file.Name,
                PageCount = doc.GetNumberOfPages(),
                Content = inputStreamCopy.ToArray()
            });
        }
        _dragging = false;
        StateHasChanged();
    }

    private async Task DocumentPagesOnPageAdded((int, int) indices)
    {
        var doc = _fileSources[indices.Item1];
        var page = doc.ExtractPages(indices.Item2, indices.Item2 + 1);
        _inputDocuments.Add(page);
        await UpdateMerge();
    }

    private async Task DocumentPagesOnDocumentRemoved(int index)
    {
        _fileSources.RemoveAt(index);
        await UpdateMerge();
    }

    private async Task DocumentPagesOnDocumentAdded(int documentIndex)
    {
        var doc = _fileSources[documentIndex];
        for (int i = 0; i < doc.PageCount; i++)
        {
            var page = doc.ExtractPages(i, i + 1);
            _inputDocuments.Add(page);
        }
        await UpdateMerge();
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

    private async Task OutputPagesOnPageRemoved(int pageIndex)
    {
        _inputDocuments.RemoveAt(pageIndex);
        await UpdateMerge();
    }

    private void OutputPagesOnSettings(int pageIndex)
    {
        _selectedPage = pageIndex;
        var transform = _inputDocuments[pageIndex].GetPageTransform(0);
        PageSettingsModal.Show(transform.Angle);
    }

    private async Task ConfirmClearOnClick()
    {
        _inputDocuments.Clear();
        await UpdateMerge();
        ConfirmClearModal.Hide();
    }

    private async Task PageSettingsOnSave()
    {
        _inputDocuments[_selectedPage] = _inputDocuments[_selectedPage].TransformPage(0, new PdfTransform
        {
            Angle = PageSettingsModal.Rotation,
        });
        await UpdateMerge();
    }

    private void FileNameOnValueChanged(string fileName)
    {
        _outputDocumentFileName = fileName;

        if (_outputDocument is { })
        {
            _outputDocument.Name = fileName;
        }
    }

    private async Task OutputPreviewOnItemDrop(PreviewPage page) {
        var order = _outputDocumentPreviewPages.Select(i => i.Index).ToList();

        _outputDocumentPreviewPages.Clear();
        StateHasChanged();

        _inputDocuments = order.Select(i => _inputDocuments[i]).ToList();

        await UpdateMerge();
    }

    private async Task UpdateMerge()
    {
        _previewCancellationTokenSource.Cancel();
        _previewCancellationTokenSource = new();
        if (_inputDocuments.Count == 0)
        {
            _outputDocument = null;
            _outputDocumentPreviewPages.Clear();
            return;
        }

        _outputDocument = PdfUtils.MergePdfFiles(_inputDocuments, _outputDocumentFileName);
        _outputDocumentPreviewPages.Clear();
        await UpdatePreview();
    }

    public async Task UpdatePreview() {
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
        StateHasChanged();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _previewCancellationTokenSource.Dispose();
    }
}
