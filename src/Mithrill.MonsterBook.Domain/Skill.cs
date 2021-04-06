using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameHu { get; set; }
        public Attribute Attribute1 { get; set; }
        public Attribute Attribute2 { get; set; }
        public SkillCategories Category { get; set; }

        public ICollection<CreatureSkill> CreatureSkills { get; set; }
    }
}