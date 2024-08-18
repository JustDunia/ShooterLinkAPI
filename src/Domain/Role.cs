using ShooterLink.Domain.Base;

namespace ShooterLink.Domain;

public sealed class Role : Entity
{
    public required string Name { get; set; }

    public ICollection<User> Users { get; set; } = [];
}
