using Microsoft.AspNetCore.Components;

namespace PDFEdit.Components;

public partial class PageSettingsModal
{
    [Parameter] public EventCallback OnSaved { get; set; }

    public Modal _modal { get; set; }

    public void Show() {
        _modal.Show();
    }

    public void Hide() {
        _modal.Hide();
    }

    public async Task OnSave() {
        _modal.Hide();
        await OnSaved.InvokeAsync();
    }    
}