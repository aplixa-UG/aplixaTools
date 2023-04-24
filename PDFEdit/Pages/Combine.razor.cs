using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PDFEdit.Services;
using PDFEdit.Shared;
using PDFEdit.Extensions;

namespace PDFEdit.Pages;

[Route(Routes.CombineTool)]
public partial class Combine
{
    private List<PdfFile> fileSources = new();
    private string ErrorMessage;

    private async Task OnChange(InputFileChangeEventArgs e)
    {
        ErrorMessage = string.Empty;
        foreach (var file in e.GetMultipleFiles(e.FileCount))
        {
            using var stream = file.OpenReadStream(int.MaxValue);

            var bytes = new byte[file.Size];

            await stream.ReadAsync(bytes);

            var reader = new PdfReader(bytes);

            fileSources.Add(new PdfFile
            {
                Name = file.Name,
                PageCount = reader.NumberOfPages,
                Content = bytes
            });
        }
        StateHasChanged();
    }
}
