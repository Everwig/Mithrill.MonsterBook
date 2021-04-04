using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Domain
{
    internal class Skill : ISkill, IMapFrom<MonsterBook.Domain.Skill>
    {
        public int Name { get; set; }
        public int Level { get; set; }
        public SkillCategories Category { get; set; }
    }
}