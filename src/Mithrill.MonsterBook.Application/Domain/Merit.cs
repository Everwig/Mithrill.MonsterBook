using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Domain
{
    internal class Merit : IMeritFlaw, IMapFrom<MonsterBook.Domain.Merit>
    {
        public string Name { get; set; }
        public string NameHu { get; set; }
    }
}