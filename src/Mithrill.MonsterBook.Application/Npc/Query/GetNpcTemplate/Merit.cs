using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain;
using Mithrill.MonsterBook.Domain.ValueObjects;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate;

public sealed record Merit(
    int Id,
    string Name,
    bool IsOptional
) : IMapFrom<CharacterMerit>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CharacterMerit, Merit>()
            .ForCtorParam(ctorParamName: nameof(Id), opt => opt.MapFrom(creature => creature.MeritId))
            .ForCtorParam(ctorParamName: nameof(Name), opt => opt.MapFrom(creature => creature.Merit.Name))
            .ForCtorParam(ctorParamName: nameof(IsOptional), opt => opt.MapFrom(creature => creature.IsOptional));
    }
}