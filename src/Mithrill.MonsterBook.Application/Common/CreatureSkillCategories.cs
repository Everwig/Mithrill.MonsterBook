using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Common
{
    public class CreatureSkillCategories : IMapFrom<MonsterBook.Domain.CreatureSkillCategories>
    {
        public SkillCategory Primary { get; set; }
        public SkillCategory FirstSecondary { get; set; }
        public SkillCategory SecondSecondary { get; set; }
        public SkillCategory Tertiary { get; set; }
    }
}