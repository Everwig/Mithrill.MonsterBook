namespace Mithrill.MonsterBook.Domain
{
    public class AttackType
    {
        public AttackType(int id, string name, int numberOfDice, int extraDamage)
        {
            Id = id;
            Name = name;
            NumberOfDice = numberOfDice;
            ExtraDamage = extraDamage;
        }

        public int Id { get; }
        public string Name { get; }
        public int NumberOfDice { get; }
        public int ExtraDamage { get; }
        public int CalculateDamage() => NumberOfDice * 6 + 2;
    }
}