using ShooterLink.Domain.Base;

namespace ShooterLink.Domain;

public sealed class User : AuditedEntity
{
    public string PasswordHash { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string NormalizedEmail { get; set; } = null!;
    public bool EmailConfirmed { get; set; }
    public string? NickName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? Token { get; set; }
    public DateTime? TokenExpires { get; set; }

    public Club Club { get; set; } = null!;
    public Guid ClubId { get; set; }

    public ICollection<Role> Roles { get; set; } = [];
}
