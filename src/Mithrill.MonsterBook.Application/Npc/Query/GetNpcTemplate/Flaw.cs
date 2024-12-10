using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain;
using Mithrill.MonsterBook.Domain.ValueObjects;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate;

public sealed record Flaw(
    int Id,
    string Name,
    bool IsOptional
) : IMapFrom<CharacterFlaw>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CharacterFlaw, Flaw>()
            .ForCtorParam(ctorParamName: nameof(Id), opt => opt.MapFrom(creature => creature.FlawId))
            .ForCtorParam(ctorParamName: nameof(Name), opt => opt.MapFrom(creature => creature.Flaw.Name))
            .ForCtorParam(ctorParamName: nameof(IsOptional), opt => opt.MapFrom(creature => creature.IsOptional));
    }
}