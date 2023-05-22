using AplixaTools.PDFEdit.Models;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using iText.Pdfa;
using System.IO;

namespace AplixaTools.PDFEdit.Shared;

public static class PdfUtils
{
    public static PdfFile MergePdfFiles(List<PdfFile> inputPdfList, string name = "")
    {
        // Set up streams for the PdfWriter to write to and for PDF/A to get its color profile
        using var outputStream = new MemoryStream();
        using var sRGBstream = new MemoryStream();

        sRGBstream.Write(ICCProfiles.sRGB_IEC61966_2_1, 0, ICCProfiles.sRGB_IEC61966_2_1.Length);
        sRGBstream.Position = 0;

		// Initialize PDF/A-3a Document with sRGB IEC61966-2.1: https://www.color.org/black_scaled_2009_srgb.xalter
		var pdf = new PdfADocument(
            new PdfWriter(outputStream),
            PdfAConformanceLevel.PDF_A_3A,
            new PdfOutputIntent("Custom", "", "https://www.color.org",
                "sRGB IEC61966-2.1", sRGBstream)
        );
        pdf.SetTagged();
        pdf.GetCatalog().SetLang(new PdfString("de-DE"));

        // Set up Merger
        var merger = new PdfMerger(pdf);

        // Loop through all source documents, write them to a Stream for a PdfWriter and add it to the Merger
        foreach (var sourcePdf in inputPdfList)
        {
            using var sourceStream = new MemoryStream();
            sourceStream.Write(sourcePdf.Content, 0, sourcePdf.Content.Length);
            sourceStream.Position = 0;

            var sourcePdfDoc = new PdfDocument(new PdfReader(sourceStream));
            merger.Merge(sourcePdfDoc, 1, sourcePdfDoc.GetNumberOfPages());
            sourcePdfDoc.Close();
        }

        // The /Interpolate Key must be false for PDF/A-3a and Dictionaries of type ExtGState mustn't have the key TR
        for (int i = 0; i < pdf.GetNumberOfPdfObjects(); i++)
        {
            var pdfObj = pdf.GetPdfObject(i + 1);
            if (pdfObj is { } && pdfObj.IsStream())
            {
                var stream = (PdfStream)pdfObj;

                if (stream.ContainsKey(PdfName.Interpolate))
                {
                    stream.Put(PdfName.Interpolate, new PdfBoolean(false));
                }
			}
            else if (pdfObj is { } && pdfObj.IsDictionary())
			{
				var dict = (PdfDictionary)pdfObj;

				if (dict.Get(PdfName.Type) is { } type && type.ToString() == "/ExtGState")
				{
					dict.Remove(PdfName.TR);
				}
			}
		}

        // Get the number of pages and close the document afterwards
        var numberOfPages = pdf.GetNumberOfPages();
        pdf.Close();

        return new PdfFile
        {
            Name = name,
            Content = outputStream.ToArray(),
            PageCount = numberOfPages
        };
    }
}
