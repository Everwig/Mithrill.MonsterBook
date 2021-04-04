using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure.Configurations
{
    internal sealed class WeaponsConfiguration : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.ToTable("Weapon");
        }
    }
}