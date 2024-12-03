using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetManaPointMinMaxValues;

public sealed record GetManaPointMinMaxValuesQuery(
    int IntelligenceMin,
    int IntelligenceMax,
    int WillpowerMin,
    int WillpowerMax,
    int EmotionMin,
    int EmotionMax,
    HashSet<int> MeritIds
) : IRequest<(int ManaPointMin, int ManaPointMax)>;