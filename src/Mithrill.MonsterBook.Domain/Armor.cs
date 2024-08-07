using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class Armor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameHu { get; set; }
        public int BaseArmorClass { get; set; }
        public int MovementInhibitoryFactor { get; set; }

        public ICollection<CreatureArmor> CreatureArmors { get; set; }
    }
}