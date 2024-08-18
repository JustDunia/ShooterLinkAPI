using ShooterLink.Domain.Base;

namespace ShooterLink.Domain;

public class Club : Entity
{
    public required string Name { get; set; }
    public bool Verified { get; set; }

    public ICollection<User> Users { get; set; } = [];
}
