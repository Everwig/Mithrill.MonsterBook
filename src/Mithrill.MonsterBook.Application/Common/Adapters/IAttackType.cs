namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface IAttackType
    {
        DamageType DamageType { get; }
        int NumberOfDices { get; }
        int GuaranteedDamage { get; }
    }
}