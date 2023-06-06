namespace AplixaTools.PDFEdit.Models;

/// <summary>
/// An Enum representing the 4 possible rotations a Pdf document can be in
/// </summary>
public enum PdfRotation
{
    deg0,
    deg90,
    deg180,
    deg270,
}

public static class PdfRotationExtensions
{
    /// <summary>
    /// Converts a PdfRotation to it's respective float value
    /// </summary>
    /// <param name="rot">The PdfRotation to convert from</param>
    /// <returns>A float with the rotation in degrees</returns>
    /// <exception cref="ArgumentException"></exception>
    public static float ToFloat(this PdfRotation rot)
    {
        return rot switch
        {
            PdfRotation.deg0 => 0,
            PdfRotation.deg90 => 90,
            PdfRotation.deg180 => 180,
            PdfRotation.deg270 => 270,
            _ => throw new ArgumentException("Impossible PdfRotation was passed in")
        };
    }

    /// <summary>
    /// Converts a float into its respective PdfRotation if possible
    /// </summary>
    /// <param name="rot">The float (in degrees) to convert from</param>
    /// <returns>The PdfRotation belonging to the input value</returns>
    /// <exception cref="ArgumentException"></exception>
	public static PdfRotation FromFloat(float rot)
	{
		return rot switch
		{
			0 => PdfRotation.deg0,
            90 => PdfRotation.deg90,
            180 => PdfRotation.deg180,
            270 => PdfRotation.deg270,
			_ => throw new ArgumentException($"{rot}deg is not valid for PDF documents")
		};
	}
}
