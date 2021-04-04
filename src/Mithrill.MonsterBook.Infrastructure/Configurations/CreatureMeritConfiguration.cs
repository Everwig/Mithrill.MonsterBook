using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CreatureMeritConfiguration : IEntityTypeConfiguration<CreatureMerit>
    {
        public void Configure(EntityTypeBuilder<CreatureMerit> builder)
        {
            builder.HasKey(creatureMerit => new { creatureMerit.CreatureId, creatureMerit.MeritId });

            builder.HasOne(creatureMerit => creatureMerit.Creature)
                .WithMany(creature => creature.CreatureMerits)
                .HasForeignKey(creatureMerit => creatureMerit.CreatureId);

            builder.HasOne(creatureMerit => creatureMerit.Merit)
                .WithMany(merit => merit.CreatureMerits)
                .HasForeignKey(creatureMerit => creatureMerit.MeritId);

            builder.ToTable("CreatureMerit");
        }
    }
}