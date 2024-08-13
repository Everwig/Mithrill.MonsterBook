using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures;

public class Armor : IMapFrom<MonsterBook.Domain.CreatureArmor>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Material Material { get; set; }
    public int ArmorClass { get; set; }
    public int MovementInhibitoryFactor { get; set; }
    public bool IsOptional { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.CreatureArmor, Armor>()
            .ForMember(armor => armor.Id, opt => opt.MapFrom(creatureArmor => creatureArmor.ArmorId))
            .ForMember(armor => armor.Name, opt => opt.MapFrom(creatureArmor => creatureArmor.Armor.Name))
            .ForMember(armor => armor.ArmorClass,
                opt => opt.MapFrom(creatureArmor =>
                    creatureArmor.Armor.BaseArmorClass + creatureArmor.AdditionalArmorClass))
            .ForMember(armor => armor.MovementInhibitoryFactor,
                opt => opt.MapFrom(creatureArmor => creatureArmor.Armor.BaseMovementInhibitoryFactor +
                                                    creatureArmor.AdditionalMovementInhibitoryFactor));
    }
}