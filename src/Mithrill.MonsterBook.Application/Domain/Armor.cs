using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Domain;

internal class Armor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Material Material { get; set; }
    public int BaseArmorClass { get; set; }
    public int BaseMovementInhibitoryFactor { get; set; }
    public int AdditionalArmorClass { get; set; }
    public int AdditionalMovementInhibitoryFactor { get; set; }
}