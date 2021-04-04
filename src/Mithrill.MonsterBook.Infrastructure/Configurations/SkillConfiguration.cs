using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skill");
        }
    }
}