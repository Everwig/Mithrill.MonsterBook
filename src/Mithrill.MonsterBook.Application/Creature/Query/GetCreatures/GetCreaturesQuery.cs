using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures
{
    public class GetCreaturesQuery : IRequest<IEnumerable<Creature>>
    {
    }
}