namespace AplixaTools.PDFEdit.Models;

public class ElementDimensions
{
	public Pos2 Position { get; set; }
	public Pos2 Size { get; set; }

	public bool Contains(Pos2 point)
	{
		if (
			point.X >= Position.X &&
			point.X <= Position.X + Size.X &&
			point.Y >= Position.Y &&
			point.Y <= Position.Y + Size.Y
		)
		{
			return true;
		}
		return false;
	}
}
