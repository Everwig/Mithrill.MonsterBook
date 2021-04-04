using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class MeritConfiguration : IEntityTypeConfiguration<Merit>
    {
        public void Configure(EntityTypeBuilder<Merit> builder)
        {
            builder.ToTable("Merit");
        }
    }
}