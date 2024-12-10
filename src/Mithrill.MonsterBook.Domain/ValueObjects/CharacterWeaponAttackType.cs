using Mithrill.MonsterBook.Domain.Entities;

namespace Mithrill.MonsterBook.Domain.ValueObjects;

public class CharacterWeaponAttackType
{
    public int NpcTemplateId { get; set; }
    public int WeaponId { get; set; }
    public CharacterWeapon CharacterWeapon { get; set; }

    public int AttackTypeId { get; set; }
    public AttackType AttackType { get; set; }
}