namespace Mithrill.MonsterBook.Domain
{
    public class CreatureSkillCategories
    {
        public int Id { get; set; }
        public SkillCategories Primary { get; set; }
        public SkillCategories FirstSecondary { get; set; }
        public SkillCategories SecondSecondary { get; set; }
        public SkillCategories Tertiary { get; set; }

        public int CreatureId { get; set; }
        public Creature Creature { get; set; }
    }
}