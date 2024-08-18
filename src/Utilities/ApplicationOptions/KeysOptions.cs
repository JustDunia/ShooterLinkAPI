using System.ComponentModel.DataAnnotations;

namespace ShooterLink.Utilities.ApplicationOptions;

public sealed class KeysOptions
{
    public const string Key = "Keys";

    [Required]
    [MinLength(32)]
    public required string SigningKey { get; init; }
}
