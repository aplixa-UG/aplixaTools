namespace AplixaTools.PDFEdit.Models;

/// <summary>
/// A wrapper for transformations of a PDF document
/// </summary>
public class PdfTransform
{
    public PdfRotation Angle { get; set; } = PdfRotation.Deg0;
}
