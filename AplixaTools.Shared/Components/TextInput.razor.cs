using Microsoft.AspNetCore.Components;

namespace AplixaTools.Shared.Components;

public partial class TextInput : ComponentBase
{
	/// <summary>
	/// The classes to apply to the input
	/// </summary>
	[Parameter] public string Class { get; set; }
	/// <summary>
	/// The faint text that is displayed when the Textbox is empty
	/// </summary>
	[Parameter] public string Placeholder { get; set; }
    /// <summary>
    /// The default content of the Textbox
    /// </summary>
    [Parameter] public string DefaultValue { get; set; } = "";
    /// <summary>
    /// Fires when the user exits the Textbox
    /// </summary>
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
