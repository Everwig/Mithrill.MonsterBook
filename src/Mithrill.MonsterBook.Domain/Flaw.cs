using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class Flaw
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public ICollection<CreatureFlaw> CreatureFlaws { get; set; }
    }
}