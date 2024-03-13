using Microsoft.AspNetCore.Components;

namespace AplixaTools.Shared.Components;

public partial class Dropdown : ComponentBase
{
    /// <summary>
    /// An enumerable collection of strings to  be shown in the dropdown
    /// </summary>
    [Parameter] public IEnumerable<string> Options { get; set; }
    /// <summary>
    /// The index in the "Options"-Collection of the default selection
    /// </summary>
    [Parameter] public int Default { get; set; }
    /// <summary>
    /// Fires when the user changed the selected option
    /// </summary>
    [Parameter] public EventCallback<int> OnValueChanged { get; set; }

    public int SelectedIndex = -1;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SelectedIndex = Default;
    }

    private async Task Select(int index)
    {
        SelectedIndex = index;
        StateHasChanged();
        await OnValueChanged.InvokeAsync(SelectedIndex);
    }
}
