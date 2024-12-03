using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Merits.Query.GetAllForNpcTemplates;

internal sealed class GetAllMeritsForNpcTemplatesQueryHandler : IRequestHandler<GetAllMeritsForNpcTemplatesQuery, IEnumerable<Merit>>
{
    private readonly IMapper _mapper;
    private readonly IMonsterBookDbContext _monsterBookDbContext;

    public GetAllMeritsForNpcTemplatesQueryHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
    {
        _mapper = mapper;
        _monsterBookDbContext = monsterBookDbContext;
    }

    public async Task<IEnumerable<Merit>> Handle(GetAllMeritsForNpcTemplatesQuery request, CancellationToken cancellationToken)
    {
        var skills = await _monsterBookDbContext.Merits.ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<Merit>>(skills);
    }
}