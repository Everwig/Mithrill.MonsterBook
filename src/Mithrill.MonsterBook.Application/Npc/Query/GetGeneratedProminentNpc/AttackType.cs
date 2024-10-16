using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedProminentNpc
{
    public class AttackType : IAttackType, IMapFrom<Common.AttackType>
    {
        public DamageType DamageType { get; }
        public int NumberOfDices { get; set; }
        public int GuaranteedDamage { get; set; }
    }
}