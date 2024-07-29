using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Builders;

namespace Mithrill.MonsterBook.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IAttackType>());
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddTransient<INpcBuilder<IGeneratedCreature>, CreatureBuilder>();
            serviceCollection.AddTransient(provider => new NpcDesigner<IGeneratedCreature>(provider.GetRequiredService<INpcBuilder<IGeneratedCreature>>()));
        }
    }
}