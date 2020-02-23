using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class MonstersConfiguration : IEntityTypeConfiguration<Monster>
    {
        public void Configure(EntityTypeBuilder<Monster> builder)
        {
            builder.ToTable("Monster");
        }
    }
}