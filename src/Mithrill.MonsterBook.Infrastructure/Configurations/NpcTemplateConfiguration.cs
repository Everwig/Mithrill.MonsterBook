using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations;

internal sealed class NpcTemplateConfiguration : IEntityTypeConfiguration<NpcTemplate>
{
    public void Configure(EntityTypeBuilder<NpcTemplate> builder)
    {
        builder.ToTable(
            "NpcTemplate",
            tableBuilder => tableBuilder.HasCheckConstraint(
                "CK_IsSummon_SummonType",
                $"([{nameof(NpcTemplate.IsSummon)}] = 0 AND [{nameof(NpcTemplate.SummonType)}] IS NULL) OR ([{nameof(NpcTemplate.IsSummon)}] = 1 AND [{nameof(NpcTemplate.SummonType)}] IS NOT NULL)"));
        builder.Property(nameof(NpcTemplate.Name)).HasMaxLength(64);
        builder.Property(nameof(NpcTemplate.NameHu)).HasMaxLength(64);
        builder.Property(creature => creature.Race)
            .HasConversion<string>()
            .HasMaxLength(32);

        builder.Property(creature => creature.Difficulty)
            .HasConversion<string>()
            .HasMaxLength(16);

        builder.Property(nameof(NpcTemplate.SummonType))
            .HasConversion<string>()
            .HasMaxLength(8);

        builder.HasIndex(e => e.SummonType)
            .HasFilter($"[{nameof(NpcTemplate.IsSummon)}] = 1")
            .IsUnique();
    }
}