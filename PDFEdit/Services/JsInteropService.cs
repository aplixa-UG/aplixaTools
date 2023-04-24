using System;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PDFEdit.Shared;

namespace PDFEdit.Services;

public class JsInteropService : DefaultJsInteropService
{
    public JsInteropService(IJSInProcessRuntime jsRuntime)
        : base(jsRuntime)
    {
    }

    public async Task<string> PDFtoJPEG(byte[] pdf, int i, CancellationToken cancellationToken)
    {
        return await JsRuntime.InvokeAsync<string>(
            Prefix + "pdfUtils.PDFtoJPEG",
            cancellationToken,
            pdf,
            i
        );
    }
}