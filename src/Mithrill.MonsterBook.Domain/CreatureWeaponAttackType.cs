namespace Mithrill.MonsterBook.Domain
{
    public class CreatureWeaponAttackType
    {
        public int CreatureId { get; set; }
        public int WeaponId { get; set; }
        public CreatureWeapon CreatureWeapon { get; set; }

        public int AttackTypeId { get; set; }
        public AttackType AttackType { get; set; }
    }
}