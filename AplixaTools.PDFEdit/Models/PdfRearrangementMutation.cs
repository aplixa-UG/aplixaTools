namespace AplixaTools.PDFEdit.Models;

public class PdfRearrangementMutation : IPdfMutation
{
    public int[] Arrangement = Array.Empty<int>();

    public PdfRearrangementMutation(int[] arrangement)
    {
        Arrangement = arrangement;
    }

    public List<PdfFile> Mutate(List<PdfFile> inputFiles)
    {
        return Arrangement.Select(i => inputFiles[i]).ToList();
    }

    public List<PreviewPage> MutatePreview(List<PreviewPage> inputFiles)
    {
        var actualIndex = 0;
        var outputFiles = Arrangement
            .Select(i => {
                var file = inputFiles[i];
                var newFile = new PreviewPage
                {
                    Index = actualIndex,
                    Image = file.Image,
                    Transform = file.Transform
                };

                actualIndex++;
                return newFile;
            })
            .ToList();
        return outputFiles;
    }
}
