using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures;

public class Skill : IMapFrom<MonsterBook.Domain.CreatureSkill>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SkillLevelMax { get; set; }
    public int SkillLevelMin { get; set; }
    public int GuaranteedSuccesses { get; set; }
    public bool IsOptional { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.CreatureSkill, Skill>()
            .ForMember(skill => skill.Name, opt => opt.MapFrom(creatureSkill => creatureSkill.Skill.Name))
            .ForMember(skill => skill.Id, opt => opt.MapFrom(creatureSkill => creatureSkill.SkillId));
    }
}