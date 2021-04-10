using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Domain
{
    internal class AttackType : IAttackType, IMapFrom<MonsterBook.Domain.AttackType>
    {
        public string Name { get; set; }
        public int NumberOfDice { get; set; }
        public int ExtraDamage { get; set; }
    }
}