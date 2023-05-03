using iTextSharp.text;

namespace PDFEdit.Shared;

public class PdfFile
{
    public string Name { get; set; }
    public int PageCount { get; set; }
    public Rectangle[] PageSizes { get; set; }
    public PdfTransform[] PageTransforms { get; set; }
    public byte[] Content { get; set; }
}
