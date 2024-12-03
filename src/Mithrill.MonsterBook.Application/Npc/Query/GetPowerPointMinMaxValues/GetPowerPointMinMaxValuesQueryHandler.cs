using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mithrill.MonsterBook.Application.Common.Builders;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetPowerPointMinMaxValues;

internal sealed class GetPowerPointMinMaxValuesQueryHandler : IRequestHandler<GetPowerPointMinMaxValuesQuery, (int PowerPointMin, int PowerPointMax)>
{
    public Task<(int PowerPointMin, int PowerPointMax)> Handle(GetPowerPointMinMaxValuesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult((Calculators.CalculatePowerPoints(request.KarmaMin), Calculators.CalculatePowerPoints(request.KarmaMax)));
    }
}