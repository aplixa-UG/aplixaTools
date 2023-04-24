using iTextSharp.text;

namespace PDFEdit.Extensions;

public static class DocumentExtensions {
    public static byte[] GetBytes(this Document document) {
        using var ms = new System.IO.MemoryStream();
        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms);
        return ms.ToArray();
    }
}