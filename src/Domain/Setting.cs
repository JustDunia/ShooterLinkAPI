using ShooterLink.Domain.Base;

namespace ShooterLink.Domain;

public sealed class Setting : Entity
{
    public required string SettingName { get; set; }
    public string? StringValue { get; set; }
    public bool? BoolValue { get; set; }
    public DateTime? DateValue { get; set; }
    public int? IntValue { get; set; }
    public double? DoubleValue { get; set; }
}