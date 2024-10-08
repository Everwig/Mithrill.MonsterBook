using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Armors.GetAllForNpcTemplates;

public class Armor : IMapFrom<MonsterBook.Domain.Armor>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BaseArmorClass { get; set; }
    public int BaseMovementInhibitoryFactor { get; set; }
}