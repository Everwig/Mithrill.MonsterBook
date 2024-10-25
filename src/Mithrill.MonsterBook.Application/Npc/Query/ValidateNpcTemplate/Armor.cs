using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

public class Armor
{
    public int Id { get; set; }
    public Material Material { get; set; }
    public int AdditionalArmorClass { get; set; }
    public int AdditionalMovementInhibitoryFactor { get; set; }
    public bool IsOptional { get; set; }
}