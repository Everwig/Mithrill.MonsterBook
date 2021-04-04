using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mithrill.MonsterBook.Application.Common.Adapters;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("EntityFramework.MonsterBook")]
namespace Mithrill.MonsterBook.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<MonsterBookDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("MonsterBookDatabase"));
                option.EnableDetailedErrors();
            });

            serviceCollection.AddScoped<IMonsterBookDbContext>(provider => provider.GetRequiredService<MonsterBookDbContext>());
        }
    }
}