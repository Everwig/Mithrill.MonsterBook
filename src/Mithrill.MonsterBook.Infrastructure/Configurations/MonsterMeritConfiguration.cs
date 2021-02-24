using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class MonsterMeritConfiguration : IEntityTypeConfiguration<CreatureMerit>
    {
        public void Configure(EntityTypeBuilder<CreatureMerit> builder)
        {
            builder.HasKey(monsterMerit => new { monsterMerit.MonsterId, monsterMerit.MeritId });

            builder.HasOne(monsterMerit => monsterMerit.Creature)
                .WithMany(monster => monster.CreatureMerits)
                .HasForeignKey(monsterMerit => monsterMerit.MonsterId);

            builder.HasOne(monsterMerit => monsterMerit.Merit)
                .WithMany(merit => merit.CreatureMerits)
                .HasForeignKey(monsterMerit => monsterMerit.MeritId);

            builder.ToTable("CreatureMerit");
        }
    }
}