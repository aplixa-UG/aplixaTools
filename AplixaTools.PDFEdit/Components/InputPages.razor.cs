using AplixaTools.PDFEdit.Models;
using AplixaTools.PDFEdit.Services;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AplixaTools.PDFEdit.Components;

public partial class InputPages {
    [Inject] public PdfMutationQueueService MutationService { get; set; }

    private bool _dragging;
    private readonly List<PdfFile> _fileSources = new();
    public readonly List<DocumentPages> DocumentPages = new();

    private DocumentPages DocumentPagesRef
    {
        set => DocumentPages.Add(value);
    }

    private async Task FileInputOnChange(InputFileChangeEventArgs e)
    {
        foreach (var file in e.GetMultipleFiles(e.FileCount))
        {
            await using var inputStream = file.OpenReadStream(int.MaxValue);
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

    private void DocumentPagesOnDocumentRemoved(int index)
    {
        _fileSources.RemoveAt(index);
    }

    private void DocumentPagesOnUpdate()
    {
        MutationService.RequestMergeUpdate();
    }
}