using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShooterLink.Domain.Base;

namespace ShooterLink.Data.Configurations.Base;

public class AuditedEntityConfiguration<T> : EntityConfiguration<T> where T : AuditedEntity
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Created)
            .IsRequired()
            .HasColumnType("Timestamp")
            .HasDefaultValue(DateTime.UtcNow);
        
        builder.Property(e => e.Modified)
            .IsRequired()
            .HasColumnType("Timestamp")
            .HasDefaultValue(DateTime.UtcNow);
    }
}

