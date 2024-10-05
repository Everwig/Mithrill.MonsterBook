using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Domain
{
    internal class AttackType : IAttackType, IMapFrom<MonsterBook.Domain.AttackType>
    {
        public DamageType DamageType { get; set; }
        public int NumberOfDices { get; set; }
        public int GuaranteedDamage { get; set; }
    }
}