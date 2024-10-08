using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class NpcTemplateConfiguration : IEntityTypeConfiguration<NpcTemplate>
    {
        public void Configure(EntityTypeBuilder<NpcTemplate> builder)
        {
            builder.ToTable("NpcTemplate");
            builder.Property(creature => creature.Race)
                .HasConversion<string>()
                .HasMaxLength(32);

            builder.Property(creature => creature.Difficulty)
                .HasConversion<string>()
                .HasMaxLength(16);
        }
    }
}