namespace Mithrill.MonsterBook.Domain
{
    public class CreatureFlaw
    {
        public int CreatureId { get; set; }
        public Creature Creature { get; set; }
        public int MeritId { get; set; }
        public Flaw Merit { get; set; }
    }
}