using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedProminentNpc
{
    public class Skill : ISkill, IMapFrom<Domain.Skill>
    {
        public string Name { get; set; }
        public string NameHu { get; set; }
        public int Level { get; set; }
        public SkillCategories Category { get; set; }
    }
}