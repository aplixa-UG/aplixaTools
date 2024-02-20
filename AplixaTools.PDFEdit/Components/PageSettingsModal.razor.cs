using Microsoft.AspNetCore.Components;
using AplixaTools.Shared.Components;
using AplixaTools.PDFEdit.Models;

namespace AplixaTools.PDFEdit.Components;

public partial class PageSettingsModal
{
    /// <summary>
    /// Fires when the user saves their selected settings.
    /// </summary>
    [Parameter] public EventCallback OnSaved { get; set; }

    public Modal Modal { get; set; }
    public Dropdown RotationDropdown { get; set; }

    /// <summary>
    /// The selected rotation of the page
    /// </summary>
    public PdfRotation Rotation => (PdfRotation)_rotation;

    private int _rotation;

    private readonly string[] _rotationOptions = {
        "0\u00b0",
        "90\u00b0",
        "180\u00b0",
        "270\u00b0"
    };

    public void Show(PdfRotation rotation)
    {
        RotationDropdown.SelectedIndex = (int)rotation;
        _rotation = (int)rotation;
        StateHasChanged();
        Modal.Show();
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