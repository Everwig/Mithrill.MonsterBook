using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class AttackType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfDice { get; set; }
        public int ExtraDamage { get; set; }
        public string ExtraDamageType { get; set; }

        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
    }
}