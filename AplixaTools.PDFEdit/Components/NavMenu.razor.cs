namespace AplixaTools.PDFEdit.Components;

public partial class NavMenu
{
	private bool _showNavMenu = false;

	private void ToggleNavMenu()
	{
		_showNavMenu = !_showNavMenu;
	}

	private void HideNavMenu()
	{
		_showNavMenu = false;
	}
}
