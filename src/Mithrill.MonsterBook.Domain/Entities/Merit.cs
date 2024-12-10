using System.Collections.Generic;
using Mithrill.MonsterBook.Domain.ValueObjects;

namespace Mithrill.MonsterBook.Domain.Entities;

public class Merit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameHu { get; set; }

    public ICollection<CharacterMerit> CreatureMerits { get; set; }
}