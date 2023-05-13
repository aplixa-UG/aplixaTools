﻿using Microsoft.AspNetCore.Components;

namespace AplixaTools.PDFEdit.Components;

public partial class FileEntry
{
    [Parameter] public string FileName { get; set; }
    [Parameter] public int Index { get; set; }
    [Parameter] public EventCallback<int> OnDelete { get; set; }
}