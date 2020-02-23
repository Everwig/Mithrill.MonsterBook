namespace Mithrill.MonsterBook.Domain
{
    public class MonsterWeapon
    {
        public int MonsterId { get; set; }
        public Monster Monster { get; set; }
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
    }
}