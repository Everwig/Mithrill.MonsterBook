namespace Mithrill.MonsterBook.Domain
{
    public class CreatureWeapon
    {
        public int MonsterId { get; set; }
        public Creature Creature { get; set; }
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
    }
}