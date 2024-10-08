using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CharacterFlawConfiguration : IEntityTypeConfiguration<CharacterFlaw>
    {
        public void Configure(EntityTypeBuilder<CharacterFlaw> builder)
        {
            builder.HasKey(characterFlaw => new { characterFlaw.NpcTemplateId, characterFlaw.FlawId });

            builder.HasOne(characterFlaw => characterFlaw.NpcTemplate)
                .WithMany(npcTemplate => npcTemplate.CreatureFlaws)
                .HasForeignKey(characterFlaw => characterFlaw.NpcTemplateId);

            builder.HasOne(characterFlaw => characterFlaw.Flaw)
                .WithMany(merit => merit.CreatureFlaws)
                .HasForeignKey(characterFlaw => characterFlaw.FlawId);

            builder.ToTable("CharacterFlaw");
        }
    }
}