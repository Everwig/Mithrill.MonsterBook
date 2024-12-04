using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Behaviours;
using Mithrill.MonsterBook.Application.Common.Builders;
using Mithrill.MonsterBook.Application.Common.Validation;
using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application;

public static class DependencyInjection
{
    public static void RegisterApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        serviceCollection.AddTransient<INpcBuilder<GeneratedCreature>, CreatureBuilder>();
        serviceCollection.AddTransient(provider => new NpcDesigner<GeneratedCreature>(provider.GetRequiredService<INpcBuilder<GeneratedCreature>>()));
        serviceCollection.AddTransient<ISummonBuilder<GeneratedCreature>, FireElementalBuilder>();
        serviceCollection.AddTransient<ISummonBuilder<GeneratedCreature>, WaterElementalBuilder>();
        serviceCollection.AddTransient<ISummonBuilder<GeneratedCreature>, IceElementalBuilder>();
        serviceCollection.AddTransient<ISummonBuilder<GeneratedCreature>, AirElementalBuilder>();
        serviceCollection.AddTransient<ISummonBuilder<GeneratedCreature>, StormElementalBuilder>();
        serviceCollection.AddTransient<ISummonBuilder<GeneratedCreature>, EarthElementalBuilder>();
        serviceCollection.AddTransient<ISummonBuilder<GeneratedCreature>, RockElementalBuilder>();
        serviceCollection.AddTransient<ISummonBuilder<GeneratedCreature>, SandElementalBuilder>();
        serviceCollection.AddTransient<ITemplateValidatorService, TemplateValidatorService>();
    }
}