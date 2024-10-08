using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CharacterSkillCategoriesConfiguration : IEntityTypeConfiguration<CharacterSkillCategories>
    {
        public void Configure(EntityTypeBuilder<CharacterSkillCategories> builder)
        {
            builder.ToTable("CharacterSkillCategories");
            builder.Property(creatureSkillCategories => creatureSkillCategories.Primary)
                .HasConversion<string>()
                .HasMaxLength(16);

            builder.Property(creatureSkillCategories => creatureSkillCategories.FirstSecondary)
                .HasConversion<string>()
                .HasMaxLength(16);

            builder.Property(creatureSkillCategories => creatureSkillCategories.SecondSecondary)
                .HasConversion<string>()
                .HasMaxLength(16);

            builder.Property(creatureSkillCategories => creatureSkillCategories.Tertiary)
                .HasConversion<string>()
                .HasMaxLength(16);
        }
    }
}