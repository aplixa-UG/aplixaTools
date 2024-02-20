using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace AplixaTools.Shared.Components;

public partial class RangeInput
{
    [Parameter] public string Class { get; set; } = "";
    [Parameter] public double Min { get; set; }
    [Parameter] public double Max { get; set; } = 1.0;
    [Parameter] public double Step { get; set; } = .1;
    [Parameter] public EventCallback<double> OnValueChanged { get; set; }


    public async Task OnChange(ChangeEventArgs args)
    {
        var value = double.Parse((string)args.Value ?? string.Empty, CultureInfo.InvariantCulture);
        await OnValueChanged.InvokeAsync(value);
    }
}
