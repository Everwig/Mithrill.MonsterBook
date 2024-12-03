using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Builders;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetHitPointMinMaxValues;

internal sealed class GetHitPointMinMaxValuesQueryHandler
    : IRequestHandler<GetHitPointMinMaxValuesQuery, (int HitPointMin, int HitPointMax)>
{
    private readonly IMonsterBookDbContext _monsterBookDbContext;

    public GetHitPointMinMaxValuesQueryHandler(IMonsterBookDbContext monsterBookDbContext)
    {
        _monsterBookDbContext = monsterBookDbContext;
    }
        
    public async Task<(int HitPointMin, int HitPointMax)> Handle(GetHitPointMinMaxValuesQuery request, CancellationToken cancellationToken)
    {
        var merits = new List<MonsterBook.Domain.Merit>();

        if (request.MeritIds.Any())
        {
            merits = await _monsterBookDbContext.Merits.Where(merit => request.MeritIds.Contains(merit.Id))
                .ToListAsync(cancellationToken);
        }

        var hitPointMin = Calculators.CalculateHitPoints(
            request.StrengthMin,
            request.BodyMin,
            request.IsUndead,
            merits);

        var hitPointMax = Calculators.CalculateHitPoints(
            request.StrengthMax,
            request.BodyMax,
            request.IsUndead,
            merits);

        return (hitPointMin, hitPointMax);
    }
}