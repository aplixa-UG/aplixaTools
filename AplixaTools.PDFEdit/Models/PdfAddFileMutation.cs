namespace AplixaTools.PDFEdit.Models;

public class PdfAddFileMutation : IPdfMutation
{
    public PdfFile File;
    public PreviewPage PreviewPage;

    public PdfAddFileMutation(PdfFile file, PreviewPage previewPage)
    {
        File = file;
        PreviewPage = previewPage;
    }

    public List<PdfFile> Mutate(List<PdfFile> inputFiles)
    {
        inputFiles.Add(File);
        return inputFiles;
    }

    public List<PreviewPage> MutatePreview(List<PreviewPage> inputFiles)
    {
        PreviewPage.Index = inputFiles.Count;
        inputFiles.Add(PreviewPage);
        return inputFiles;
    }
}
