using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CharacterWeaponAttackTypeConfiguration : IEntityTypeConfiguration<CharacterWeaponAttackType>
    {
        public void Configure(EntityTypeBuilder<CharacterWeaponAttackType> builder)
        {
            builder.HasKey(characterWeaponAttackType => new
            {
                characterWeaponAttackType.AttackTypeId,
                characterWeaponAttackType.NpcTemplateId,
                characterWeaponAttackType.WeaponId
            });

            builder.ToTable("CharacterWeaponAttackType");
        }
    }
}