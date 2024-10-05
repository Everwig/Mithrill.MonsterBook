using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc
{
    public class AttackType : IAttackType, IMapFrom<Domain.AttackType>
    {
        public int NumberOfDices { get; set; }
        public int GuaranteedDamage { get; set; }
    }
}