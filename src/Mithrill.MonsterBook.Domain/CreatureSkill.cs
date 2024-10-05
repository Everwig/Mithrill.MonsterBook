namespace Mithrill.MonsterBook.Domain
{
    public class CreatureSkill
    {
        public int SkillLevelMin { get; set; }
        public int SkillLevelMax { get; set; }
        public int GuaranteedSuccesses { get; set; }
        public bool IsOptional { get; set; }

        public int CreatureId { get; set; }
        public Creature Creature { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}