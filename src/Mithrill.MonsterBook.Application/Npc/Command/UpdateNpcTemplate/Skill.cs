using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate;

public record Skill(
    int Id,
    int MinLevel,
    int MaxLevel,
    int GuaranteedSuccesses,
    bool IsOptional) : IMapTo<CharacterSkill>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Skill, CharacterSkill>()
            .ForMember(characterSkill => characterSkill.NpcTemplateId, opt => opt.Ignore())
            .ForMember(characterSkill => characterSkill.NpcTemplate, opt => opt.Ignore())
            .ForMember(characterSkill => characterSkill.Skill, opt => opt.Ignore())
            .ForMember(characterSkill => characterSkill.SkillId, opt => opt.MapFrom(skill => skill.Id))
            .ForMember(characterSkill => characterSkill.SkillLevelMin, opt => opt.MapFrom(skill => skill.MinLevel))
            .ForMember(characterSkill => characterSkill.SkillLevelMax, opt => opt.MapFrom(skill => skill.MaxLevel));
    }
}