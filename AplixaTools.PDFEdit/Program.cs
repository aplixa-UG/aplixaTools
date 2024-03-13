using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using AplixaTools.PDFEdit;
using AplixaTools.Shared.Services;
using AplixaTools.PDFEdit.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient(serviceProvider =>
    (IJSInProcessRuntime)serviceProvider.GetRequiredService<IJSRuntime>());
builder.Services.AddTransient<DefaultJsInteropService>(serviceProvider =>
    serviceProvider.GetRequiredService<JsInteropService>());
builder.Services.AddTransient<JsInteropService>();

builder.Services.AddSingleton<PdfMutationQueueService>();

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
