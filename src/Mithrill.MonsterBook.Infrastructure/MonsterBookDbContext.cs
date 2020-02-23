using System.Threading;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure
{
    internal class MonsterBookDbContext : DbContext, IMonsterBookDbContext
    {
        public DbSet<AttackType> AttackTypes { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Merit> Merits { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MonsterBookDbContext).Assembly);
        }
    }
}