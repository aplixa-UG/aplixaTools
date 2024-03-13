using Microsoft.AspNetCore.Components;

namespace AplixaTools.Shared.Components;

/// <summary>
/// A wrapper for the svg-code to display an icon defined in SvgIcons.razor
/// </summary>
public partial class Icon
{
    /// <summary>
    /// The ID of the icon (see Icons.cs)
    /// </summary>
    [Parameter] public string Href { get; set; }
    /// <summary>
    /// Classes to apply to the svg
    /// </summary>
    [Parameter] public string Class { get; set; }
}
