using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Builders;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetManaPointMinMaxValues;

internal sealed class GetManaPointMinMaxValuesQueryHandler
    : IRequestHandler<GetManaPointMinMaxValuesQuery, (int ManaPointMin, int ManaPointMax)>
{
    private readonly IMonsterBookDbContext _monsterBookDbContext;

    public GetManaPointMinMaxValuesQueryHandler(IMonsterBookDbContext monsterBookDbContext)
    {
        _monsterBookDbContext = monsterBookDbContext;
    }

    public async Task<(int ManaPointMin, int ManaPointMax)> Handle(GetManaPointMinMaxValuesQuery request, CancellationToken cancellationToken)
    {
        var merits = new List<MonsterBook.Domain.Merit>();

        if (request.MeritIds.Any())
        {
            merits = await _monsterBookDbContext.Merits.Where(merit => request.MeritIds.Contains(merit.Id))
                .ToListAsync(cancellationToken);
        }

        var manaPointMin = Calculators.CalculateManaPoints(
            request.IntelligenceMin,
            request.WillpowerMin,
            request.EmotionMin,
            merits);

        var manaPointMax = Calculators.CalculateManaPoints(
            request.IntelligenceMax,
            request.WillpowerMax,
            request.EmotionMax,
            merits);

        return (manaPointMin, manaPointMax);
    }
}