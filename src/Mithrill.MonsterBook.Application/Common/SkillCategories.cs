using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Common
{
    public class SkillCategories :
        IMapFrom<MonsterBook.Domain.CharacterSkillCategories>,
        IMapTo<MonsterBook.Domain.CharacterSkillCategories>
    {
        public SkillCategory Primary { get; set; }
        public SkillCategory FirstSecondary { get; set; }
        public SkillCategory SecondSecondary { get; set; }
        public SkillCategory Tertiary { get; set; }

        void IMapTo<MonsterBook.Domain.CharacterSkillCategories>.Mapping(Profile profile)
        {
            profile.CreateMap<SkillCategories, MonsterBook.Domain.CharacterSkillCategories>()
                .ForMember(skillCategory => skillCategory.NpcTemplateId, opt => opt.Ignore())
                .ForMember(skillCategory => skillCategory.Id, opt => opt.Ignore())
                .ForMember(skillCategory => skillCategory.NpcTemplate, opt => opt.Ignore());
        }
    }
}