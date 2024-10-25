using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using AttackType = Mithrill.MonsterBook.Application.Common.AttackType;
using Material = Mithrill.MonsterBook.Application.Common.Material;

namespace Mithrill.MonsterBook.Application.Npc.Command.CreateNpcTemplate;

public class Weapon : IMapTo<MonsterBook.Domain.CharacterWeapon>
{
    public Weapon()
    {
        AdditionalAttackTypes = new List<AttackType>();
    }

    public int Id { get; set; }
    public Material Material { get; set; }
    public int AdditionalAttackModifier { get; set; }
    public int AdditionalDefenseModifier { get; set; }
    public int AdditionalInitiativeModifier { get; set; }
    public bool IsOptional { get; set; }
    public IEnumerable<AttackType> AdditionalAttackTypes { get; set; }

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

public class CustomAttackTypeMapping : IValueResolver<Weapon, MonsterBook.Domain.CharacterWeapon, ICollection<MonsterBook.Domain.CharacterWeaponAttackType>>
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