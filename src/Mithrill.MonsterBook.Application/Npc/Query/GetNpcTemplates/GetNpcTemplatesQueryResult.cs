using System.Collections.Generic;
using Mithrill.MonsterBook.Application.Common.PageInformation;
using Mithrill.MonsterBook.Application.Common.SortInformation;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplates;

public sealed record GetNpcTemplatesQueryResult(
    IEnumerable<Npc> Creatures,
    SortInformation<SortProperty> SortInformation,
    PageInformation PageInformation
);