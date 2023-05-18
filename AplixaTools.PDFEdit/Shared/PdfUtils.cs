using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using iText.Pdfa;
using System.IO;

namespace AplixaTools.PDFEdit.Shared;

public static class PdfUtils
{
    public static PdfFile MergePdfFiles(List<PdfFile> inputPdfList, string name = "")
    {
        using var outputStream = new MemoryStream();
        using var sRGBstream = new MemoryStream();

        sRGBstream.Write(ICCProfiles.sRGB_IEC61966_2_1, 0, ICCProfiles.sRGB_IEC61966_2_1.Length);
        sRGBstream.Position = 0;

        var pdf = new PdfADocument(
            new PdfWriter(outputStream),
            PdfAConformanceLevel.PDF_A_3A,
            new PdfOutputIntent("Custom", "", "https://www.color.org",
                "sRGB IEC61966-2.1", sRGBstream)
        );
        pdf.SetTagged();
        pdf.GetCatalog().SetLang(new PdfString("de-DE"));

        var merger = new PdfMerger(pdf);

        foreach (var sourcePdf in inputPdfList)
        {
            using var sourceStream = new MemoryStream();
            sourceStream.Write(sourcePdf.Content, 0, sourcePdf.Content.Length);
            sourceStream.Position = 0;

            var sourcePdfDoc = new PdfDocument(new PdfReader(sourceStream));
            merger.Merge(sourcePdfDoc, 1, sourcePdfDoc.GetNumberOfPages());
            sourcePdfDoc.Close();
        }

        // The /Interpolate Key must be false for PDF/A-3a
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

				if (stream.ContainsKey(PdfName.FontFamily))
				{
					Console.WriteLine(stream.Get(PdfName.FontFamily)?.ToString());
				}
			}
            else if (pdfObj is { } && pdfObj.IsDictionary())
			{
				var dict = (PdfDictionary)pdfObj;

                if (dict.ContainsKey(PdfName.FontFamily))
                {
                    Console.WriteLine(dict.Get(PdfName.FontFamily)?.ToString());
                }

				if (dict.Get(PdfName.Type) is { } type && type.ToString() == "/ExtGState")
				{
					dict.Remove(PdfName.TR);
				}
			}
		}

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
