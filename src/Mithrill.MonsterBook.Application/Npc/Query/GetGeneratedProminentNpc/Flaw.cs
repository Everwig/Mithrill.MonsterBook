using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedProminentNpc
{
    public class Flaw : IMeritFlaw, IMapFrom<Domain.Flaw>
    {
        public string Name { get; set; }
        public string NameHu { get; set; }
    }
}