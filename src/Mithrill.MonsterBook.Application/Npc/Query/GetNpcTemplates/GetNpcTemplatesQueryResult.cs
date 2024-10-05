using System.Collections.Generic;
using Mithrill.MonsterBook.Application.Common.PageInformation;
using Mithrill.MonsterBook.Application.Common.SortInformation;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplates;

public class GetNpcTemplatesQueryResult
{
    public IEnumerable<Npc> Creatures { get; set; }
    public SortInformation<SortProperty> SortInformation { get; set; }
    public PageInformation PageInformation { get; set; }
}