using MediatR;
using Mithrill.MonsterBook.Application.Common.SortInformation;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplates
{
    public class GetNpcTemplatesQuery : IRequest<GetNpcTemplatesQueryResult>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public SortDirection SortDirection { get; set; }
        public SortProperty SortProperty { get; set; }
    }
}