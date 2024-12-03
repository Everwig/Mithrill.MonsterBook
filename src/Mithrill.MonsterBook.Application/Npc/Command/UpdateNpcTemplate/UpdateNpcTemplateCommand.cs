using MediatR;

namespace Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate;

public sealed record UpdateNpcTemplateCommand(int Id, NpcTemplate NpcTemplate) : IRequest;