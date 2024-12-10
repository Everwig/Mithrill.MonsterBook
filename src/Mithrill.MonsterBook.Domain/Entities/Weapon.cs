using Mithrill.MonsterBook.Domain.ValueObjects;
using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain.Entities;

public class Weapon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameHu { get; set; }
    public int BaseAttackModifier { get; set; }
    public int BaseDefenseModifier { get; set; }
    public int BaseInitiativeModifier { get; set; }

    public int BaseAttackTypeId { get; set; }
    public AttackType BaseAttackType { get; set; }
    public ICollection<CharacterWeapon> CreatureWeapons { get; set; }
}