using AplixaTools.PDFEdit.Models;
using AplixaTools.PDFEdit.Services;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AplixaTools.PDFEdit.Components;

public partial class InputPages {
    [Inject] public PdfMutationQueueService MutationService { get; set; }

    [Parameter] public EventCallback UpdateMerge { get; set; }
    
    private bool _dragging = false;
    private readonly List<PdfFile> _fileSources = new();
    private readonly List<DocumentPages> _documentPages = new();
    DocumentPages DocumentPagesRef
    {
        set { _documentPages.Add(value); }
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

    private void DocumentPagesOnDocumentRemoved(int index)
    {
        _fileSources.RemoveAt(index);
    }

    private async Task DocumentPagesOnUpdate()
    {
        await UpdateMerge.InvokeAsync();
    }
}