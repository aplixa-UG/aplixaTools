using iText.Kernel.Pdf;
using iText.Layout.Properties;
using System.Collections.Generic;

namespace AplixaTools.PDFEdit.Shared;

public class PdfFile
{
    public string Name { get; set; }
    public int PageCount { get; set; }
    public byte[] Content { get; set; }

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

    public PdfFile TransformPage(int pageIndex, PdfTransform transform)
    {
        using var outputStream = new MemoryStream();
        using var inputStream = new MemoryStream();

        inputStream.Write(Content, 0, Content.Length);
        inputStream.Position = 0;

        var doc = new PdfDocument(new PdfReader(inputStream), new PdfWriter(outputStream));

        var page = doc.GetPage(pageIndex + 1);
        page.SetRotation((int)transform.Angle * 90);

        return new PdfFile
        {
            Name = Name,
            PageCount = PageCount,
            Content = outputStream.ToArray(),
        };
    }

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

    public List<string> GetFontsUsed()
    {
        var fonts = new List<string>();

        using var inputStream = new MemoryStream();

        inputStream.Write(Content, 0, Content.Length);
        inputStream.Position = 0;

        var doc = new PdfDocument(new PdfReader(inputStream));

		PdfDictionary resources;
		for (int k = 1; k <= doc.GetNumberOfPages(); ++k)
		{
			
			GetFontsUsed(fonts, resources);
		}

		doc.Close(); 
        return fonts;
    }

	public void GetFontsUsed(List<string> set, PdfDictionary resource)
	{
		if (resource == null)
			return;
		PdfDictionary xobjects = resource.GetAsDictionary(PdfName.XObject);
		if (xobjects != null)
		{
			foreach (var key in xobjects.KeySet())
			{
				GetFontsUsed(set, xobjects.GetAsDictionary(key));
			}
		}
		PdfDictionary fonts = resource.GetAsDictionary(PdfName.Font);
		if (fonts == null)
			return;
		PdfDictionary font;
		foreach (var key in fonts.KeySet())
		{
			font = fonts.GetAsDictionary(key);
			String name = font.GetAsName(PdfName.BaseFont).toString();
			if (name.Length > 8 && name[7] == '+')
			{
                name = $"{name.Substring(8)} subset ({name.Substring(1, 7)})";
			}
			else
			{
				name = name.Substring(1);
				PdfDictionary desc = font.GetAsDictionary(PdfName.FontDescriptor);
				if (desc == null)
					name += " nofontdescriptor";
				else if (desc.Get(PdfName.FontFile) != null)
					name += " (Type 1) embedded";
				else if (desc.Get(PdfName.FontFile2) != null)
					name += " (TrueType) embedded";
				else if (desc.Get(PdfName.FontFile3) != null)
					name += " (" + font.GetAsName(PdfName.Subtype).ToString().Substring(1) + ") embedded";
			}
			set.Add(name);
		}
	}
}
