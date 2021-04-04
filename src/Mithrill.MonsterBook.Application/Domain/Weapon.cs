using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;

namespace Mithrill.MonsterBook.Application.Domain
{
    internal class Weapon : IWeapon
    {
        public int Name { get; set; }
        public AttackType AttackType { get; set; }
    }
}