namespace AplixaTools.PDFEdit.Models;

public interface IPdfMutation
{
    public List<PdfFile> Mutate(List<PdfFile> inputFiles);

    public List<PreviewPage> MutatePreview(List<PreviewPage> inputFiles);
}
