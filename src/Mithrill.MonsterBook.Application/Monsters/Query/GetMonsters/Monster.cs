namespace Mithrill.MonsterBook.Application.Monsters.Query.GetMonsters
{
    public class Monster
    {
        public Monster(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}