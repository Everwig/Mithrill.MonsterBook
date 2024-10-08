using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CharacterWeaponConfiguration : IEntityTypeConfiguration<CharacterWeapon>
    {
        public void Configure(EntityTypeBuilder<CharacterWeapon> builder)
        {
            builder.HasKey(characterWeapon => new { characterWeapon.NpcTemplateId, characterWeapon.WeaponId });
            builder.Property(creatureWeapon => creatureWeapon.Material)
                .HasConversion<string>()
                .HasMaxLength(16);

            builder.HasOne(characterWeapon => characterWeapon.NpcTemplate)
                .WithMany(npcTemplate => npcTemplate.CharacterWeapons)
                .HasForeignKey(characterWeapon => characterWeapon.NpcTemplateId);

            builder.HasOne(characterWeapon => characterWeapon.Weapon)
                .WithMany(weapon => weapon.CreatureWeapons)
                .HasForeignKey(characterWeapon => characterWeapon.WeaponId);

            builder.ToTable("CharacterWeapon");
        }
    }
}