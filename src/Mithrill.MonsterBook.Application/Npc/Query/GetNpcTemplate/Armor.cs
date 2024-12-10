using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain.ValueObjects;
using Material = Mithrill.MonsterBook.Application.Common.Material;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate;

public sealed record Armor(
    int Id,
    string Name,
    int BaseArmorClass,
    int BaseMovementInhibitoryFactor,
    Material Material,
    int AdditionalArmorClass,
    int AdditionalMovementInhibitoryFactor,
    bool IsOptional
) : IMapFrom<CharacterArmor>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CharacterArmor, Armor>()
            .ForCtorParam(ctorParamName: nameof(Id), opt => opt.MapFrom(creatureArmor => creatureArmor.ArmorId))
            .ForCtorParam(ctorParamName: nameof(Name), opt => opt.MapFrom(creatureArmor => creatureArmor.Armor.Name))
            .ForCtorParam(ctorParamName: nameof(BaseArmorClass),
                opt => opt.MapFrom(creatureArmor => creatureArmor.Armor.BaseArmorClass))
            .ForCtorParam(ctorParamName: nameof(BaseMovementInhibitoryFactor),
                opt => opt.MapFrom(creatureArmor => creatureArmor.Armor.BaseMovementInhibitoryFactor))
            .ForCtorParam(ctorParamName: nameof(Material), opt => opt.MapFrom(creatureArmor => creatureArmor.Material))
            .ForCtorParam(ctorParamName: nameof(AdditionalArmorClass),
                opt => opt.MapFrom(creatureArmor => creatureArmor.AdditionalArmorClass))
            .ForCtorParam(ctorParamName: nameof(AdditionalMovementInhibitoryFactor),
                opt => opt.MapFrom(creatureArmor => creatureArmor.AdditionalMovementInhibitoryFactor))
            .ForCtorParam(ctorParamName: nameof(IsOptional),
                opt => opt.MapFrom(creatureArmor => creatureArmor.IsOptional));
    }
}