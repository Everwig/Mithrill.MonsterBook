using MediatR;

namespace Mithrill.MonsterBook.Application.Npc.Command.DeleteNpcTemplate;

public sealed record DeleteNpcTemplateCommand(int TemplateId, bool IsSoftDelete) : IRequest;