using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class Merit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameHu { get; set; }

        public ICollection<CharacterMerit> CreatureMerits { get; set; }
    }
}