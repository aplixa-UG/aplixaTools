using iTextSharp.text;

namespace PDFEdit.Shared;

public class PdfFile
{
    public string Name { get; set; }
    public Document Content { get; set; }
}
