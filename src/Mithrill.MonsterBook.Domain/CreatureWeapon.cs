using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class CreatureWeapon
    {
        public int CreatureId { get; set; }
        public Creature Creature { get; set; }
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
        public ICollection<CreatureWeaponAttackType> AdditionalAttackTypes { get; set; }
        
        public Material Material { get; set; }
        public int AdditionalAttackModifier { get; set; }
        public int AdditionalDefenseModifier { get; set; }
        public int AdditionalInitiativeModifier { get; set; }
        public bool IsOptional { get; set; }
    }
}