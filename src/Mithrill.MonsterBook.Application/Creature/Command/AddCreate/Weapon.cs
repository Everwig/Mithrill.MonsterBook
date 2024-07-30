using System.Collections.Generic;

namespace Mithrill.MonsterBook.Application.Creature.Command.AddCreate
{
    public class Weapon
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public IEnumerable<int> AdditionalAttackTypes { get; set; }
    }
}