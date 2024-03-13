using AplixaTools.PDFEdit.Services;
using Microsoft.AspNetCore.Components;

namespace AplixaTools.PDFEdit.Models;

public class PdfRearrangementMutation : IPdfMutation
{
    [Inject] public JsInteropService JsInterop { get; set; }

    public int[] Arrangement;

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
                    Preview = file.Preview,
                    Rotation = file.Rotation,
					Size = file.Size
				};

                actualIndex++;
                return newFile;
            })
            .ToList();
        return outputFiles;
    }
}
