using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Domain
{
    internal class Skill : ISkill, IMapFrom<MonsterBook.Domain.Skill>
    {
        public string Name { get; set; }
        public string NameHu { get; set; }
        public int Level { get; set; }
        public SkillCategories Category { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MonsterBook.Domain.Skill, Skill>()
                .ForMember(dest => dest.Level, opt => opt.Ignore());
        }
    }
}