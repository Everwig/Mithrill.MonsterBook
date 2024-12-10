using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Domain;

internal class Merit : IMapFrom<MonsterBook.Domain.Entities.Merit>
{
    public int Id { get; set; }
    public string Name { get; set; }
}