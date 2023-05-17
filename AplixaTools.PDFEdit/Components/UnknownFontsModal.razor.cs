using Microsoft.AspNetCore.Components;
using AplixaTools.PDFEdit.Shared;
using AplixaTools.Shared.Components;

namespace AplixaTools.PDFEdit.Components;

public partial class UnknownFontsModal
{
    [Parameter] public IEnumerable<string> Fonts { get; set; }
    [Parameter] public EventCallback<IEnumerable<Font>> OnSaved { get; set; }
}