using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Weapons.Query.GetAllForNpcTemplates;

public class Weapon : IMapFrom<MonsterBook.Domain.Weapon>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BaseAttackModifier { get; set; }
    public int BaseDefenseModifier { get; set; }
    public int BaseInitiativeModifier { get; set; }

    public AttackType BaseAttackType { get; set; }
}