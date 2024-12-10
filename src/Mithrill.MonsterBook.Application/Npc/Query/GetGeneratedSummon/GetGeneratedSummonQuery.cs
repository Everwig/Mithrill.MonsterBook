using MediatR;
using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedSummon;

public sealed record GetGeneratedSummonQuery(SummonType Type, int Level) : IRequest<GeneratedSummon>;