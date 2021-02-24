using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class MonsterWeaponConfiguration : IEntityTypeConfiguration<CreatureWeapon>
    {
        public void Configure(EntityTypeBuilder<CreatureWeapon> builder)
        {
            builder.HasKey(monsterWeapon => new { monsterWeapon.MonsterId, monsterWeapon.WeaponId });

            builder.HasOne(monsterWeapon => monsterWeapon.Creature)
                .WithMany(monster => monster.CreatureWeapons)
                .HasForeignKey(monsterWeapon => monsterWeapon.MonsterId);

            builder.HasOne(monsterWeapon => monsterWeapon.Weapon)
                .WithMany(weapon => weapon.CreatureWeapons)
                .HasForeignKey(monsterWeapon => monsterWeapon.WeaponId);

            builder.ToTable("CreatureWeapon");
        }
    }
}