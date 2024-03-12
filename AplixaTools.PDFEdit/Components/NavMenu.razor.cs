using AplixaTools.Shared.Components;

namespace AplixaTools.PDFEdit.Components;

public partial class NavMenu
{
	protected Modal InfoModal { get; set; }

	private bool _showNavMenu;

	private void ToggleNavMenu()
	{
		_showNavMenu = !_showNavMenu;
	}

	private void HideNavMenu()
	{
		_showNavMenu = false;
	}
}
