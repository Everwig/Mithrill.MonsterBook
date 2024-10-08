using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasIndex(nameof(Skill.Name), nameof(Skill.NameHu), nameof(Skill.Category), nameof(Skill.Attribute1), nameof(Skill.Attribute2)).IsUnique();
            builder.Property(nameof(Skill.Name)).HasMaxLength(64);
            builder.Property(nameof(Skill.NameHu)).HasMaxLength(64);
            builder.Property(skill => skill.Attribute1)
                .HasConversion<string>()
                .HasMaxLength(16);

            builder.Property(skill => skill.Attribute2)
                .HasConversion<string>()
                .HasMaxLength(16);

            builder.Property(skill => skill.Category)
                .HasConversion<string>()
                .HasMaxLength(16);

            builder.ToTable("Skill");
        }
    }
}