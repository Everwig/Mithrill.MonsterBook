using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedProminentNpc
{
    public class Weapon : IWeapon, IMapFrom<Domain.Weapon>
    {
        public string Name { get; set; }
        public IAttackType AttackType { get; set; }
    }
}