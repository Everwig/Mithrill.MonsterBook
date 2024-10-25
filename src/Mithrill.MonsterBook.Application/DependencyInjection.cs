using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Behaviours;
using Mithrill.MonsterBook.Application.Common.Builders;
using Mithrill.MonsterBook.Application.Common.Validation;

namespace Mithrill.MonsterBook.Application
{
    public static class DependencyInjection
    {
        public static void RegisterApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            serviceCollection.AddTransient<INpcBuilder<IGeneratedCreature>, CreatureBuilder>();
            serviceCollection.AddTransient(provider => new NpcDesigner<IGeneratedCreature>(provider.GetRequiredService<INpcBuilder<IGeneratedCreature>>()));
            serviceCollection.AddTransient<ITemplateValidatorService, TemplateValidatorService>();
        }
    }
}