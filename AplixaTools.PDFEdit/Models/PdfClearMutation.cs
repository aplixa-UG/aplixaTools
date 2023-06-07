namespace AplixaTools.PDFEdit.Models;

public class PdfClearMutation : IPdfMutation
{
    public List<PdfFile> Mutate(List<PdfFile> _)
    {
        return new();
    }

    public List<PreviewPage> MutatePreview(List<PreviewPage> _)
    {
        return new();
    }
}
