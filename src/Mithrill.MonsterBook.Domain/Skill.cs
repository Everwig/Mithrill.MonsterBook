﻿using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class Skill
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public SkillCategories Category { get; set; }

        public ICollection<CreatureSkill> CreatureSkills { get; set; }
    }
}