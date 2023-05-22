using AplixaTools.PDFEdit.Shared;
using Microsoft.AspNetCore.Components;

namespace AplixaTools.PDFEdit.Components;

public partial class NavItem
{
	[Inject] public NavigationManager NavigationManager { get; set; }

	[Parameter] public string Title { get; set; }
	[Parameter] public string Href { get; set; }
	[Parameter] public string Icon { get; set; }
	[Parameter] public EventCallback OnNavigated { get; set; }

	private async Task Navigate()
	{
		NavigationManager.NavigateTo(Href);
		await OnNavigated.InvokeAsync();
	}
}
