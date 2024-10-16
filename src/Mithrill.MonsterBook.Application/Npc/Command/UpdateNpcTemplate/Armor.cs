using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate;

public class Armor : IMapTo<MonsterBook.Domain.CharacterArmor>
{
    public int Id { get; set; }
    public Material Material { get; set; }
    public int AdditionalArmorClass { get; set; }
    public int AdditionalMovementInhibitoryFactor { get; set; }
    public bool IsOptional { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Armor, MonsterBook.Domain.CharacterArmor>()
            .ForMember(characterArmor => characterArmor.Armor, opt => opt.Ignore())
            .ForMember(characterArmor => characterArmor.NpcTemplateId, opt => opt.Ignore())
            .ForMember(characterArmor => characterArmor.NpcTemplate, opt => opt.Ignore())
            .ForMember(characterArmor => characterArmor.ArmorId, opt => opt.MapFrom(armor => armor.Id));
    }
}