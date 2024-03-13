using Microsoft.AspNetCore.Components;
using AplixaTools.PDFEdit.Components;
using AplixaTools.PDFEdit.Services;
using AplixaTools.PDFEdit.Shared;
using AplixaTools.Shared.Components;
using AplixaTools.PDFEdit.Models;

namespace AplixaTools.PDFEdit.Pages;

[Route(Routes.CombineTool)]
public partial class Combine : IDisposable
{
    [Inject] public PdfMutationQueueService MutationService { get; set; }
    [Inject] public JsInteropService JsInterop { get; set; }

    public Modal ConfirmClearModal { get; set; }
    public PageSettingsModal PageSettingsModal { get; set; }
    public OutputPages OutputPages { get; set; }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            JsInterop.Startup();
            StateHasChanged();
        }
        base.OnAfterRender(firstRender);
    }

    private async void ConfirmClearOnClick()
    {
        MutationService.RequestStartLoading();

        MutationService.QueueMutation(new PdfClearMutation());

        await ConfirmClearModal.Hide();
    }

    private void PageSettingsOnSave()
    {
        MutationService.RequestStartLoading();

        MutationService.QueueMutation(
            new PdfTransformPageMutation(
                OutputPages.SelectedPage,
                0,
                new PdfTransform
                {
                    Angle = PageSettingsModal.Rotation
                }
            )
        );
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        OutputPages.Dispose();
    }
}
