using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using AttackType = Mithrill.MonsterBook.Application.Common.AttackType;
using Material = Mithrill.MonsterBook.Application.Common.Material;

namespace Mithrill.MonsterBook.Application.Npc.Command.CreateNpcTemplate;

public sealed record Weapon(
    int Id,
    Material Material,
    int AdditionalAttackModifier,
    int AdditionalDefenseModifier,
    int AdditionalInitiativeModifier,
    bool IsOptional,
    HashSet<AttackType> AdditionalAttackTypes) : IMapTo<MonsterBook.Domain.CharacterWeapon>
{

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Weapon, MonsterBook.Domain.CharacterWeapon>()
            .ForMember(characterWeapon => characterWeapon.Weapon, opt => opt.Ignore())
            .ForMember(characterWeapon => characterWeapon.NpcTemplateId, opt => opt.Ignore())
            .ForMember(characterWeapon => characterWeapon.NpcTemplate, opt => opt.Ignore())
            .ForMember(characterWeapon => characterWeapon.WeaponId, opt => opt.MapFrom(weapon => weapon.Id))
            .ForMember(characterWeapon => characterWeapon.AdditionalAttackTypes, opt => opt.MapFrom<CustomAttackTypeMapping>());
    }
}

internal class CustomAttackTypeMapping : IValueResolver<Weapon, MonsterBook.Domain.CharacterWeapon, ICollection<MonsterBook.Domain.CharacterWeaponAttackType>>
{
    public ICollection<MonsterBook.Domain.CharacterWeaponAttackType> Resolve(Weapon source, MonsterBook.Domain.CharacterWeapon destination, ICollection<MonsterBook.Domain.CharacterWeaponAttackType> destMember, ResolutionContext context)
    {
        return source.AdditionalAttackTypes.Select(attackType => new MonsterBook.Domain.CharacterWeaponAttackType
        {
            WeaponId = source.Id,
            AttackType = new MonsterBook.Domain.AttackType
            {
                DamageType = (MonsterBook.Domain.DamageType)attackType.DamageType,
                GuaranteedDamage = attackType.GuaranteedDamage,
                NumberOfDices = attackType.NumberOfDices
            }
        }).ToList();
    }
}