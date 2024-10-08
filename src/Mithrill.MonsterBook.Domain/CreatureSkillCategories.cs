namespace Mithrill.MonsterBook.Domain
{
    public class CreatureSkillCategories
    {
        public int Id { get; set; }
        public SkillCategory Primary { get; set; }
        public SkillCategory FirstSecondary { get; set; }
        public SkillCategory SecondSecondary { get; set; }
        public SkillCategory Tertiary { get; set; }

        public int CreatureId { get; set; }
        public Creature Creature { get; set; }
    }
}