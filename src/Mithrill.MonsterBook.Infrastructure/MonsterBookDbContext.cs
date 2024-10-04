using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure
{
    public class MonsterBookDbContext : DbContext, IMonsterBookDbContext
    {
        public MonsterBookDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AttackType> AttackTypes { get; set; }
        public DbSet<Creature> Creatures { get; set; }
        public DbSet<Merit> Merits { get; set; }
        public DbSet<Flaw> Flaws {get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armor> Armors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MonsterBookDbContext).Assembly);
        }
    }
}