namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface IWeapon
    {
        int Name { get; }
        IAttackType AttackType { get; }
    }
}