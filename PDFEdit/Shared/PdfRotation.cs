namespace PDFEdit.Shared;

public enum PdfRotation
{
    deg0,
    deg90,
    deg180,
    deg270,
}

public static class PdfRotationExtensions
{
    public static float ToFloat(this PdfRotation rot)
    {
        return rot switch
        {
            PdfRotation.deg0 => 0,
            PdfRotation.deg90 => 90,
            PdfRotation.deg180 => 180,
            PdfRotation.deg270 => 270,
            _ => throw new ArgumentException()
        };
    }
}
