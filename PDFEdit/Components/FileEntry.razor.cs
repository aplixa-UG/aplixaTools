using Microsoft.AspNetCore.Components;

namespace PDFEdit.Components;

public partial class FileEntry
{
    [Parameter] public string FileName { get; set; }
}
