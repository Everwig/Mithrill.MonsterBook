using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class MonsterMeritConfiguration : IEntityTypeConfiguration<MonsterMerit>
    {
        public void Configure(EntityTypeBuilder<MonsterMerit> builder)
        {
            builder.HasKey(monsterMerit => new { monsterMerit.MonsterId, monsterMerit.MeritId });

            builder.HasOne(monsterMerit => monsterMerit.Monster)
                .WithMany(monster => monster.MonsterMerits)
                .HasForeignKey(monsterMerit => monsterMerit.MonsterId);

            builder.HasOne(monsterMerit => monsterMerit.Merit)
                .WithMany(merit => merit.MonsterMerits)
                .HasForeignKey(monsterMerit => monsterMerit.MeritId);

            builder.ToTable("MonsterMerit");
        }
    }
}