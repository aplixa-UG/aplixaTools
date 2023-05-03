namespace PDFEdit.Shared;

public class PdfTransform
{
    public float TransformX { get; set; } = 0;
    public float TransformY { get; set; } = 0;
    public float ScaleX { get; set; } = 1;
    public float ScaleY { get; set; } = 1;
    public PdfRotation Angle { get; set; } = PdfRotation.deg0;
}
