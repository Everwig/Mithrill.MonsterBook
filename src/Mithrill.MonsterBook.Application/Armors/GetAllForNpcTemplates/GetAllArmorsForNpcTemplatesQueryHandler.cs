using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Armors.GetAllForNpcTemplates;

internal sealed class GetAllArmorsForNpcTemplatesQueryHandler : IRequestHandler<GetAllArmorsForNpcTemplatesQuery, IEnumerable<Armor>>
{
    private readonly IMapper _mapper;
    private readonly IMonsterBookDbContext _monsterBookDbContext;

    public GetAllArmorsForNpcTemplatesQueryHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
    {
        _mapper = mapper;
        _monsterBookDbContext = monsterBookDbContext;
    }

    public async Task<IEnumerable<Armor>> Handle(GetAllArmorsForNpcTemplatesQuery request, CancellationToken cancellationToken)
    {
        var armors = await _monsterBookDbContext.Armors.ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<Armor>>(armors);
    }
}