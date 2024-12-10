using System.Collections.Generic;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;

public sealed record Weapon(
    int Id,
    string Name,
    Material Material,
    int BaseAttackModifier,
    int BaseDefenseModifier,
    int BaseInitiativeModifier,
    int AdditionalAttackModifier,
    int AdditionalDefenseModifier,
    int AdditionalInitiativeModifier,
    HashSet<AttackType> AttackTypes) : IMapFrom<Domain.Weapon>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Weapon, Weapon>()
            .ForCtorParam(ctorParamName: nameof(Id), opt => opt.MapFrom(skill => skill.Id))
            .ForCtorParam(ctorParamName: nameof(Name), opt => opt.MapFrom(skill => skill.Name))
            .ForCtorParam(ctorParamName: nameof(Material), opt => opt.MapFrom(skill => skill.Material))
            .ForCtorParam(ctorParamName: nameof(BaseAttackModifier), opt => opt.MapFrom(skill => skill.BaseAttackModifier))
            .ForCtorParam(ctorParamName: nameof(BaseDefenseModifier), opt => opt.MapFrom(skill => skill.BaseDefenseModifier))
            .ForCtorParam(ctorParamName: nameof(BaseInitiativeModifier), opt => opt.MapFrom(skill => skill.BaseInitiativeModifier))
            .ForCtorParam(ctorParamName: nameof(AdditionalAttackModifier), opt => opt.MapFrom(skill => skill.AdditionalAttackModifier))
            .ForCtorParam(ctorParamName: nameof(AdditionalDefenseModifier), opt => opt.MapFrom(skill => skill.AdditionalDefenseModifier))
            .ForCtorParam(ctorParamName: nameof(AdditionalInitiativeModifier), opt => opt.MapFrom(skill => skill.AdditionalInitiativeModifier))
            .ForCtorParam(ctorParamName: nameof(AttackTypes), opt => opt.MapFrom(skill => skill.AttackTypes));
    }
}