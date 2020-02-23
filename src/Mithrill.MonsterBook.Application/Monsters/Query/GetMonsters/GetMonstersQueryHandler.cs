using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Monsters.Query.GetMonsters
{
    internal sealed class GetMonstersQueryHandler : IRequestHandler<GetMonstersQuery, IEnumerable<Monster>>
    {
        private readonly IMonsterBookDbContext _monsterBookDbContext;

        public GetMonstersQueryHandler(IMonsterBookDbContext monsterBookDbContext)
        {
            _monsterBookDbContext = monsterBookDbContext;
        }

        public async Task<IEnumerable<Monster>> Handle(GetMonstersQuery request, CancellationToken cancellationToken)
        {
            return await _monsterBookDbContext.Monsters
                .Select(monster => new Monster(monster.Id, monster.Name))
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);
        }
    }
}