using System.Collections.Generic;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain.ValueObjects;
using Material = Mithrill.MonsterBook.Application.Common.Material;

namespace Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate;

public sealed record Weapon(
    int Id,
    Material Material,
    int AdditionalAttackModifier,
    int AdditionalDefenseModifier,
    int AdditionalInitiativeModifier,
    bool IsOptional,
    HashSet<AttackType> AdditionalAttackTypes) : IMapTo<CharacterWeapon>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Weapon, CharacterWeapon>()
            .ForMember(characterWeapon => characterWeapon.Weapon, opt => opt.Ignore())
            .ForMember(characterWeapon => characterWeapon.NpcTemplateId, opt => opt.Ignore())
            .ForMember(characterWeapon => characterWeapon.NpcTemplate, opt => opt.Ignore())
            .ForMember(characterWeapon => characterWeapon.WeaponId, opt => opt.MapFrom(weapon => weapon.Id))
            .ForMember(characterWeapon => characterWeapon.AdditionalAttackTypes, opt => opt.Ignore());
    }
}