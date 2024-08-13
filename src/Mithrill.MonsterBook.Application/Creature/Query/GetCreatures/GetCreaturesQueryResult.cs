using System.Collections.Generic;
using Mithrill.MonsterBook.Application.Common.PageInformation;
using Mithrill.MonsterBook.Application.Common.SortInformation;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures;

public class GetCreaturesQueryResult
{
    public IEnumerable<Creature> Creatures { get; set; }
    public SortInformation<SortProperty> SortInformation { get; set; }
    public PageInformation PageInformation { get; set; }
}