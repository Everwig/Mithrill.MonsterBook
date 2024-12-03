using MediatR;
using Mithrill.MonsterBook.Application.Common.SortInformation;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplates;

public sealed record GetNpcTemplatesQuery(
    int PageSize,
    int PageIndex,
    SortDirection SortDirection,
    SortProperty SortProperty
) : IRequest<GetNpcTemplatesQueryResult>;