using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures
{
    internal sealed class GetCreaturesQueryHandler : IRequestHandler<GetCreaturesQuery, IEnumerable<Creature>>
    {
        private readonly IMonsterBookDbContext _monsterBookDbContext;

        public GetCreaturesQueryHandler(IMonsterBookDbContext monsterBookDbContext)
        {
            _monsterBookDbContext = monsterBookDbContext;
        }

        public async Task<IEnumerable<Creature>> Handle(GetCreaturesQuery request, CancellationToken cancellationToken)
        {
            return await _monsterBookDbContext.Creatures
                .Select(monster => new Creature(monster.Id, monster.Name))
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);
        }
    }
}