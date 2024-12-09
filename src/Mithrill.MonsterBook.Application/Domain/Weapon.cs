using System.Collections.Generic;
using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Domain;

internal class Weapon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Material Material { get; set; }
    public int BaseAttackModifier { get; set; }
    public int BaseDefenseModifier { get; set; }
    public int BaseInitiativeModifier { get; set; }
    public int AdditionalInitiativeModifier { get; set; }
    public int AdditionalAttackModifier { get; set; }
    public int AdditionalDefenseModifier { get; set; }
    public AttackType AttackType { get; set; }
    public IEnumerable<AttackType> AttackTypes { get; set; }
}