using MediatR;
using System.Collections.Generic;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetHitPointMinMaxValues;

public sealed record GetHitPointMinMaxValuesQuery(
    int StrengthMin,
    int StrengthMax,
    int BodyMin,
    int BodyMax,
    bool IsUndead,
    HashSet<int> MeritIds
) : IRequest<(int HitPointMin, int HitPointMax)>;