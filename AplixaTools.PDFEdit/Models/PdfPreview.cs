namespace AplixaTools.PDFEdit.Models;

public class PdfPreview
{
    public string Rot0deg { get; set; }
    public string Rot90deg { get; set; }
    public string Rot180deg { get; set; }
    public string Rot270deg { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }

    public string GetFromRotation(PdfRotation rot)
    {
        Console.WriteLine(rot);
        return rot switch
        {
            PdfRotation.deg0 => Rot0deg,
            PdfRotation.deg90 => Rot90deg,
            PdfRotation.deg180 => Rot180deg,
            PdfRotation.deg270 => Rot270deg,
            _ => throw new NotImplementedException()
        };
    }
}
