using ShooterLink.Extensions;

namespace ShooterLink.UnitTests.Extensions;
public class StringExtensionsTests
{
    [Fact]
    public void FilterChar_ShouldFilterCharFromString()
    {
        // Arrange
        string input = "Hello, World!";
        char charToFilter = 'o';
        string expected = "Hell, Wrld!";

        // Act
        string result = input.FilterChar(charToFilter);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FilterString_ShouldFilterStringFromString()
    {
        // Arrange
        string input = "Hello, World!";
        string stringToFilter = "o";
        string expected = "Hell, Wrld!";

        // Act
        string result = input.FilterString(stringToFilter);

        // Assert
        Assert.Equal(expected, result);
    }
}
