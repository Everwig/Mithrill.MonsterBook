namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface IWeapon
    {
        string Name { get; }
        IAttackType AttackType { get; }
    }
}