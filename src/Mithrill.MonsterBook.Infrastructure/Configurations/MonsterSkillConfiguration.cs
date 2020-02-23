using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class MonsterSkillConfiguration : IEntityTypeConfiguration<MonsterSkill>
    {
        public void Configure(EntityTypeBuilder<MonsterSkill> builder)
        {
            builder.HasKey(monsterSkill => new { monsterSkill.MonsterId, monsterSkill.SkillId });

            builder.HasOne(monsterSkill => monsterSkill.Monster)
                .WithMany(monster => monster.MonsterSkills)
                .HasForeignKey(monsterSkill => monsterSkill.MonsterId);

            builder.HasOne(monsterSkill => monsterSkill.Skill)
                .WithMany(merit => merit.MonsterSkills)
                .HasForeignKey(monsterSkill => monsterSkill.SkillId);

            builder.ToTable("MonsterSkill");
        }
    }
}