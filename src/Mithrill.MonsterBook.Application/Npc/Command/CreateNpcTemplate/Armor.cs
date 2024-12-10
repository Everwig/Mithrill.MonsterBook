using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain.ValueObjects;
using Material = Mithrill.MonsterBook.Application.Common.Material;

namespace Mithrill.MonsterBook.Application.Npc.Command.CreateNpcTemplate;

public sealed record Armor(
    int Id,
    Material Material,
    int AdditionalArmorClass,
    int AdditionalMovementInhibitoryFactor,
    bool IsOptional) : IMapTo<CharacterArmor>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Armor, CharacterArmor>()
            .ForMember(characterArmor => characterArmor.Armor, opt => opt.Ignore())
            .ForMember(characterArmor => characterArmor.NpcTemplateId, opt => opt.Ignore())
            .ForMember(characterArmor => characterArmor.NpcTemplate, opt => opt.Ignore())
            .ForMember(characterArmor => characterArmor.ArmorId, opt => opt.MapFrom(armor => armor.Id));
    }
}