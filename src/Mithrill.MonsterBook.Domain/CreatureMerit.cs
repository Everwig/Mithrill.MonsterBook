namespace Mithrill.MonsterBook.Domain
{
    public class CreatureMerit
    {
        public int MonsterId { get; set; }
        public Creature Creature { get; set; }
        public int MeritId { get; set; }
        public Merit Merit { get; set; }
    }
}