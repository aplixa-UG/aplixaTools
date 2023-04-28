using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PDFEdit.Extensions;
using PDFEdit.Services;
using PDFEdit.Shared;

namespace PDFEdit.Pages;

[Route(Routes.CombineTool)]
public partial class Combine
{
    [Inject] public JsInteropService JsInterop { get; set; }

    private List<PdfFile> _fileSources = new();
    private List<byte[]> _inputDocuments = new();
    private List<string> _outputDocumentPreviewPages = new();

    private PdfFile _outputDocument;
    private Rectangle _pageSize = PageSize.A4;
    private bool _landscapeOrientation = false;

    private async Task OnChange(InputFileChangeEventArgs e)
    {
        foreach (var file in e.GetMultipleFiles(e.FileCount))
        {
            using var stream = file.OpenReadStream(int.MaxValue);

            var bytes = new byte[file.Size];

            await stream.ReadAsync(bytes);

            var reader = new PdfReader(bytes);

            _fileSources.Add(new PdfFile
            {
                Name = file.Name,
                PageCount = reader.NumberOfPages,
                Content = bytes
            });
        }
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

    private async Task DocumentPagesOnPageAdded(int documentIndex, int pageIndex)
    {
        var doc = _fileSources[documentIndex];
        var page = PdfUtils.ExtractPages(doc.Content, "", pageIndex, pageIndex + 1);
        _inputDocuments.Add(page.Content);
        await UpdateMerge();
    }

    private async Task DocumentPagesOnDocumentAdded(int documentIndex)
    {
        var doc = _fileSources[documentIndex];
        _inputDocuments.Add(doc.Content);
        await UpdateMerge();
    }

    private async Task MergeButtonOnClick()
    {
        if (_outputDocument is not { } || _outputDocument.Content.Length == 0)
        {
            return;
        }
        await JsInterop.DownloadByteArray(_outputDocument.Name, _outputDocument.Content, CancellationToken.None);
    }

    private void ClearButtonOnClick()
    {

    }

    private async Task OutputPagesOnPageRemoved(int pageIndex)
    {
        var firstHalf = PdfUtils.ExtractPages(_outputDocument.Content, "", 0, pageIndex);
        var secondHalf = PdfUtils.ExtractPages(_outputDocument.Content, "", pageIndex + 1, _outputDocument.PageCount);
        if (firstHalf.PageCount == 0)
        {
            _outputDocument = secondHalf;
        }
        else if (secondHalf.PageCount == 0)
        {
            _outputDocument = firstHalf;
        }
        else
        {
            _outputDocument = PdfUtils.MergePdfFiles(new() { firstHalf.Content, secondHalf.Content }, "merge.pdf", _pageSize, _landscapeOrientation);
        }
        await UpdateMerge();
    }

    private async Task UpdateMerge()
    {
        if (_inputDocuments.Count == 0)
        {
            return;
        }

        _outputDocument = PdfUtils.MergePdfFiles(_inputDocuments, "merge.pdf", _pageSize, _landscapeOrientation);
        _outputDocumentPreviewPages.Clear();
        for (int i = 0; i < _outputDocument.PageCount; i++)
        {
            _outputDocumentPreviewPages.Add(await JsInterop.PDFtoJPEG(_outputDocument.Content, i, CancellationToken.None));
        }
        StateHasChanged();
    }
}
