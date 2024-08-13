namespace Mithrill.MonsterBook.Domain
{
    public class CreatureFlaw
    {
        public int CreatureId { get; set; }
        public Creature Creature { get; set; }
        public int FlawId { get; set; }
        public Flaw Flaw { get; set; }
        public bool IsOptional { get; set; }
    }
}