using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Domain
{
    internal class Flaw : IMeritFlaw, IMapFrom<MonsterBook.Domain.Flaw>
    {
        public string Name { get; set; }
        public string NameHu { get; set; }
    }
}