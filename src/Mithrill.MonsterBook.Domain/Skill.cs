namespace Mithrill.MonsterBook.Domain
{
    public class Skill
    {
        public Skill(int id, string name, int level, string attributeTwo, string attributeOne)
        {
            Id = id;
            Name = name;
            Level = level;
            AttributeTwo = attributeTwo;
            AttributeOne = attributeOne;
        }

        public int Id { get; }
        public string Name { get; }
        public int Level { get; }
        public string AttributeOne { get; }
        public string AttributeTwo { get; }
    }
}