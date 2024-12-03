using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Weapons.Query.GetAllForNpcTemplates;

public sealed record AttackType (
    int Id,
    DamageType DamageType,
    int NumberOfDices,
    int GuaranteedDamage
) : IMapFrom<MonsterBook.Domain.AttackType>;