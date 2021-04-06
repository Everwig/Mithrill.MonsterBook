using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameHu { get; set; }
        public AttackType AttackType { get; set; }

        public ICollection<CreatureWeapon> CreatureWeapons { get; set; }
    }
}