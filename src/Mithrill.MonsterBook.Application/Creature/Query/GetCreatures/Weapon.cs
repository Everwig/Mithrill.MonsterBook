using System.Collections.Generic;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures;

public class Weapon : IMapFrom<MonsterBook.Domain.CreatureWeapon>
{
    public Weapon()
    {
        AttackTypes = new List<AttackType>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int AttackModifier { get; set; }
    public int DefenseModifier { get; set; }
    public int InitiativeModifier { get; set; }
    public Material Material { get; set; }
    public IEnumerable<AttackType> AttackTypes { get; set; }
    public bool IsOptional { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.CreatureWeapon, Weapon>()
            .ForMember(weapon => weapon.Id, opt => opt.MapFrom(creatureWeapon => creatureWeapon.WeaponId))
            .ForMember(weapon => weapon.Name, opt => opt.MapFrom(creatureWeapon => creatureWeapon.Weapon.Name))
            .ForMember(weapon => weapon.AttackModifier,
                opt => opt.MapFrom(creatureWeapon =>
                    creatureWeapon.Weapon.BaseAttackModifier + creatureWeapon.AdditionalAttackModifier))
            .ForMember(weapon => weapon.DefenseModifier,
                opt => opt.MapFrom(creatureWeapon =>
                    creatureWeapon.Weapon.BaseDefenseModifier + creatureWeapon.AdditionalDefenseModifier))
            .ForMember(weapon => weapon.InitiativeModifier,
                opt => opt.MapFrom(creatureWeapon =>
                    creatureWeapon.Weapon.BaseInitiativeModifier + creatureWeapon.AdditionalInitiativeModifier))
            .ForMember(weapon => weapon.AttackTypes, opt => opt.Ignore());
    }
}