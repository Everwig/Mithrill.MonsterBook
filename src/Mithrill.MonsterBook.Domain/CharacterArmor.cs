namespace Mithrill.MonsterBook.Domain
{
    public class CharacterArmor
    {
        public int NpcTemplateId { get; set; }
        public NpcTemplate NpcTemplate { get; set; }
        public int ArmorId { get; set; }
        public Armor Armor { get; set; }

        public Material Material { get; set; }
        public int AdditionalArmorClass { get; set; }
        public int AdditionalMovementInhibitoryFactor { get; set; }
        public bool IsOptional { get; set; }
    }
}