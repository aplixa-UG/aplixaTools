namespace AplixaTools.PDFEdit.Models;

public class PdfRemovePageMutation : IPdfMutation
{
    public int PageIndex;

    public PdfRemovePageMutation(int pageIndex)
    {
        PageIndex = pageIndex;
    }

    public List<PdfFile> Mutate(List<PdfFile> inputFiles)
    {
        inputFiles.RemoveAt(PageIndex);
        return inputFiles;
    }

    public List<PreviewPage> MutatePreview(List<PreviewPage> inputFiles)
    {
        var actualIndex = 0;
        var outputFiles = new List<PreviewPage>();
        for (var i = 0; i < inputFiles.Count; i++)
        {
            if (i == PageIndex)
            {
                continue;
            }

            var file = inputFiles[i];
            file.Index = actualIndex;
            outputFiles.Add(file);
            actualIndex++;
        }
        return outputFiles;
    }
}
