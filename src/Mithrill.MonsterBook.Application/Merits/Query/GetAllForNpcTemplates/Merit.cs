using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Merits.Query.GetAllForNpcTemplates;

public class Merit : IMapFrom<MonsterBook.Domain.Merit>
{
    public int Id { get; set; }
    public string Name { get; set; }
}