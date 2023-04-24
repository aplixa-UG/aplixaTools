using iTextSharp.text;

namespace PDFEdit.Shared;

public class PdfFile
{
    public string Name { get; set; }
    public int PageCount { get; set; }
    public byte[] Content { get; set; }
}
