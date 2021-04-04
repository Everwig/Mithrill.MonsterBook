using Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;

namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface IWeapon
    {
        int Name { get; }
        AttackType AttackType { get; }
    }
}