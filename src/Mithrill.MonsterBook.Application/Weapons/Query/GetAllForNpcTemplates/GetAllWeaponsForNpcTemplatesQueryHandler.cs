using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Weapons.Query.GetAllForNpcTemplates;

internal sealed class GetAllWeaponsForNpcTemplatesQueryHandler : IRequestHandler<GetAllWeaponsForNpcTemplatesQuery, IEnumerable<Weapon>>
{
    private readonly IMapper _mapper;
    private readonly IMonsterBookDbContext _monsterBookDbContext;

    public GetAllWeaponsForNpcTemplatesQueryHandler(IMonsterBookDbContext monsterBookDbContext, IMapper mapper)
    {
        _monsterBookDbContext = monsterBookDbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Weapon>> Handle(GetAllWeaponsForNpcTemplatesQuery request, CancellationToken cancellationToken)
    {
        var weapons = await _monsterBookDbContext.Weapons
            .Include(weapon => weapon.BaseAttackType)
            .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<Weapon>>(weapons);
    }
}