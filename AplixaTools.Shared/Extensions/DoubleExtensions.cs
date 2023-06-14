namespace AplixaTools.Shared.Extensions;

public static class DoubleExtensions
{
    public static string ToHTMLString(this double num)
    {
        return num.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
    }
}
