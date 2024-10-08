using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CreatureSkillCategoriesConfiguration : IEntityTypeConfiguration<CreatureSkillCategories>
    {
        public void Configure(EntityTypeBuilder<CreatureSkillCategories> builder)
        {
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

            builder.ToTable("CreatureSkillCategories");
        }
    }
}