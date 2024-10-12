using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Weapons.Query.GetAllAttackTypes
{
    public class GetAllAttackTypesQuery : IRequest<IEnumerable<AttackType>>
    {
    }
}