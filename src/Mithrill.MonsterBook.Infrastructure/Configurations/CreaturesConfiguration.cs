using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class CreaturesConfiguration : IEntityTypeConfiguration<Creature>
    {
        public void Configure(EntityTypeBuilder<Creature> builder)
        {
            builder.Property(creature => creature.Race)
                .HasConversion<string>()
                .HasMaxLength(32);

            builder.Property(creature => creature.Difficulty)
                .HasConversion<string>()
                .HasMaxLength(16);

            builder.ToTable("Creature");
        }
    }
}