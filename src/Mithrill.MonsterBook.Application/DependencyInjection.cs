using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Factories;
using Mithrill.MonsterBook.Application.Common.Mapping;
using Mithrill.MonsterBook.Application.Monsters.Query.GetGeneratedMonster;

namespace Mithrill.MonsterBook.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMonsterFactory, MonsterFactory>();
            serviceCollection.AddMediatR(typeof(GetGeneratedMonsterQuery).Assembly);
            serviceCollection.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}