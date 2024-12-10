using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain.ValueObjects;
using DamageType = Mithrill.MonsterBook.Application.Common.DamageType;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate;

public sealed record Weapon(
    int Id,
    string Name,
    int BaseAttackModifier,
    int BaseDefenseModifier,
    int BaseInitiativeModifier,
    int AdditionalAttackModifier,
    int AdditionalDefenseModifier,
    int AdditionalInitiativeModifier,
    Common.Material Material,
    bool IsOptional,
    List<AttackType> AttackType
) : IMapFrom<CharacterWeapon>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CharacterWeapon, Weapon>()
            .ForCtorParam(ctorParamName: nameof(Id), opt => opt.MapFrom(creatureWeapon => creatureWeapon.WeaponId))
            .ForCtorParam(ctorParamName: nameof(Name), opt => opt.MapFrom(creatureWeapon => creatureWeapon.Weapon.Name))
            .ForCtorParam(ctorParamName: nameof(BaseAttackModifier),
                opt => opt.MapFrom(creatureWeapon => creatureWeapon.Weapon.BaseAttackModifier))
            .ForCtorParam(ctorParamName: nameof(BaseDefenseModifier),
                opt => opt.MapFrom(creatureWeapon => creatureWeapon.Weapon.BaseDefenseModifier))
            .ForCtorParam(ctorParamName: nameof(BaseInitiativeModifier),
                opt => opt.MapFrom(creatureWeapon => creatureWeapon.Weapon.BaseInitiativeModifier))
            .ForCtorParam(ctorParamName: nameof(AdditionalAttackModifier),
                opt => opt.MapFrom(creatureWeapon => creatureWeapon.AdditionalAttackModifier))
            .ForCtorParam(ctorParamName: nameof(AdditionalDefenseModifier),
                opt => opt.MapFrom(creatureWeapon => creatureWeapon.AdditionalDefenseModifier))
            .ForCtorParam(ctorParamName: nameof(AdditionalInitiativeModifier),
                opt => opt.MapFrom(creatureWeapon => creatureWeapon.AdditionalInitiativeModifier))
            .ForCtorParam(ctorParamName: nameof(Material), opt => opt.MapFrom(creatureArmor => creatureArmor.Material))
            .ForCtorParam(ctorParamName: nameof(IsOptional), opt => opt.MapFrom(creatureArmor => creatureArmor.IsOptional))
            .ForCtorParam(ctorParamName: nameof(AttackType), opt => opt.MapFrom(creatureWeapon => creatureWeapon.AdditionalAttackTypes.Select(attackType => attackType.AttackType)))
            .AfterMap((creatureWeapon, weapon) => weapon.AttackType.Add(new AttackType(
                creatureWeapon.Weapon.BaseAttackType.Id,
                (DamageType)creatureWeapon.Weapon.BaseAttackType.DamageType,
                creatureWeapon.Weapon.BaseAttackType.NumberOfDices,
                creatureWeapon.Weapon.BaseAttackType.GuaranteedDamage,
                true)));
    }
}