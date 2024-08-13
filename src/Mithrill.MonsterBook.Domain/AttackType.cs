namespace Mithrill.MonsterBook.Domain
{
    public class AttackType
    {
        public int Id { get; set; }
        public DamageType DamageType { get; set; }
        public int NumberOfDices { get; set; }
        public int GuaranteedDamage { get; set; }

        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
    }
}