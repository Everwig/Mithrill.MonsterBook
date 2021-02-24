using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class MonsterSkillConfiguration : IEntityTypeConfiguration<CreatureSkill>
    {
        public void Configure(EntityTypeBuilder<CreatureSkill> builder)
        {
            builder.HasKey(monsterSkill => new { monsterSkill.MonsterId, monsterSkill.SkillId });

            builder.HasOne(monsterSkill => monsterSkill.Creature)
                .WithMany(monster => monster.CreatureSkills)
                .HasForeignKey(monsterSkill => monsterSkill.MonsterId);

            builder.HasOne(monsterSkill => monsterSkill.Skill)
                .WithMany(merit => merit.CreatureSkills)
                .HasForeignKey(monsterSkill => monsterSkill.SkillId);

            builder.ToTable("CreatureSkill");
        }
    }
}