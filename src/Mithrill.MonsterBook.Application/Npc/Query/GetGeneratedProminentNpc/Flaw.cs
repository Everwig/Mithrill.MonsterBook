using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedProminentNpc;

public class Flaw : IMapFrom<Domain.Flaw>
{
    public string Name { get; set; }
}