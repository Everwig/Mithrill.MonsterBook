using MediatR;

namespace Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate
{
    public class UpdateNpcTemplateCommand : IRequest
    {
        public int Id { get; set; }
        public NpcTemplate NpcTemplate { get; set; }
    }
}