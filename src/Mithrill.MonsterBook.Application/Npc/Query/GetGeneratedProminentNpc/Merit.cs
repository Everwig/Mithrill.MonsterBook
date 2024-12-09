using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedProminentNpc;

public class Merit : IMapFrom<Domain.Merit>
{
    public string Name { get; set; }
}