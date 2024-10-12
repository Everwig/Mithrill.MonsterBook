using MediatR;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate
{
    public class GetNpcTemplateQuery : IRequest<NpcTemplate>
    {
        public int Id { get; set; }
    }
}