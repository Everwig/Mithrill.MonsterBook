using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate
{
    public class Skill : IMapFrom<MonsterBook.Domain.CreatureSkill>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
        public int GuaranteedSuccesses { get; set; }
        public bool IsOptional { get; set; }
        public Attribute Attribute1 { get; set; }
        public Attribute Attribute2 { get; set; }
        public SkillCategory Category { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MonsterBook.Domain.CreatureSkill, Skill>()
                .ForMember(skill => skill.Id, option => option.MapFrom(creatureSkill => creatureSkill.Skill.Id))
                .ForMember(skill => skill.Name, option => option.MapFrom(creatureSkill => creatureSkill.Skill.Name))
                .ForMember(skill => skill.MinLevel, option => option.MapFrom(creatureSkill => creatureSkill.SkillLevelMin))
                .ForMember(skill => skill.MaxLevel, option => option.MapFrom(creatureSkill => creatureSkill.SkillLevelMax))
                .ForMember(skill => skill.GuaranteedSuccesses, option => option.MapFrom(creatureSkill => creatureSkill.GuaranteedSuccesses))
                .ForMember(skill => skill.IsOptional, option => option.MapFrom(creatureSkill => creatureSkill.IsOptional))
                .ForMember(skill => skill.Attribute1, option => option.MapFrom(creatureSkill => creatureSkill.Skill.Attribute1))
                .ForMember(skill => skill.Attribute2, option => option.MapFrom(creatureSkill => creatureSkill.Skill.Attribute2))
                .ForMember(skill => skill.Category, option => option.MapFrom(creatureSkill => creatureSkill.Skill.Category));
        }
    }
}