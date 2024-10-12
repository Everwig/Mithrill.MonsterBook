using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application.Weapons.Query.GetAllAttackTypes;

public class AttackType : IMapFrom<MonsterBook.Domain.AttackType>
{
    public int Id { get; set; }
    public DamageType DamageType { get; set; }
    public int NumberOfDices { get; set; }
    public int GuaranteedDamage { get; set; }
}