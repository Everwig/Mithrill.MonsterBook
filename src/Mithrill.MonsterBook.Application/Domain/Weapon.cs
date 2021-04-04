using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Domain
{
    internal class Weapon : IWeapon, IMapFrom<MonsterBook.Domain.Weapon>
    {
        public int Name { get; set; }
        public IAttackType AttackType { get; set; }
    }
}