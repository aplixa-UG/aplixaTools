using iTextSharp.text;
using iTextSharp.text.pdf;
using PDFEdit.Extensions;

namespace PDFEdit.Shared;

public static class PdfUtils
{
    public static PdfFile MergePdfFiles(List<PdfFile> inputPdfList, string name, bool landscapeAspectRatio = false)
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

        var pageSizes = new List<Rectangle>();
        var pageTransforms = new List<PdfTransform>();

        // Iterate and process the reader list.
        for (int i = 0; i < readers.Count; i++)
        {
            var pdfReader = readers[i];
            var pageInfo = inputPdfList[i];

            //Create page and add content.
            for (int j = 0; j < pdfReader.NumberOfPages; j++)
            {
                var pageTransform = pageInfo.PageTransforms[j];
                document.SetPageSize(pageInfo.PageSizes[j]);
                pageSizes.Add(pageInfo.PageSizes[j]);
                pageTransforms.Add(pageTransform);
                document.NewPage();

                // Get the Page
                pdfImportedPage = writer.GetImportedPage(
                        pdfReader, j + 1);
                
                // Add the Page with the previously calculated Transform
                pageContentByte.AddTemplate(pdfImportedPage, pageTransform);
            }
       }

        // Close document
        document.Close();
        outputStream.Close();

        return new PdfFile
        {
            Name = name,
            Content = outputStream.ToArray(),
            PageSizes = pageSizes.ToArray(),
            PageTransforms = pageTransforms.ToArray(),
            PageCount = totalPages
        };
    }

    public static PdfFile ExtractPages(PdfFile inputFile, int startIndex, int endIndex, string name = "")
    {
        if (startIndex - endIndex == 0) {
            return new PdfFile
            {
                Name = name,
                Content = new byte[0],
                PageSizes = new Rectangle[0],
                PageTransforms = new PdfTransform[0],
                PageCount = 0
            };
        }
        using var reader = new PdfReader(inputFile.Content);
        using var outputStream = new MemoryStream();

        var outputByteArrays = new List<byte[]>();
        var document = new Document();
        var copy = new PdfCopy(document, outputStream);
        document.Open();

        var pageSizes = new List<Rectangle>();
        var pageTransforms = new List<PdfTransform>();

        for (int i = startIndex; i < endIndex; i++)
        {
            var page = copy.GetImportedPage(reader, i + 1);
            var size = reader.GetPageSize(i + 1);
            pageSizes.Add(size);
            pageTransforms.Add(inputFile.PageTransforms[i]);
            copy.AddPage(page);
        }

        document.Close();

        return new PdfFile
        {
            Name = name,
            Content = outputStream.ToArray(),
            PageSizes = pageSizes.ToArray(),
            PageTransforms = pageTransforms.ToArray(),
            PageCount = endIndex - startIndex
        };
    }

    public static PdfFile TransformPage(PdfFile inputPdf, int pageIndex, PdfTransform transform)
    {
        using var outputStream = new MemoryStream();

        var reader = new PdfReader(inputPdf.Content);
        var pageSizes = new List<Rectangle>();
        var pageTransforms = inputPdf.PageTransforms;

        for (int p = 1; p <= reader.NumberOfPages; p++) {
            var page = reader.GetPageN(p);
            var rotate = page.GetAsNumber(PdfName.Rotate);
            if (rotate == null) {
                page.Put(PdfName.Rotate, new PdfNumber(90));
                pageTransforms[p - 1].Angle = 90;
            }
            else {
                page.Put(PdfName.Rotate, new PdfNumber((rotate.IntValue + 90) % 360));
                pageTransforms[p - 1].Angle = (rotate.IntValue + 90) % 360;
            }
            pageSizes.Add(reader.GetPageSizeWithRotation(p));
        }
        PdfStamper stamper = new PdfStamper(reader, outputStream);
        stamper.Close();
        reader.Close();

        return new PdfFile
        {
            Name = inputPdf.Name,
            PageCount = inputPdf.PageCount,
            PageSizes = pageSizes.ToArray(),
            PageTransforms = pageTransforms,
            Content = outputStream.ToArray()
        };
    }
}
