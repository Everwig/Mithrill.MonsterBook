using System.Collections.Generic;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedSummon;

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
    HashSet<AttackType> AttackTypes) :
    IMapFrom<Domain.Weapon>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Weapon, Weapon>()
            .ForCtorParam(nameof(Id), opt => opt.MapFrom(weapon => weapon.Id))
            .ForCtorParam(nameof(Name), opt => opt.MapFrom(weapon => weapon.Name))
            .ForCtorParam(nameof(BaseAttackModifier), opt => opt.MapFrom(weapon => weapon.BaseAttackModifier))
            .ForCtorParam(nameof(BaseDefenseModifier), opt => opt.MapFrom(weapon => weapon.BaseDefenseModifier))
            .ForCtorParam(nameof(BaseInitiativeModifier), opt => opt.MapFrom(weapon => weapon.BaseInitiativeModifier))
            .ForCtorParam(nameof(AdditionalAttackModifier), opt => opt.MapFrom(weapon => weapon.AdditionalAttackModifier))
            .ForCtorParam(nameof(AdditionalDefenseModifier), opt => opt.MapFrom(weapon => weapon.AdditionalDefenseModifier))
            .ForCtorParam(nameof(AdditionalInitiativeModifier), opt => opt.MapFrom(weapon => weapon.AdditionalInitiativeModifier))
            .ForCtorParam(nameof(Material), opt => opt.MapFrom(weapon => weapon.Material))
            .ForCtorParam(nameof(AttackTypes), opt => opt.MapFrom(weapon => weapon.AttackTypes));
    }
}