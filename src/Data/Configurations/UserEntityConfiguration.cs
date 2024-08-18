using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShooterLink.Data.Configurations.Base;
using ShooterLink.Domain;

namespace ShooterLink.Data.Configurations;

public sealed class UserEntityConfiguration : EntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.PasswordHash)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.NormalizedEmail)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.NickName)
            .HasMaxLength(255);

        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(e => e.DateOfBirth)
            .HasColumnType("Date");

        builder.Property(e => e.Token)
            .HasMaxLength(500);

        builder.Property(e => e.TokenExpires)
            .HasColumnType("Timestamp");

        builder.HasMany(e => e.Roles)
            .WithMany(e => e.Users);
    }
}