﻿namespace Mithrill.MonsterBook.Domain
{
    public class CreatureWeapon
    {
        public Material Material { get; set; }
        public int CreatureId { get; set; }
        public Creature Creature { get; set; }
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
    }
}