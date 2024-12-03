using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Command.CreateNpcTemplate;

public sealed record Armor(
    int Id,
    Material Material,
    int AdditionalArmorClass,
    int AdditionalMovementInhibitoryFactor,
    bool IsOptional) : IMapTo<MonsterBook.Domain.CharacterArmor>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Armor, MonsterBook.Domain.CharacterArmor>()
            .ForMember(characterArmor => characterArmor.Armor, opt => opt.Ignore())
            .ForMember(characterArmor => characterArmor.NpcTemplateId, opt => opt.Ignore())
            .ForMember(characterArmor => characterArmor.NpcTemplate, opt => opt.Ignore())
            .ForMember(characterArmor => characterArmor.ArmorId, opt => opt.MapFrom(armor => armor.Id));
    }
}