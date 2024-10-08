using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate
{
    internal sealed class GetNpcTemplateQueryHandler : IRequestHandler<GetNpcTemplateQuery, Npc>
    {
        private readonly IMapper _mapper;
        private readonly IMonsterBookDbContext _monsterBookDbContext;

        public GetNpcTemplateQueryHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
        {
            _mapper = mapper;
            _monsterBookDbContext = monsterBookDbContext;
        }

        public async Task<Npc> Handle(GetNpcTemplateQuery request, CancellationToken cancellationToken)
        {
            var monster = await _monsterBookDbContext.NpcTemplates
                .Where(m => m.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            return _mapper.Map<Npc>(monster);
        }
    }
}