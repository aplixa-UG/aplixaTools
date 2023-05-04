using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PDFEdit.Components;
using PDFEdit.Services;
using PDFEdit.Shared;

namespace PDFEdit.Pages;

[Route(Routes.CombineTool)]
public partial class Combine : IDisposable
{
    [Inject] public JsInteropService JsInterop { get; set; }

    public Modal ConfirmClearModal { get; set; }
    public PageSettingsModal PageSettingsModal { get; set; }

    private List<PdfFile> _fileSources = new();
    private List<PdfFile> _inputDocuments = new();
    private List<string> _outputDocumentPreviewPages = new();

    private int _selectedPage;
    private PdfFile _outputDocument;
    private Rectangle _pageSize = PageSize.A4;
    private bool _landscapeOrientation = false;
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
            using var stream = file.OpenReadStream(int.MaxValue);

            var bytes = new byte[file.Size];

            await stream.ReadAsync(bytes);

            var reader = new PdfReader(bytes);

            var pageSizes = new List<Rectangle>();

            for (int i = 0; i < reader.NumberOfPages; i++)
            {
                pageSizes.Add(reader.GetPageSize(i + 1));
            }

            var pageTransforms = new PdfTransform[reader.NumberOfPages];

            for (int i = 0; i < pageTransforms.Length; i++)
            {
                pageTransforms[i] = new PdfTransform();
            }

            _fileSources.Add(new PdfFile
            {
                Name = file.Name,
                PageCount = reader.NumberOfPages,
                Content = bytes
            });
        }
        _dragging = false;
        StateHasChanged();
    }

    private void FileEntryOnDelete(int index)
    {
        _fileSources.RemoveAt(index);
        StateHasChanged();
    }

    private async Task PageSizeOnChanged(int index)
    {
        _pageSize = PageSizes.Sizes.Values.ElementAt(index);
        await UpdateMerge();
    }

    private async Task LandscapeOnChanged(bool value)
    {
        _landscapeOrientation = value;
        await UpdateMerge();
    }

    private async Task DocumentPagesOnPageAdded((int, int) indices)
    {
        var doc = _fileSources[indices.Item1];
        var page = PdfUtils.ExtractPages(doc, indices.Item2, indices.Item2 + 1);
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
            var page = PdfUtils.ExtractPages(doc, i, i + 1);
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

    private void DragFileInputOnDragEnter()
    {

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
        var transform = PdfUtils.GetPageTransform(_inputDocuments[pageIndex], 0);
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
        _inputDocuments[_selectedPage] = PdfUtils.TransformPage(_inputDocuments[_selectedPage], 0, new PdfTransform
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
        for (int i = 0; i < _outputDocument.PageCount; i++)
        {
            try
            {
                var preview = await JsInterop.PDFtoJPEGAsync(_outputDocument.Content, i, _previewCancellationTokenSource.Token);
                if (preview is not { })
                {
                    break;
                }
                _outputDocumentPreviewPages.Add(preview);
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
        _previewCancellationTokenSource.Dispose();
    }
}
