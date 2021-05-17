using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class FlawConfiguration : IEntityTypeConfiguration<Flaw>
    {
        public void Configure(EntityTypeBuilder<Flaw> builder)
        {
            builder.HasIndex(nameof(Flaw.Name), nameof(Flaw.NameHu)).IsUnique();
            builder.Property(nameof(Flaw.Name)).HasMaxLength(50);
            builder.Property(nameof(Flaw.NameHu)).HasMaxLength(50);
            builder.ToTable("Flaw");
        }
    }
}