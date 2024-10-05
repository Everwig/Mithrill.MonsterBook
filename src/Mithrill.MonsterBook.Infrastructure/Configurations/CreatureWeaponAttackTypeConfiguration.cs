using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CreatureWeaponAttackTypeConfiguration : IEntityTypeConfiguration<CreatureWeaponAttackType>
    {
        public void Configure(EntityTypeBuilder<CreatureWeaponAttackType> builder)
        {
            builder.HasKey(creatureWeaponAttackType => new
            {
                creatureWeaponAttackType.AttackTypeId,
                creatureWeaponAttackType.CreatureId,
                creatureWeaponAttackType.WeaponId
            });

            builder.ToTable("CreatureWeaponAttackType");
        }
    }
}