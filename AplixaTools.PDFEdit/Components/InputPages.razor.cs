using AplixaTools.PDFEdit.Models;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AplixaTools.PDFEdit.Components;

public partial class InputPages {
    [Parameter] public EventCallback UpdateMerge { get; set; }

    public List<PdfFile> InputDocuments = new();
    
    private bool _dragging = false;
    private readonly List<PdfFile> _fileSources = new();

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
        InputDocuments.Add(page);
        await UpdateMerge.InvokeAsync();
    }

    private void DocumentPagesOnDocumentRemoved(int index)
    {
        _fileSources.RemoveAt(index);
    }

    private async Task DocumentPagesOnDocumentAdded(int documentIndex)
    {
        var doc = _fileSources[documentIndex];
        for (int i = 0; i < doc.PageCount; i++)
        {
            var page = doc.ExtractPages(i, i + 1);
            InputDocuments.Add(page);
        }
        await UpdateMerge.InvokeAsync();
    }
}