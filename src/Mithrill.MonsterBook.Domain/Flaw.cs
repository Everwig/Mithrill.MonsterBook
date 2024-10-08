using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class Flaw
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameHu { get; set; }

        public ICollection<CharacterFlaw> CreatureFlaws { get; set; }
    }
}