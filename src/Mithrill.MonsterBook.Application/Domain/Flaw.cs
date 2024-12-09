using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Domain;

internal class Flaw : IMapFrom<MonsterBook.Domain.Flaw>
{
    public string Name { get; set; }
}