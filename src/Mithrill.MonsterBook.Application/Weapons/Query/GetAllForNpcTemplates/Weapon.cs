using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Weapons.Query.GetAllForNpcTemplates;

public sealed record Weapon (
    int Id,
    string Name,
    int BaseAttackModifier,
    int BaseDefenseModifier,
    int BaseInitiativeModifier,
    AttackType BaseAttackType
) : IMapFrom<MonsterBook.Domain.Weapon>;