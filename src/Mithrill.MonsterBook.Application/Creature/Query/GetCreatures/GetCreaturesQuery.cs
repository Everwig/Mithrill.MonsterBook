using MediatR;
using Mithrill.MonsterBook.Application.Common.SortInformation;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures
{
    public class GetCreaturesQuery : IRequest<GetCreaturesQueryResult>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public SortDirection SortDirection { get; set; }
        public SortProperty SortProperty { get; set; }
    }
}