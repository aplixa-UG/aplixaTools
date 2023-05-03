using Microsoft.AspNetCore.Components;

namespace PDFEdit.Components;

public partial class Dropdown
{
    [Parameter] public IEnumerable<string> Options { get; set; }
    [Parameter] public int Default { get; set; } = 0;
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

    public void Reset()
    {
        SelectedIndex = 0;
        StateHasChanged();
    }
}
