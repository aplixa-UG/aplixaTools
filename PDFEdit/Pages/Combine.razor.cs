using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PDFEdit.Components;
using PDFEdit.Shared;

namespace PDFEdit.Pages;

[Route(Routes.CombineTool)]
public partial class Combine
{
    private List<PdfFile> fileSources = new();
    private const int maxAllowedFiles = int.MaxValue;
    private string ErrorMessage;

    async Task OnChange(InputFileChangeEventArgs e)
    {
        ErrorMessage = string.Empty;
        if (e.FileCount > maxAllowedFiles)
        {
            ErrorMessage = $"Only {maxAllowedFiles} files can be uploaded";
            return;
        }
        foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
        {
            using var stream = file.OpenReadStream();
            var pdf = new Document();

            PdfWriter.GetInstance(pdf, stream);

            fileSources.Add(new PdfFile
            {
                Name = file.Name,
                Content = pdf,
            });
        }
        StateHasChanged();
    }
}
