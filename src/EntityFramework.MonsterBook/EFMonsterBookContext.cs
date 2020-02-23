using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Infrastructure;

namespace EntityFramework.MonsterBook
{
    internal sealed class EFMonsterBookDbContext : MonsterBookDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MonsterBook;Trusted_Connection=true");
        }
    }
}