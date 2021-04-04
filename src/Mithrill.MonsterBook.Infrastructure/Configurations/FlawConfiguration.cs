using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class FlawConfiguration : IEntityTypeConfiguration<Flaw>
    {
        public void Configure(EntityTypeBuilder<Flaw> builder)
        {
            builder.ToTable("Flaw");
        }
    }
}