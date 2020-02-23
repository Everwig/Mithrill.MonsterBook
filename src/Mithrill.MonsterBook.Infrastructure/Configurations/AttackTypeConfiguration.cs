using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class AttackTypeConfiguration : IEntityTypeConfiguration<AttackType>
    {
        public void Configure(EntityTypeBuilder<AttackType> builder)
        {
            builder.ToTable("AttackType");
        }
    }
}