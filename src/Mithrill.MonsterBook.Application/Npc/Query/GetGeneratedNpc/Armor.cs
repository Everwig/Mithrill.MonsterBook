using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;

public sealed record Armor(
    int Id,
    string Name,
    Material Material,
    int BaseArmorClass,
    int BaseMovementInhibitoryFactor,
    int AdditionalArmorClass,
    int AdditionalMovementInhibitoryFactor) : IMapFrom<Domain.Armor>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Armor, Armor>()
            .ForCtorParam(ctorParamName: nameof(Id), opt => opt.MapFrom(armor => armor.Id))
            .ForCtorParam(ctorParamName: nameof(Name), opt => opt.MapFrom(armor => armor.Name))
            .ForCtorParam(ctorParamName: nameof(BaseArmorClass), opt => opt.MapFrom(armor => armor.BaseArmorClass))
            .ForCtorParam(ctorParamName: nameof(BaseMovementInhibitoryFactor),
                opt => opt.MapFrom(armor => armor.BaseMovementInhibitoryFactor))
            .ForCtorParam(ctorParamName: nameof(Material), opt => opt.MapFrom(armor => armor.Material))
            .ForCtorParam(ctorParamName: nameof(AdditionalArmorClass),
                opt => opt.MapFrom(armor => armor.AdditionalArmorClass))
            .ForCtorParam(ctorParamName: nameof(AdditionalMovementInhibitoryFactor),
                opt => opt.MapFrom(armor => armor.AdditionalMovementInhibitoryFactor));
    }
}