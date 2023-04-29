using Microsoft.AspNetCore.Components;
using PDFEdit.Services;

namespace PDFEdit.Components;

public partial class Modal {
    [Inject] public JsInteropService JsInterop { get; set; }
    
    [Parameter] public string Title { get; set; }
    [Parameter] public RenderFragment Content { get; set; }
    [Parameter] public RenderFragment Footer { get; set; }
    [Parameter] public bool Closeable { get; set; } = true;
    [Parameter] public bool Static { get; set; } =  true;

    public void Show() {
        JsInterop.ShowModal($"#modal-{this.GetHashCode()}");
    }

    public void Hide() {
        JsInterop.HideModal($"#modal-{this.GetHashCode()}");
    }
}