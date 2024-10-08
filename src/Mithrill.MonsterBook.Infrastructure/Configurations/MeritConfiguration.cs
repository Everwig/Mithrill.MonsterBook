using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class MeritConfiguration : IEntityTypeConfiguration<Merit>
    {
        public void Configure(EntityTypeBuilder<Merit> builder)
        {
            builder.HasIndex(nameof(Merit.Name), nameof(Merit.NameHu)).IsUnique();
            builder.Property(nameof(Merit.Name)).HasMaxLength(64);
            builder.Property(nameof(Merit.NameHu)).HasMaxLength(64);
            builder.ToTable("Merit");
        }
    }
}