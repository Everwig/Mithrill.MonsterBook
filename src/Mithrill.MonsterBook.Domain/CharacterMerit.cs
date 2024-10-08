namespace Mithrill.MonsterBook.Domain
{
    public class CharacterMerit
    {
        public int NpcTemplateId { get; set; }
        public NpcTemplate NpcTemplate { get; set; }
        public int MeritId { get; set; }
        public Merit Merit { get; set; }
        public bool IsOptional { get; set; }
    }
}