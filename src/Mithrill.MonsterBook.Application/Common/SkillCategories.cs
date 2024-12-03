using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Common;

public sealed record SkillCategories(
    SkillCategory Primary,
    SkillCategory FirstSecondary,
    SkillCategory SecondSecondary,
    SkillCategory Tertiary) :
    IMapFrom<MonsterBook.Domain.CharacterSkillCategories>,
    IMapTo<MonsterBook.Domain.CharacterSkillCategories>
{
    void IMapTo<MonsterBook.Domain.CharacterSkillCategories>.Mapping(Profile profile)
    {
        profile.CreateMap<SkillCategories, MonsterBook.Domain.CharacterSkillCategories>()
            .ForMember(skillCategory => skillCategory.NpcTemplateId, opt => opt.Ignore())
            .ForMember(skillCategory => skillCategory.Id, opt => opt.Ignore())
            .ForMember(skillCategory => skillCategory.NpcTemplate, opt => opt.Ignore());
    }
}