namespace AplixaTools.PDFEdit.Components;

public partial class NavMenu
{
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
