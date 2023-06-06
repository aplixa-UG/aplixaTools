using iText.Kernel.Pdf;

namespace AplixaTools.PDFEdit.Models;

public class PdfFile
{
    /// <summary>
    /// (Optional) The name of the PDF File (e.g. "merge.pdf")
    /// </summary>
    public string Name { get; set; }
    public int PageCount { get; set; }
    public byte[] Content { get; set; }

	/// <summary>
	/// Extracts pages from a PdfFile and puts them into a new PdfFile
	/// </summary>
	/// <param name="startIndex">The first element to extract (0-based index, included)</param>
	/// <param name="endIndex">The last element to extract (0-based index, excluded)</param>
	/// <param name="name">(Optional) The name of the resulting file</param>
	/// <returns></returns>
	public PdfFile ExtractPages(int startIndex, int endIndex, string name = "")
    {
        if (startIndex - endIndex == 0)
        {
            return new PdfFile
            {
                Name = name,
                Content = Array.Empty<byte>(),
                PageCount = 0
            };
        }

        using var outputStream = new MemoryStream();
        using var inputStream = new MemoryStream();

        inputStream.Write(Content, 0, Content.Length);
        inputStream.Position = 0;

        var inputDoc = new PdfDocument(new PdfReader(inputStream));
        var outputDoc = new PdfDocument(new PdfWriter(outputStream));

        for (int i = startIndex; i < endIndex; i++)
        {
            var newPage = inputDoc.GetPage(i + 1).CopyTo(outputDoc);
            outputDoc.AddPage(newPage);
        }

        inputDoc.Close();
        outputDoc.Close();

        return new PdfFile
        {
            Name = name,
            Content = outputStream.ToArray(),
            PageCount = endIndex - startIndex
        };
    }

    /// <summary>
    /// Transforms (= Rotates) a page in the PdfDocument
    /// </summary>
    /// <param name="pageIndex">0-based index of the page on which the transformation should be applied</param>
    /// <param name="transform">The transformation to apply</param>
    /// <returns></returns>
    public PdfFile TransformPage(int pageIndex, PdfTransform transform)
    {
        using var outputStream = new MemoryStream();
        using var inputStream = new MemoryStream();

        inputStream.Write(Content, 0, Content.Length);
        inputStream.Position = 0;

        var doc = new PdfDocument(new PdfReader(inputStream), new PdfWriter(outputStream));

        var page = doc.GetPage(pageIndex + 1);
        page.SetRotation((int)transform.Angle * 90);

        doc.Close();

        return new PdfFile
        {
            Name = Name,
            PageCount = PageCount,
            Content = outputStream.ToArray(),
        };
    }

    /// <summary>
    /// Gets the current transformation of a page in the PdfFile
    /// </summary>
    /// <param name="pageIndex">0-based index of the page of which the transform should be read</param>
    /// <returns></returns>
    public PdfTransform GetPageTransform(int pageIndex)
    {
        using var inputStream = new MemoryStream();

        inputStream.Write(Content, 0, Content.Length);
        inputStream.Position = 0;

        var doc = new PdfDocument(new PdfReader(inputStream));

        var page = doc.GetPage(pageIndex + 1);

        var rotation = page.GetRotation();

        var rotationIndex = rotation / 90;

        var angle = rotation % 90 == 0 && rotationIndex < 4
            ? (PdfRotation)rotationIndex
            : PdfRotation.deg0
            ;

        return new PdfTransform
        {
            Angle = angle
        };
    }
}
