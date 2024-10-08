using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CreatureWeaponConfiguration : IEntityTypeConfiguration<CreatureWeapon>
    {
        public void Configure(EntityTypeBuilder<CreatureWeapon> builder)
        {
            builder.Property(creatureWeapon => creatureWeapon.Material)
                .HasConversion<string>()
                .HasMaxLength(16);

            builder.HasKey(creatureWeapon => new { creatureWeapon.CreatureId, creatureWeapon.WeaponId });

            builder.HasOne(creatureWeapon => creatureWeapon.Creature)
                .WithMany(creature => creature.CreatureWeapons)
                .HasForeignKey(creatureWeapon => creatureWeapon.CreatureId);

            builder.HasOne(creatureWeapon => creatureWeapon.Weapon)
                .WithMany(weapon => weapon.CreatureWeapons)
                .HasForeignKey(creatureWeapon => creatureWeapon.WeaponId);

            builder.ToTable("CreatureWeapon");
        }
    }
}