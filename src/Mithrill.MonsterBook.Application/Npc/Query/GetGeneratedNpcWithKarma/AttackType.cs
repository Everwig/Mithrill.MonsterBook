using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpcWithKarma
{
    public class AttackType : IAttackType, IMapFrom<Domain.AttackType>
    {
        public string Name { get; set; }
        public int NumberOfDice { get; set; }
        public int ExtraDamage { get; set; }
    }
}