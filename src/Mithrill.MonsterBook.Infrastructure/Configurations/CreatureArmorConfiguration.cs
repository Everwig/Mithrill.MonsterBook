using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CreatureArmorConfiguration : IEntityTypeConfiguration<CreatureArmor>
    {
        public void Configure(EntityTypeBuilder<CreatureArmor> builder)
        {
            builder.HasKey(creatureArmor => new { creatureArmor.CreatureId, creatureArmor.ArmorId });

            builder.HasOne(creatureArmor => creatureArmor.Creature)
                .WithMany(creatureArmor => creatureArmor.CreatureArmors)
                .HasForeignKey(creatureArmor => creatureArmor.CreatureId);

            builder.HasOne(creatureArmor => creatureArmor.Armor)
                .WithMany(creatureArmor => creatureArmor.CreatureArmors)
                .HasForeignKey(creatureArmor => creatureArmor.ArmorId);

            builder.ToTable("CreatureArmor");
        }
    }
}