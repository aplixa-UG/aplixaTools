using Microsoft.AspNetCore.Components;

namespace AplixaTools.Shared.Components;

public partial class Checkbox : ComponentBase
{
    [Parameter] public string Label { get; set; }
    [Parameter] public bool DefaultValue { get; set; } = false;
    [Parameter] public EventCallback<bool> ValueChanged { get; set; }

    private bool _value = false;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _value = DefaultValue;
    }

    private async Task SetValue(ChangeEventArgs changeEventArgs)
    {
        _value = (bool)changeEventArgs.Value;
        await ValueChanged.InvokeAsync(_value);
    }
}
