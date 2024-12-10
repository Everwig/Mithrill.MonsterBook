using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;

public sealed record Skill(
    int Id,
    string Name,
    int Level,
    int NumberOfDices,
    int GuaranteedSuccesses) : IMapFrom<Domain.Skill>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Skill, Skill>()
            .ForCtorParam(ctorParamName: nameof(Id), opt => opt.MapFrom(skill => skill.Id))
            .ForCtorParam(ctorParamName: nameof(Name), opt => opt.MapFrom(skill => skill.Name))
            .ForCtorParam(ctorParamName: nameof(Level), opt => opt.MapFrom(skill => skill.Level))
            .ForCtorParam(ctorParamName: nameof(NumberOfDices), opt => opt.MapFrom(skill => skill.NumberOfDices))
            .ForCtorParam(ctorParamName: nameof(GuaranteedSuccesses), opt => opt.MapFrom(skill => skill.GuaranteedSuccesses));
    }
}