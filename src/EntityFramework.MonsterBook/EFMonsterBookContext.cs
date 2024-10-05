using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Mithrill.MonsterBook.Infrastructure;

namespace EntityFramework.MonsterBook
{
    public sealed class EfMonsterBookDbContext : MonsterBookDbContext
    {
        private const string ConnectionString = "Server=.;Database=MonsterBook;Trusted_Connection=true;TrustServerCertificate=True";
        
        public EfMonsterBookDbContext() : base(new DbContextOptionsBuilder<MonsterBookDbContext>()
            .UseSqlServer(ConnectionString)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .Options)
        {
        }
    }

    public class EfMonsterBookDbContextFactory : IDesignTimeDbContextFactory<EfMonsterBookDbContext>
    {
        public EfMonsterBookDbContext CreateDbContext(string[] args)
        {
            return new EfMonsterBookDbContext();
        }
    }
}