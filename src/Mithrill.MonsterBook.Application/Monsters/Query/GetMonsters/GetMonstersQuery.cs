using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Monsters.Query.GetMonsters
{
    public class GetMonstersQuery : IRequest<IEnumerable<Monster>>
    {
    }
}