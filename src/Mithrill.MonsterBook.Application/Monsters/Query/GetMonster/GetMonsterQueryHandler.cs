using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Monsters.Query.GetMonster
{
    internal sealed class GetMonsterQueryHandler : IRequestHandler<GetMonsterQuery, Monster>
    {
        private readonly IMapper _mapper;
        private readonly IMonsterBookDbContext _monsterBookDbContext;

        public GetMonsterQueryHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
        {
            _mapper = mapper;
            _monsterBookDbContext = monsterBookDbContext;
        }

        public async Task<Monster> Handle(GetMonsterQuery request, CancellationToken cancellationToken)
        {
            var monster = await _monsterBookDbContext.Monsters
                .Select(m => m.Id)
                .SingleOrDefaultAsync(cancellationToken);

            return _mapper.Map<Monster>(monster);
        }
    }
}