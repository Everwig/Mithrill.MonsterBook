using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Infrastructure;

namespace EntityFramework.MonsterBook
{
    internal sealed class EfMonsterBookDbContext : MonsterBookDbContext
    {
        private const string ConnectionString = "Server=.\\SQLEXPRESS;Database=MonsterBook;Trusted_Connection=true";
        
        public EfMonsterBookDbContext() : base(new DbContextOptionsBuilder<MonsterBookDbContext>()
            .UseSqlServer(ConnectionString)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .Options)
        {
        }
    }
}