using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class MonstersConfiguration : IEntityTypeConfiguration<Creature>
    {
        public void Configure(EntityTypeBuilder<Creature> builder)
        {
            builder.ToTable("Creature");
        }
    }
}