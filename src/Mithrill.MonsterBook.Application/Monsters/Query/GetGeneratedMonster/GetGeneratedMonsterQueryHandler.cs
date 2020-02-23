using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Monsters.Query.GetGeneratedMonster
{
    internal class GetGeneratedMonsterQueryHandler : IRequestHandler<GetGeneratedMonsterQuery, GeneratedMonster>
    {
        private readonly IMonsterBookDbContext _monsterBookDbContext;
        private readonly IMonsterFactory _monsterFactory;

        public GetGeneratedMonsterQueryHandler(IMonsterBookDbContext monsterBookDbContext, IMonsterFactory monsterFactory)
        {
            _monsterBookDbContext = monsterBookDbContext;
            _monsterFactory = monsterFactory;
        }

        public async Task<GeneratedMonster> Handle(GetGeneratedMonsterQuery request, CancellationToken cancellationToken)
        {
            var monster = await _monsterBookDbContext.Monsters
                .Where(m => m.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            return monster == null ? null : _monsterFactory.CreateMonster(monster);
        }
    }
}