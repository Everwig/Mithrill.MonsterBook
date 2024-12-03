using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Weapons.Query.GetAllAttackTypes;

internal sealed class GetAllAttackTypesQueryHandler : IRequestHandler<GetAllAttackTypesQuery, IEnumerable<AttackType>>
{
    private readonly IMonsterBookDbContext _monsterBookDbContext;
    private readonly IMapper _mapper;

    public GetAllAttackTypesQueryHandler(IMonsterBookDbContext monsterBookDbContext, IMapper mapper)
    {
        _monsterBookDbContext = monsterBookDbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AttackType>> Handle(GetAllAttackTypesQuery request, CancellationToken cancellationToken)
    {
        var attackTypes = await _monsterBookDbContext.AttackTypes.ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<AttackType>>(attackTypes);
    }
}