using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class Encounter
    {
        public Encounter(int id, IEnumerable<Monster> monsters, Difficulty difficulty)
        {
            Id = id;
            Monsters = monsters;
            Difficulty = difficulty;
        }

        public int Id { get; }
        public IEnumerable<Monster> Monsters { get; }
        public Difficulty Difficulty { get; }
    }
}