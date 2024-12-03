using MediatR;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetPowerPointMinMaxValues;

public sealed record GetPowerPointMinMaxValuesQuery(int KarmaMin, int KarmaMax) : IRequest<(int PowerPointMin, int PowerPointMax)>;