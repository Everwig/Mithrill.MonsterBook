namespace Mithrill.MonsterBook.Domain
{
    public class CreatureArmor
    {
        public int CreatureId { get; set; }
        public Creature Creature { get; set; }
        public int ArmorId { get; set; }
        public Armor Armor { get; set; }
    }
}