using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Weapons.Query.GetAllAttackTypes;

public sealed record GetAllAttackTypesQuery : IRequest<IEnumerable<AttackType>>;