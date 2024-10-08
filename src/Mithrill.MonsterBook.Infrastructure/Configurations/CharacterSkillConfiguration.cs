using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CharacterSkillConfiguration : IEntityTypeConfiguration<CharacterSkill>
    {
        public void Configure(EntityTypeBuilder<CharacterSkill> builder)
        {
            builder.HasKey(characterSkill => new { characterSkill.NpcTemplateId, characterSkill.SkillId });

            builder.HasOne(characterSkill => characterSkill.NpcTemplate)
                .WithMany(npcTemplate => npcTemplate.CreatureSkills)
                .HasForeignKey(characterSkill => characterSkill.NpcTemplateId);

            builder.HasOne(characterSkill => characterSkill.Skill)
                .WithMany(skill => skill.CreatureSkills)
                .HasForeignKey(characterSkill => characterSkill.SkillId);

            builder.ToTable("CharacterSkill");
        }
    }
}