namespace AplixaTools.PDFEdit.Models;

/// <summary>
/// The Base64 encoded JPEG preview of a PDF pagel, it's index and other Information
/// </summary>
public class PreviewPage
{
    public int Index { get; set; } = -1;
    public PdfPreview Preview { get; set; }
    public Pos2 Size { get; set; }
    public PdfRotation Rotation { get; set; }
}