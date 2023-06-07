namespace AplixaTools.PDFEdit.Models;

public class PdfTransformPageMutation : IPdfMutation
{
    public int DocumentIndex;
    public int PageIndex;
    public PdfTransform Transform;

    public PdfTransformPageMutation(int documentIndex, int pageIndex, PdfTransform transform)
    {
        DocumentIndex = documentIndex;
        PageIndex = pageIndex;
        Transform = transform;
    }

    public List<PdfFile> Mutate(List<PdfFile> inputFiles)
    {
        inputFiles[DocumentIndex] = inputFiles[DocumentIndex].TransformPage(PageIndex, Transform);
        return inputFiles;
    }

    public List<PreviewPage> MutatePreview(List<PreviewPage> inputFiles)
    {
        inputFiles[DocumentIndex].Transform = Transform;
        return inputFiles;
    }
}
