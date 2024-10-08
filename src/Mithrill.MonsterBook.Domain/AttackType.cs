using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class AttackType
    {
        public int Id { get; set; }
        public DamageType DamageType { get; set; }
        public int NumberOfDices { get; set; }
        public int GuaranteedDamage { get; set; }
        
        public ICollection<Weapon> Weapons { get; set; }
        public ICollection<CharacterWeaponAttackType> CharacterWeaponAttackTypes { get; set; }
    }
}