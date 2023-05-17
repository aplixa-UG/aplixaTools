using iText.Kernel.Font;

namespace AplixaTools.PDFEdit.Shared;

public class Font
{
	public string Name { get; set; }
	public byte[] Data { get; set; }
	
	public PdfFont ToPdfFont()
	{
		return PdfFontFactory.CreateFont(Data, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);	
	}
}
