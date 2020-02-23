using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class Weapon
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public AttackType AttackType { get; set; }

        public ICollection<MonsterWeapon> MonsterWeapons { get; set; }
    }
}