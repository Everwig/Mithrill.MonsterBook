using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CreatureSkillCategoriesConfiguration : IEntityTypeConfiguration<CreatureSkillCategories>
    {
        public void Configure(EntityTypeBuilder<CreatureSkillCategories> builder)
        {
            builder.ToTable("CreatureSkillCategories");
        }
    }
}