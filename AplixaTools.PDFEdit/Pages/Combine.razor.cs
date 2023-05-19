using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using AplixaTools.PDFEdit.Components;
using AplixaTools.PDFEdit.Services;
using AplixaTools.PDFEdit.Shared;
using AplixaTools.Shared.Components;
using iText.Kernel.Pdf;

namespace AplixaTools.PDFEdit.Pages;

[Route(Routes.CombineTool)]
public partial class Combine : IDisposable
{
    [Inject] public JsInteropService JsInterop { get; set; }

    public Modal ConfirmClearModal { get; set; }
    public PageSettingsModal PageSettingsModal { get; set; }
    public OutputPages OutputPages { get; set; }
    public InputPages InputPages { get; set; }

    private PdfFile _outputDocument;

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            JsInterop.Startup();
            StateHasChanged();
        }
        base.OnAfterRender(firstRender);
    }

    private async Task ConfirmClearOnClick()
    {
        OutputPages.StartLoading();
        InputPages.InputDocuments.Clear();
        ConfirmClearModal.Hide();
        await OutputPages.UpdateMerge();
    }

    private async Task PageSettingsOnSave()
    {
        OutputPages.StartLoading();
        InputPages.InputDocuments[OutputPages.SelectedPage] = InputPages.InputDocuments[OutputPages.SelectedPage].TransformPage(0, new PdfTransform
        {
            Angle = PageSettingsModal.Rotation,
        });
        await OutputPages.UpdateMerge();
    }

    private async Task UpdateMerge()
    {
        if (OutputPages is not {})
        {
            return;
        }
        OutputPages.StartLoading();
        StateHasChanged();

        await OutputPages.UpdateMerge();
        StateHasChanged();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        OutputPages.Dispose();
    }
}
