using Microsoft.AspNetCore.Components;

namespace PDFEdit.Components;

public partial class TextInput
{
    [Parameter] public string Placeholder { get; set; }
    [Parameter] public string DefaultValue { get; set; } = "";
    [Parameter] public EventCallback<string> ValueChanged { get; set; }

    private string _value = "";

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _value = DefaultValue;
    }

    private async Task SetValue(ChangeEventArgs changeEventArgs)
    {
        _value = (string)changeEventArgs.Value;
        await ValueChanged.InvokeAsync(_value);
    }
}
