using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class WeaponsConfiguration : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.HasIndex(nameof(Weapon.Name), nameof(Weapon.NameHu)).IsUnique();
            builder.Property(nameof(Weapon.Name)).HasMaxLength(64);
            builder.Property(nameof(Weapon.NameHu)).HasMaxLength(64);
            builder.ToTable("Weapon");

            builder.HasOne(weapon => weapon.BaseAttackType)
                .WithMany(attackType => attackType.Weapons)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}