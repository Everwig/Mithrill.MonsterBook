using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Domain;

internal class Flaw : IMapFrom<MonsterBook.Domain.Entities.Flaw>
{
    public int Id { get; set; }
    public string Name { get; set; }
}