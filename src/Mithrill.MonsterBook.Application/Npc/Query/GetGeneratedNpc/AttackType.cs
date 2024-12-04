using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;

public class AttackType : IMapFrom<Common.AttackType>
{
    public DamageType DamageType { get; set; }
    public int NumberOfDices { get; set; }
    public int GuaranteedDamage { get; set; }
}