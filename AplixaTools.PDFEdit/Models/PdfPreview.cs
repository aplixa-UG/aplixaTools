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
            PdfRotation.Deg0 => Rot0deg,
            PdfRotation.Deg90 => Rot90deg,
            PdfRotation.Deg180 => Rot180deg,
            PdfRotation.Deg270 => Rot270deg,
            _ => throw new NotImplementedException()
        };
    }
}
