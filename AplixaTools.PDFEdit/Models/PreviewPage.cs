namespace AplixaTools.PDFEdit.Models;

/// <summary>
/// The Base64 encoded JPEG preview of a PDF page and it's index
/// </summary>
public class PreviewPage
{
    public int Index = -1;
    public string Image = "";
    public PdfTransform Transform = new();
}