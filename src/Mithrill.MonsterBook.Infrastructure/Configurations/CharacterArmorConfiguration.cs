using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CharacterArmorConfiguration : IEntityTypeConfiguration<CharacterArmor>
    {
        public void Configure(EntityTypeBuilder<CharacterArmor> builder)
        {
            builder.HasKey(characterArmor => new { characterArmor.NpcTemplateId, characterArmor.ArmorId });
            builder.Property(creatureArmor => creatureArmor.Material)
                .HasConversion<string>()
                .HasMaxLength(16);

            builder.HasOne(characterArmor => characterArmor.NpcTemplate)
                .WithMany(characterArmor => characterArmor.CreatureArmors)
                .HasForeignKey(characterArmor => characterArmor.NpcTemplateId);

            builder.HasOne(characterArmor => characterArmor.Armor)
                .WithMany(characterArmor => characterArmor.CharacterArmors)
                .HasForeignKey(characterArmor => characterArmor.ArmorId);

            builder.ToTable("CharacterArmor");
        }
    }
}