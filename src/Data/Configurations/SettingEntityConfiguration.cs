using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShooterLink.Data.Configurations.Base;
using ShooterLink.Domain;

namespace ShooterLink.Data.Configurations;

public sealed class SettingEntityConfiguration : EntityConfiguration<Setting>
{
    public override void Configure(EntityTypeBuilder<Setting> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.SettingName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.StringValue)
            .HasMaxLength(500);

        builder.Property(e => e.DateValue)
            .HasColumnType("Timestamp");
    }
}