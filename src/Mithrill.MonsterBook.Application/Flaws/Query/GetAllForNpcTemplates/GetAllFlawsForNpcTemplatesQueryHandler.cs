using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Flaws.Query.GetAllForNpcTemplates
{
    internal sealed class GetAllFlawsForNpcTemplatesQueryHandler : IRequestHandler<GetAllFlawsForNpcTemplatesQuery, IEnumerable<Flaw>>
    {
        private readonly IMapper _mapper;
        private readonly IMonsterBookDbContext _monsterBookDbContext;

        public GetAllFlawsForNpcTemplatesQueryHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
        {
            _mapper = mapper;
            _monsterBookDbContext = monsterBookDbContext;
        }

        public async Task<IEnumerable<Flaw>> Handle(GetAllFlawsForNpcTemplatesQuery request, CancellationToken cancellationToken)
        {
            var flaws = await _monsterBookDbContext.Flaws.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<Flaw>>(flaws);
        }
    }
}