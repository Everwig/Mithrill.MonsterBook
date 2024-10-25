using System.Collections.Generic;
using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

public class Weapon
{
    public Weapon()
    {
        AdditionalAttackTypes = new List<AttackType>();
    }

    public int Id { get; set; }
    public Material Material { get; set; }
    public int AdditionalAttackModifier { get; set; }
    public int AdditionalDefenseModifier { get; set; }
    public int AdditionalInitiativeModifier { get; set; }
    public bool IsOptional { get; set; }
    public IEnumerable<AttackType> AdditionalAttackTypes { get; set; }
}