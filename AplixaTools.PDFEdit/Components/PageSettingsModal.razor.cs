using Microsoft.AspNetCore.Components;
using AplixaTools.PDFEdit.Shared;
using AplixaTools.Shared.Components;

namespace AplixaTools.PDFEdit.Components;

public partial class PageSettingsModal
{
    [Parameter] public EventCallback OnSaved { get; set; }

    public Modal Modal { get; set; }
    public Dropdown RotationDropdown { get; set; }

    public PdfRotation Rotation { get => (PdfRotation)_rotation; }

    private int _rotation = 0;

    private string[] _rotationOptions = new[]
    {
        "0\u00b0",
        "90\u00b0",
        "180\u00b0",
        "270\u00b0"
    };

    public void Show(PdfRotation rotation)
    {
        RotationDropdown.SelectedIndex = (int)rotation;
        _rotation = (int)rotation;
        Modal.Show();
    }

    public void Hide()
    {
        Modal.Hide();
    }

    public async Task OnSave()
    {
        Modal.Hide();
        await OnSaved.InvokeAsync();
    }

    private void RotationDropdownOnValueChanged(int newValue)
    {
        _rotation = newValue;
    }
}