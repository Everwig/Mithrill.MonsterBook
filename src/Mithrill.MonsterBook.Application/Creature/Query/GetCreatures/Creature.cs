namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures
{
    public class Creature
    {
        public Creature(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}