using System.Text.Json;
using System.Text.Json.Serialization;

namespace ShooterLink.Utilities.GlobalSettings;

public static class Json
{
    public static JsonSerializerOptions DefaultSerializerOptions => new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
}
