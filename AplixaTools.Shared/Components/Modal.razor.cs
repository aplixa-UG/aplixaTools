using Microsoft.AspNetCore.Components;
using AplixaTools.Shared.Services;

namespace AplixaTools.Shared.Components;

/// <summary>
/// A Bootstrap Dialog/Modal box
/// </summary>
public partial class Modal
{
    [Inject] public DefaultJsInteropService JsInterop { get; set; }

    /// <summary>
    /// The title of the Modal
    /// </summary>
    [Parameter] public string Title { get; set; }
    /// <summary>
    /// The content of the Modal
    /// </summary>
    [Parameter] public RenderFragment Content { get; set; }
    /// <summary>
    /// The footer (buttons) of the Modal
    /// </summary>
    [Parameter] public RenderFragment Footer { get; set; }
    /// <summary>
    /// Defines if the Modal is dismissable via a close button in the top right
    /// </summary>
    [Parameter] public bool Closeable { get; set; } = true;
    /// <summary>
    /// Defines if the Modal is closable by clicking outside of the Modal
    /// </summary>
    [Parameter] public bool Static { get; set; } = true;

    public void Show()
    {
        JsInterop.ShowModal($"#modal-{this.GetHashCode()}");
    }

    public void Hide()
    {
        JsInterop.HideModal($"#modal-{this.GetHashCode()}");
    }
}