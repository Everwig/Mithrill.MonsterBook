using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedSummon;

public sealed record Skill(
    int Id,
    string Name,
    int Level,
    int GuaranteedSuccesses,
    SkillCategory Category,
    int NumberOfDices) : IMapFrom<GeneratedSummon>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Skill, Skill>()
            .ForCtorParam(ctorParamName: nameof(Id), option => option.MapFrom(skill => skill.Id))
            .ForCtorParam(ctorParamName: nameof(Name), option => option.MapFrom(skill => skill.Name))
            .ForCtorParam(ctorParamName: nameof(Level), option => option.MapFrom(skill => skill.Level))
            .ForCtorParam(ctorParamName: nameof(NumberOfDices), option => option.MapFrom(skill => skill.NumberOfDices))
            .ForCtorParam(ctorParamName: nameof(GuaranteedSuccesses), option => option.MapFrom(skill => skill.GuaranteedSuccesses))
            .ForCtorParam(ctorParamName: nameof(Category), option => option.MapFrom(skill => skill.Category));
    }
}