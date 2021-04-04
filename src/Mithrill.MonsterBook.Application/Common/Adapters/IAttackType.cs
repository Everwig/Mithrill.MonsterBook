namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface IAttackType
    {
        string Name { get; }
        int NumberOfDice { get; }
        int ExtraDamage { get; }
    }
}