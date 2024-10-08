using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Flaws.Query.GetAllForNpcTemplates;

public class Flaw : IMapFrom<MonsterBook.Domain.Flaw>
{
    public int Id { get; set; }
    public string Name { get; set; }
}