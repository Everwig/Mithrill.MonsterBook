using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Infrastructure.Dto;

namespace Mithrill.MonsterBook.Infrastructure
{
    internal class MonsterBookDbContext : DbContext
    {
        public DbSet<Monster> Monsters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monster>();
        }
    }
}