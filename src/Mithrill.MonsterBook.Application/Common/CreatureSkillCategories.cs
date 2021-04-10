using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Common
{
    public class CreatureSkillCategories : IMapFrom<MonsterBook.Domain.CreatureSkillCategories>
    {
        public SkillCategories Primary { get; set; }
        public SkillCategories FirstSecondary { get; set; }
        public SkillCategories SecondSecondary { get; set; }
        public SkillCategories Tertiary { get; set; }
    }
}