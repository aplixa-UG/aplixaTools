using AplixaTools.PDFEdit.Shared;
using Microsoft.AspNetCore.Components;

namespace AplixaTools.PDFEdit.Components;

public partial class NavItem
{
	[Inject] public NavigationManager NavigationManager { get; set; }

	/// <summary>
	/// The title of the NavItem's route
	/// </summary>
	[Parameter] public string Title { get; set; }
	/// <summary>
	/// The URL of the NavItems route
	/// </summary>
	[Parameter] public string Href { get; set; }
	/// <summary>
	/// The icon displayed next to the Title
	/// </summary>
	[Parameter] public string Icon { get; set; }
	/// <summary>
	/// Fires when the user clicks the NavItem
	/// </summary>
	[Parameter] public EventCallback OnNavigated { get; set; }

	private async Task Navigate()
	{
		NavigationManager.NavigateTo(Href);
		await OnNavigated.InvokeAsync();
	}
}
