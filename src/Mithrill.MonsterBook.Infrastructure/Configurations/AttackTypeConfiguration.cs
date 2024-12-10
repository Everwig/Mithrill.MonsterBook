using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain.Entities;

namespace Mithrill.MonsterBook.Infrastructure.Configurations;

internal sealed class AttackTypeConfiguration : IEntityTypeConfiguration<AttackType>
{
    public void Configure(EntityTypeBuilder<AttackType> builder)
    {
        builder.ToTable("AttackType");
        builder.Property(attackType => attackType.DamageType)
            .HasConversion<string>()
            .HasMaxLength(16);
    }
}