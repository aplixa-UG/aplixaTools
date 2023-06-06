namespace AplixaTools.PDFEdit.Models;

/// <summary>
/// Defines an element bounding box's position and size
/// </summary>
public class ElementDimensions
{
	public Pos2 Position { get; set; }
	public Pos2 Size { get; set; }

	/// <summary>
	/// Checks if a point is inside of the element's bounding box
	/// </summary>
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
