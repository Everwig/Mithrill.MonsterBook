using MediatR;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate;

public sealed record GetNpcTemplateQuery(int Id) : IRequest<NpcTemplate>;