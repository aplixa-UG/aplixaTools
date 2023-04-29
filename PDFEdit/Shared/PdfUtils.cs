using iTextSharp.text;
using iTextSharp.text.pdf;
using PDFEdit.Extensions;

namespace PDFEdit.Shared;

public static class PdfUtils
{
    public static PdfFile MergePdfFiles(List<byte[]> inputPdfList, string name, Rectangle pageSize = null, bool landscapeAspectRatio = false)
    {
        pageSize = pageSize ?? PageSize.A4;
        
        if (landscapeAspectRatio)
        {
            pageSize = new Rectangle(pageSize.Height, pageSize.Width);
        }

        using var outputStream = new MemoryStream();

        // Create document and pdfReader objects.
        var document = new Document(pageSize);
        var readers = new List<PdfReader>();
        int totalPages = 0;


        // Create reader list for the input pdf files.
        foreach (var pdf in inputPdfList)
        {
            var pdfReader = new PdfReader(pdf);
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
        int currentPdfReaderPage = 1;

        // Iterate and process the reader list.
        foreach (var pdfReader in readers)
        {
            //Create page and add content.
            while (currentPdfReaderPage <= pdfReader.NumberOfPages)
            {
                document.NewPage();
                var rotation = pdfReader.GetPageRotation(currentPdfReaderPage);
                var size = pdfReader.GetPageSizeWithRotation(currentPdfReaderPage);
                var width = size.Width;
                var height = size.Height;

                // Scale the added Page to fit the Document
                var scaleX = document.PageSize.Width / width;
                var scaleY = document.PageSize.Height / height;

                // Choose by which factor to scale based on which makes the new Page appear larger
                scaleX = scaleY < scaleX ? scaleY : scaleX;
                scaleY = scaleY < scaleX ? scaleY : scaleX;

                // Center the new Page
                var transformX = (document.PageSize.Width - width * scaleX) / 2;
                var transformY = (document.PageSize.Height - height * scaleY) / 2;

                var transform = new PdfTransform
                {
                    ScaleX = scaleX,
                    ScaleY = scaleY,
                    TransformX = transformX,
                    TransformY = transformY
                };

                // Get the Page
                pdfImportedPage = writer.GetImportedPage(
                        pdfReader, currentPdfReaderPage);

                // Add the Page with the previously calculated Transform
                pageContentByte.AddTemplate(
                    pdfImportedPage,
                    transform
                );

                // Proceed through the pages
                currentPdfReaderPage++;
            }
            // Reset Page Counter
            currentPdfReaderPage = 1;
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

    public static PdfFile ExtractPages(byte[] inputFile, int startIndex, int endIndex, string name = "")
    {
        if (startIndex - endIndex == 0) {
            return new PdfFile()
            {
                Name = name,
                Content = new byte[0],
                PageCount = 0
            };
        }
        using var reader = new PdfReader(inputFile);
        using var outputStream = new MemoryStream();

        var outputByteArrays = new List<byte[]>();
        var document = new Document();
        var copy = new PdfCopy(document, outputStream);
        document.Open();

        for (int i = startIndex; i < endIndex; i++)
        {
            copy.AddPage(copy.GetImportedPage(reader, i + 1));
        }

        Console.WriteLine(reader.NumberOfPages);

        document.Close();

        return new PdfFile()
        {
            Name = name,
            Content = outputStream.ToArray(),
            PageCount = endIndex - startIndex
        };
    }
}
