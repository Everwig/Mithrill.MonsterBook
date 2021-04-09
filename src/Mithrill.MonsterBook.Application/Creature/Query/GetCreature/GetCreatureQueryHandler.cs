using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreature
{
    internal sealed class GetCreatureQueryHandler : IRequestHandler<GetCreatureQuery, Creature>
    {
        private readonly IMapper _mapper;
        private readonly IMonsterBookDbContext _monsterBookDbContext;

        public GetCreatureQueryHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
        {
            _mapper = mapper;
            _monsterBookDbContext = monsterBookDbContext;
        }

        public async Task<Creature> Handle(GetCreatureQuery request, CancellationToken cancellationToken)
        {
            var monster = await _monsterBookDbContext.Creatures
                .Where(m => m.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            return _mapper.Map<Creature>(monster);
        }
    }
}