using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class Skill
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Level { get; set; }

        public ICollection<MonsterSkill> MonsterSkills { get; set; }
    }
}