using Microsoft.AspNetCore.Components;

namespace PDFEdit.Components;

public partial class Checkbox
{
    [Parameter] public string Label { get; set; }
    [Parameter] public bool DefaultValue { get; set; } = false;
    [Parameter] public Action<bool> ValueChanged { get; set; }

    private bool _value = false;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _value = DefaultValue;
    }

    private void SetValue(ChangeEventArgs changeEventArgs)
    {
        _value = (bool)changeEventArgs.Value;
        ValueChanged(_value);
    }
}
