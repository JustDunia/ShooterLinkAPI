using ShooterLink.Domain;

namespace ShooterLink.Domain.Base;

public abstract class UserAuditedEntity : AuditedEntity
{
    public Guid CreatorId { get; set; }
    public User? Creator { get; set; }
    public Guid ModifierId { get; set; }
    public User? Modifier { get; set; }
}
