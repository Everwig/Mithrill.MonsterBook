using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class Weapon
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public AttackType AttackType { get; set; }

        public ICollection<CreatureWeapon> CreatureWeapons { get; set; }
    }
}