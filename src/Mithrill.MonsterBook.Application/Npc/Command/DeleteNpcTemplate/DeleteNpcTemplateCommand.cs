using MediatR;

namespace Mithrill.MonsterBook.Application.Npc.Command.DeleteNpcTemplate
{
    public class DeleteNpcTemplateCommand : IRequest
    {
        public int TemplateId { get; set; }
        public bool IsSoftDelete { get; set; }
    }
}