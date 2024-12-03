using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate;

public class Armor : IMapFrom<MonsterBook.Domain.CharacterArmor>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BaseArmorClass { get; set; }
    public int BaseMovementInhibitoryFactor { get; set; }
    public Material Material { get; set; }
    public int AdditionalArmorClass { get; set; }
    public int AdditionalMovementInhibitoryFactor { get; set; }
    public bool IsOptional { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.CharacterArmor, Armor>()
            .ForMember(armor => armor.Id, opt => opt.MapFrom(creatureArmor => creatureArmor.ArmorId))
            .ForMember(armor => armor.Name, opt => opt.MapFrom(creatureArmor => creatureArmor.Armor.Name))
            .ForMember(armor => armor.BaseArmorClass,
                opt => opt.MapFrom(creatureArmor => creatureArmor.Armor.BaseArmorClass))
            .ForMember(armor => armor.BaseMovementInhibitoryFactor,
                opt => opt.MapFrom(creatureArmor => creatureArmor.Armor.BaseMovementInhibitoryFactor));
    }
}