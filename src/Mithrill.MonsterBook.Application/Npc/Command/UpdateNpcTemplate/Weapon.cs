using System.Collections.Generic;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate;

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
            .ForMember(characterWeapon => characterWeapon.AdditionalAttackTypes, opt => opt.Ignore());
    }
}