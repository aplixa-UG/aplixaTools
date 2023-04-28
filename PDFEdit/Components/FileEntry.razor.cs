using Microsoft.AspNetCore.Components;

namespace PDFEdit.Components;

public partial class FileEntry
{
    [Parameter] public string FileName { get; set; }
    [Parameter] public int Index { get; set; }
    [Parameter] public Action<int> OnDelete { get; set; }
}
