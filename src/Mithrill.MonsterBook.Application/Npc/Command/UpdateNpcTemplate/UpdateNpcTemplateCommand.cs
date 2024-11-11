using MediatR;

namespace Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate;

public record UpdateNpcTemplateCommand(int Id, NpcTemplate NpcTemplate) : IRequest;