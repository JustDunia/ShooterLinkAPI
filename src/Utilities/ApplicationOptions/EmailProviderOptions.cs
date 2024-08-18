using System.ComponentModel.DataAnnotations;

namespace ShooterLink.Utilities.ApplicationOptions;

public sealed class EmailProviderOptions
{
    public const string Key = "EmailProvider";

    [Required]
    public required string Host { get; init; }

    [Required]
    public int Port { get; init; }

    [Required]
    public required string UserName { get; init; }

    [Required]
    public required string Password { get; init; }

    [Required]
    [EmailAddress]
    public required string SenderAddress { get; init; }
}
