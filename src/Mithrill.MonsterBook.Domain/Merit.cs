using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class Merit
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public ICollection<MonsterMerit> MonsterMerits { get; set; }
    }
}