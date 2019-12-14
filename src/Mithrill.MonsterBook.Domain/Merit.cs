namespace Mithrill.MonsterBook.Domain
{
    public class Merit
    {
        public Merit(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}