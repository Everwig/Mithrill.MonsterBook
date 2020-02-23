using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class MonsterWeaponConfiguration : IEntityTypeConfiguration<MonsterWeapon>
    {
        public void Configure(EntityTypeBuilder<MonsterWeapon> builder)
        {
            builder.HasKey(monsterWeapon => new { monsterWeapon.MonsterId, monsterWeapon.WeaponId });

            builder.HasOne(monsterWeapon => monsterWeapon.Monster)
                .WithMany(monster => monster.MonsterWeapons)
                .HasForeignKey(monsterWeapon => monsterWeapon.MonsterId);

            builder.HasOne(monsterWeapon => monsterWeapon.Weapon)
                .WithMany(weapon => weapon.MonsterWeapons)
                .HasForeignKey(monsterWeapon => monsterWeapon.WeaponId);

            builder.ToTable("MonsterWeapon");
        }
    }
}