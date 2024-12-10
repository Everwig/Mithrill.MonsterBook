using MediatR;
using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;

public sealed record GetGeneratedNpcQuery(
    int Id,
    bool IsProminent,
    bool HasKarma,
    bool IsEvil,
    bool IsUndead,
    Difficulty? Difficulty) :
    IRequest<GeneratedNpc>;