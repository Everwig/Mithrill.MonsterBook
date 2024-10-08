using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain;
using DamageType = Mithrill.MonsterBook.Application.Domain.DamageType;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate
{
    public class Weapon : IMapFrom<CharacterWeapon>
    {
        public Weapon()
        {
            Name = string.Empty;
            AttackType = new List<AttackType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseAttackModifier { get; set; }
        public int BaseDefenseModifier { get; set; }
        public int BaseInitiativeModifier { get; set; }
        public int AdditionalAttackModifier { get; set; }
        public int AdditionalDefenseModifier { get; set; }
        public int AdditionalInitiativeModifier { get; set; }
        public Common.Material Material { get; set; }
        public bool IsOptional { get; set; }
        public IEnumerable<AttackType> AttackType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CharacterWeapon, Weapon>()
                .ForMember(weapon => weapon.Id, opt => opt.MapFrom(creatureWeapon => creatureWeapon.NpcTemplateId))
                .ForMember(weapon => weapon.Name, opt => opt.MapFrom(creatureWeapon => creatureWeapon.Weapon.Name))
                .ForMember(weapon => weapon.BaseAttackModifier,
                    opt => opt.MapFrom(creatureWeapon => creatureWeapon.Weapon.BaseAttackModifier))
                .ForMember(weapon => weapon.BaseDefenseModifier,
                    opt => opt.MapFrom(creatureWeapon => creatureWeapon.Weapon.BaseDefenseModifier))
                .ForMember(weapon => weapon.BaseInitiativeModifier,
                    opt => opt.MapFrom(creatureWeapon => creatureWeapon.Weapon.BaseInitiativeModifier))
                .ForMember(weapon => weapon.AttackType, opt => opt.MapFrom(creatureWeapon => creatureWeapon.AdditionalAttackTypes.Select(attackType => attackType.AttackType)))
                .AfterMap((creatureWeapon, weapon) => weapon.AttackType.Append(new AttackType
                {
                    IsBaseAttackType = true,
                    DamageType = (DamageType)creatureWeapon.Weapon.BaseAttackType.DamageType,
                    Id = creatureWeapon.Weapon.BaseAttackType.Id,
                    GuaranteedDamage = creatureWeapon.Weapon.BaseAttackType.GuaranteedDamage,
                    NumberOfDices = creatureWeapon.Weapon.BaseAttackType.NumberOfDices
                }));
        }
    }
}