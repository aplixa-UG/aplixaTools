using Microsoft.AspNetCore.Components;

namespace AplixaTools.Shared.Components;

public partial class Checkbox
{
    /// <summary>
    /// The content of the descriptive label next to the checkbox
    /// </summary>
    [Parameter] public string Label { get; set; }
    /// <summary>
    /// The default state of the checkbox (true = checked, false = unchecked)
    /// </summary>
    [Parameter] public bool DefaultValue { get; set; }
    /// <summary>
    /// Fires when the User interacted with the checkbox and changed it's state
    /// </summary>
    [Parameter] public EventCallback<bool> ValueChanged { get; set; }

    private bool _value;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _value = DefaultValue;
    }

    private async Task SetValue(ChangeEventArgs changeEventArgs)
    {
        if (changeEventArgs.Value is null) return;

        _value = (bool)changeEventArgs.Value;
        await ValueChanged.InvokeAsync(_value);
    }
}
