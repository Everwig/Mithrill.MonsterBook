using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CreatureSkillConfiguration : IEntityTypeConfiguration<CreatureSkill>
    {
        public void Configure(EntityTypeBuilder<CreatureSkill> builder)
        {
            builder.HasKey(creatureSkill => new { creatureSkill.CreatureId, creatureSkill.SkillId });

            builder.HasOne(creatureSkill => creatureSkill.Creature)
                .WithMany(creature => creature.CreatureSkills)
                .HasForeignKey(creatureSkill => creatureSkill.CreatureId);

            builder.HasOne(creatureSkill => creatureSkill.Skill)
                .WithMany(skill => skill.CreatureSkills)
                .HasForeignKey(creatureSkill => creatureSkill.SkillId);

            builder.ToTable("CreatureSkill");
        }
    }
}