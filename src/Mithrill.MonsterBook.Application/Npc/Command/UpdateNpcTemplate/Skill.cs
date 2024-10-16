using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate;

public class Skill : IMapTo<CharacterSkill>
{
    public int Id { get; set; }
    public int MinLevel { get; set; }
    public int MaxLevel { get; set; }
    public int GuaranteedSuccesses { get; set; }
    public bool IsOptional { get; set; }

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