using Microsoft.AspNetCore.Components;

namespace PDFEdit.Components;

public partial class Icon
{
    [Parameter] public string Href { get; set; }
    [Parameter] public string Class { get; set; }
}
