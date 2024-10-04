using MediatR;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate
{
    public class GetNpcTemplateQuery : IRequest<Npc>
    {
        public int Id { get; set; }
    }
}