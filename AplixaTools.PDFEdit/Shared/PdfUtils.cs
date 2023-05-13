using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AplixaTools.PDFEdit.Shared;

public static class PdfUtils
{
    public static PdfFile MergePdfFiles(List<PdfFile> inputPdfList, string name)
    {
        using var outputStream = new MemoryStream();

        // Create document and pdfReader objects.
        var document = new Document();
        var readers = new List<PdfReader>();
        int totalPages = 0;


        // Create reader list for the input pdf files.
        foreach (var pdf in inputPdfList)
        {
            var pdfReader = new PdfReader(pdf.Content);
            readers.Add(pdfReader);
            totalPages = totalPages + pdfReader.NumberOfPages;
        }

        // Create writer for the outputStream
        PdfWriter writer = PdfWriter.GetInstance(document, outputStream);

        // Open document.
        document.Open();

        // Contain the pdf data.
        PdfContentByte pageContentByte = writer.DirectContent;

        PdfImportedPage pdfImportedPage;

        // Iterate and process the reader list.
        for (int i = 0; i < readers.Count; i++)
        {
            var pdfReader = readers[i];
            var pageInfo = inputPdfList[i];

            //Create page and add content.
            for (int j = 0; j < pdfReader.NumberOfPages; j++)
            {
                var pageSize = pdfReader.GetPageSizeWithRotation(j + 1);
                document.SetPageSize(pageSize);
                document.NewPage();

                // Get the Page
                pdfImportedPage = writer.GetImportedPage(
                    pdfReader, j + 1);

                // Depending on the rotation, different transforms have to be applied
                var rotation = pdfReader.GetPageRotation(j + 1);
                switch (rotation)
                {
                    case 0:
                        pageContentByte.AddTemplate(pdfImportedPage, 1f, 0, 0, 1f, 0, 0);
                        break;

                    case 90:
                        pageContentByte.AddTemplate(pdfImportedPage, 0, -1f, 1f, 0, 0, pageSize.Height);
                        break;

                    case 180:
                        pageContentByte.AddTemplate(pdfImportedPage, -1f, 0, 0, -1f, pageSize.Width, pageSize.Height);
                        break;

                    case 270:
                        pageContentByte.AddTemplate(pdfImportedPage, 0, 1f, -1f, 0, pageSize.Width, 0);
                        break;

                    default:
                        throw new InvalidOperationException($"Unexpected page rotation: {rotation}\u00b0.");
                }
            }
        }

        // Close document
        document.Close();
        outputStream.Close();

        return new PdfFile
        {
            Name = name,
            Content = outputStream.ToArray(),
            PageCount = totalPages
        };
    }

    public static PdfFile ExtractPages(PdfFile inputFile, int startIndex, int endIndex, string name = "")
    {
        if (startIndex - endIndex == 0)
        {
            return new PdfFile
            {
                Name = name,
                Content = new byte[0],
                PageCount = 0
            };
        }
        using var reader = new PdfReader(inputFile.Content);
        using var outputStream = new MemoryStream();

        var outputByteArrays = new List<byte[]>();
        var document = new Document();
        var copy = new PdfCopy(document, outputStream);
        document.Open();

        for (int i = startIndex; i < endIndex; i++)
        {
            var page = copy.GetImportedPage(reader, i + 1);
            var size = reader.GetPageSizeWithRotation(i + 1);
            copy.AddPage(page);
        }

        document.Close();

        return new PdfFile
        {
            Name = name,
            Content = outputStream.ToArray(),
            PageCount = endIndex - startIndex
        };
    }

    public static PdfFile TransformPage(PdfFile inputPdf, int pageIndex, PdfTransform transform)
    {
        using var stream = new MemoryStream();
        using var reader = new PdfReader(inputPdf.Content);

        var page = reader.GetPageN(pageIndex + 1);
        page.Put(PdfName.Rotate, new PdfNumber(transform.Angle.ToFloat()));

        var stamper = new PdfStamper(reader, stream);
        stamper.Close();

        return new PdfFile
        {
            Name = inputPdf.Name,
            PageCount = inputPdf.PageCount,
            Content = stream.ToArray(),
        };
    }

    public static PdfTransform GetPageTransform(PdfFile inputPdf, int pageIndex)
    {
        using var reader = new PdfReader(inputPdf.Content);

        var page = reader.GetPageN(pageIndex + 1);
        var rotation = 0f;

        if (page.GetAsNumber(PdfName.Rotate) is { } r)
        {
            rotation = r.FloatValue;
        }

        var rotationIndex = rotation / 90;

        var angle = rotation % 90 == 0 && rotationIndex < 4
            ? (PdfRotation) rotationIndex
            : PdfRotation.deg0
            ;

        return new PdfTransform
        {
            Angle = angle
        };
    }
}
