using Microsoft.Extensions.DependencyInjection;
using Mithrill.MonsterBook.Application.Interfaces;

namespace Mithrill.MonsterBook.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEncounterRepository, EncounterRepository>();
        }
    }
}