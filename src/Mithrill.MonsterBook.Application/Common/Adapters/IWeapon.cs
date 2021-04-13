namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface IWeapon
    {
        string Name { get; }
        string NameHu { get;}
        IAttackType AttackType { get; }
    }
}