namespace ShooterLink.Domain.Base;

public abstract class AuditedEntity : Entity
{
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}
