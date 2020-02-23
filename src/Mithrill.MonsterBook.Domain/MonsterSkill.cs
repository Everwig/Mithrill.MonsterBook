namespace Mithrill.MonsterBook.Domain
{
    public class MonsterSkill
    {
        public int MonsterId { get; set; }
        public Monster Monster { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}