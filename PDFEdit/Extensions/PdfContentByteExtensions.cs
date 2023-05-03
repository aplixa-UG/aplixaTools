using iTextSharp.text.pdf;
using PDFEdit.Shared;

namespace PDFEdit.Extensions;

public static class PdfContentByteExtensions
{
    public static void AddTemplate(this PdfContentByte pdfContentByte, PdfTemplate template, PdfTransform transform)
    {
        // Explanation: https://stackoverflow.com/questions/45930261
        var cosAngle = (float)Math.Cos(transform.Angle.ToFloat());
        var sinAngle = (float)Math.Sin(transform.Angle.ToFloat());
        var a = transform.ScaleX * cosAngle;
        var b = transform.ScaleY * sinAngle;
        var c = transform.ScaleX * -sinAngle;
        var d = transform.ScaleY * cosAngle;
        var e = transform.TransformX;
        var f = transform.TransformY;

        pdfContentByte.AddTemplate(template, a, b, c, d, e, f);
    }
}
