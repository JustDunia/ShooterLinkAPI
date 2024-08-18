namespace ShooterLink.Extensions;

public static class StringExtensions
{
    public static string FilterChar(this string input, char charToFilter)
    {
        string filteredString = input.Replace(charToFilter.ToString(), string.Empty);
        return filteredString;
    }

    public static string FilterString(this string input, string stringToFilter)
    {
        string filteredString = input.Replace(stringToFilter, string.Empty);
        return filteredString;
    }
}
