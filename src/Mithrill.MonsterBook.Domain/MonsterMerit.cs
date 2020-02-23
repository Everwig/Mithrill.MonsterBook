namespace Mithrill.MonsterBook.Domain
{
    public class MonsterMerit
    {
        public int MonsterId { get; set; }
        public Monster Monster { get; set; }
        public int MeritId { get; set; }
        public Merit Merit { get; set; }
    }
}