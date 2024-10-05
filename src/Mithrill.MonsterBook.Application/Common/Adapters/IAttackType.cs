namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface IAttackType
    {
        int NumberOfDices { get; }
        int GuaranteedDamage { get; }
    }
}