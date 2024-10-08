using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CharacterMeritConfiguration : IEntityTypeConfiguration<CharacterMerit>
    {
        public void Configure(EntityTypeBuilder<CharacterMerit> builder)
        {
            builder.HasKey(characterMerit => new { characterMerit.NpcTemplateId, characterMerit.MeritId });

            builder.HasOne(characterMerit => characterMerit.NpcTemplate)
                .WithMany(npcTemplate => npcTemplate.CharacterMerits)
                .HasForeignKey(characterMerit => characterMerit.NpcTemplateId);

            builder.HasOne(characterMerit => characterMerit.Merit)
                .WithMany(merit => merit.CreatureMerits)
                .HasForeignKey(characterMerit => characterMerit.MeritId);

            builder.ToTable("CharacterMerit");
        }
    }
}