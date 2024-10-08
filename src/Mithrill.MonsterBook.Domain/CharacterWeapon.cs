using System.Collections.Generic;

namespace Mithrill.MonsterBook.Domain
{
    public class CharacterWeapon
    {
        public int NpcTemplateId { get; set; }
        public NpcTemplate NpcTemplate { get; set; }
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
        public ICollection<CharacterWeaponAttackType> AdditionalAttackTypes { get; set; }
        
        public Material Material { get; set; }
        public int AdditionalAttackModifier { get; set; }
        public int AdditionalDefenseModifier { get; set; }
        public int AdditionalInitiativeModifier { get; set; }
        public bool IsOptional { get; set; }
    }
}