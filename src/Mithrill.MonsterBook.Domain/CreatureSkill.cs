namespace Mithrill.MonsterBook.Domain
{
    public class CreatureSkill
    {
        public int CreatureId { get; set; }
        public Creature Creature { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}