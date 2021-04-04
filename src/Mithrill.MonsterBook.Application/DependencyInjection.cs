using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mithrill.MonsterBook.Application.Common.Mapping;
using Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;

namespace Mithrill.MonsterBook.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(GetGeneratedNpcQuery).Assembly);
            serviceCollection.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}