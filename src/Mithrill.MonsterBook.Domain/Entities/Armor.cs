using Mithrill.MonsterBook.Domain.ValueObjects;
using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain.Entities;

public class Armor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameHu { get; set; }
    public int BaseArmorClass { get; set; }
    public int BaseMovementInhibitoryFactor { get; set; }

    public ICollection<CharacterArmor> CharacterArmors { get; set; }
}