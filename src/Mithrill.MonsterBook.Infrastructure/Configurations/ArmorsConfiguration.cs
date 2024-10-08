using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations;

internal sealed class ArmorsConfiguration : IEntityTypeConfiguration<Armor>
{
    public void Configure(EntityTypeBuilder<Armor> builder)
    {
        builder.HasIndex(nameof(Armor.Name), nameof(Armor.NameHu)).IsUnique();
        builder.Property(nameof(Armor.Name)).HasMaxLength(64);
        builder.Property(nameof(Armor.NameHu)).HasMaxLength(64);
        builder.ToTable("Armor");
    }
}