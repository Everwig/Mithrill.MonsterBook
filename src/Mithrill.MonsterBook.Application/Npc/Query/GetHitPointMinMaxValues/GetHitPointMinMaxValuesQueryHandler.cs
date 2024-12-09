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
        var meritNames = new List<string>();

        if (request.MeritIds.Any())
        {
            meritNames = await _monsterBookDbContext.Merits.Where(merit => request.MeritIds.Contains(merit.Id))
                .Select(merit => merit.Name)
                .ToListAsync(cancellationToken);
        }

        var hitPointMin = Calculators.CalculateHitPoints(
            request.StrengthMin,
            request.BodyMin,
            request.IsUndead,
            meritNames);

        var hitPointMax = Calculators.CalculateHitPoints(
            request.StrengthMax,
            request.BodyMax,
            request.IsUndead,
            meritNames);

        return (hitPointMin, hitPointMax);
    }
}