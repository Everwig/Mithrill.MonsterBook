using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds
{
    public static class WeaponsAndArmors
    {
        public static Task AddOrUpdateAttackTypes(DbContext dbContext)
        {
            return dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new AttackType { Id = 1, DamageType = DamageType.Bludgeoning, NumberOfDices = 1, GuaranteedDamage = 0 },
                new AttackType { Id = 2, DamageType = DamageType.Bludgeoning, NumberOfDices = 1, GuaranteedDamage = 2 },
                new AttackType { Id = 3, DamageType = DamageType.Bludgeoning, NumberOfDices = 2, GuaranteedDamage = 2 },
                new AttackType { Id = 4, DamageType = DamageType.Slashing, NumberOfDices = 1, GuaranteedDamage = 0 },
                new AttackType { Id = 5, DamageType = DamageType.Slashing, NumberOfDices = 2, GuaranteedDamage = 2 },
                new AttackType { Id = 6, DamageType = DamageType.Slashing, NumberOfDices = 2, GuaranteedDamage = 2 },
                new AttackType { Id = 7, DamageType = DamageType.Stabbing, NumberOfDices = 1, GuaranteedDamage = 0 },
                new AttackType { Id = 8, DamageType = DamageType.Stabbing, NumberOfDices = 2, GuaranteedDamage = 2 },
                new AttackType { Id = 9, DamageType = DamageType.Stabbing, NumberOfDices = 2, GuaranteedDamage = 2 },
                new AttackType { Id = 10, DamageType = DamageType.Fire, NumberOfDices = 1, GuaranteedDamage = 0 },
                new AttackType { Id = 11, DamageType = DamageType.Fire, NumberOfDices = 2, GuaranteedDamage = 0 },
                new AttackType { Id = 12, DamageType = DamageType.Fire, NumberOfDices = 3, GuaranteedDamage = 0 },
                new AttackType { Id = 13, DamageType = DamageType.Fire, NumberOfDices = 4, GuaranteedDamage = 0 },
                new AttackType { Id = 14, DamageType = DamageType.Fire, NumberOfDices = 5, GuaranteedDamage = 0 },
                new AttackType { Id = 15, DamageType = DamageType.Lightning, NumberOfDices = 1, GuaranteedDamage = 0 },
                new AttackType { Id = 16, DamageType = DamageType.Lightning, NumberOfDices = 2, GuaranteedDamage = 0 },
                new AttackType { Id = 17, DamageType = DamageType.Lightning, NumberOfDices = 3, GuaranteedDamage = 0 },
                new AttackType { Id = 18, DamageType = DamageType.Lightning, NumberOfDices = 4, GuaranteedDamage = 0 },
                new AttackType { Id = 19, DamageType = DamageType.Lightning, NumberOfDices = 5, GuaranteedDamage = 0 },
                new AttackType { Id = 20, DamageType = DamageType.Ice, NumberOfDices = 1, GuaranteedDamage = 0 },
                new AttackType { Id = 21, DamageType = DamageType.Ice, NumberOfDices = 2, GuaranteedDamage = 0 },
                new AttackType { Id = 22, DamageType = DamageType.Ice, NumberOfDices = 3, GuaranteedDamage = 0 },
                new AttackType { Id = 23, DamageType = DamageType.Ice, NumberOfDices = 4, GuaranteedDamage = 0 },
                new AttackType { Id = 24, DamageType = DamageType.Ice, NumberOfDices = 5, GuaranteedDamage = 0 },
                new AttackType { Id = 25, DamageType = DamageType.Light, NumberOfDices = 1, GuaranteedDamage = 0 },
                new AttackType { Id = 26, DamageType = DamageType.Light, NumberOfDices = 2, GuaranteedDamage = 0 },
                new AttackType { Id = 27, DamageType = DamageType.Light, NumberOfDices = 3, GuaranteedDamage = 0 },
                new AttackType { Id = 28, DamageType = DamageType.Light, NumberOfDices = 4, GuaranteedDamage = 0 },
                new AttackType { Id = 29, DamageType = DamageType.Light, NumberOfDices = 5, GuaranteedDamage = 0 },
                new AttackType { Id = 30, DamageType = DamageType.Dark, NumberOfDices = 1, GuaranteedDamage = 0 },
                new AttackType { Id = 31, DamageType = DamageType.Dark, NumberOfDices = 2, GuaranteedDamage = 0 },
                new AttackType { Id = 32, DamageType = DamageType.Dark, NumberOfDices = 3, GuaranteedDamage = 0 },
                new AttackType { Id = 33, DamageType = DamageType.Dark, NumberOfDices = 4, GuaranteedDamage = 0 },
                new AttackType { Id = 34, DamageType = DamageType.Dark, NumberOfDices = 5, GuaranteedDamage = 0 },
                new AttackType { Id = 35, DamageType = DamageType.Stabbing, NumberOfDices = 0, GuaranteedDamage = 1 },
                new AttackType { Id = 36, DamageType = DamageType.Stabbing, NumberOfDices = 1, GuaranteedDamage = 3 },
                new AttackType { Id = 37, DamageType = DamageType.Poison, NumberOfDices = 1, GuaranteedDamage = 0 },
                new AttackType { Id = 38, DamageType = DamageType.None, NumberOfDices = 0, GuaranteedDamage = 0 }
            });
        }

        public static Task AddOrUpdateWeapons(DbContext dbContext)
        {
            return dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Weapon { Id = 1, Name = "Javelin", NameHu = "Dárda", BaseAttackTypeId = 7 },
                new Weapon { Id = 2, Name = "Spear", NameHu = "Lándzsa", BaseAttackTypeId = 8 },
                new Weapon { Id = 3, Name = "Throwing knife", NameHu = "Dobótőr", BaseAttackTypeId = 7 },
                new Weapon { Id = 4, Name = "Throwing axe", NameHu = "Hajító bárd", BaseAttackTypeId = 5 },
                new Weapon { Id = 5, Name = "Throwing star", NameHu = "Hajító csillag", BaseAttackTypeId = 7 },
                new Weapon { Id = 6, Name = "Harpoon", NameHu = "Szigony", BaseAttackTypeId = 8 },
                new Weapon { Id = 7, Name = "Blow pipe", NameHu = "Fúvócső", BaseAttackTypeId = 35 },
                new Weapon { Id = 8, Name = "Crossbow", NameHu = "Nyílpuska", BaseAttackTypeId = 8 },
                new Weapon { Id = 9, Name = "Heavy crossbow", NameHu = "Nehéz nyílpuska", BaseAttackTypeId = 9 },
                new Weapon { Id = 10, Name = "Sling", NameHu = "Parittya", BaseAttackTypeId = 1 },
                new Weapon { Id = 11, Name = "Short stick bow", NameHu = "Rövid bot íj", BaseAttackTypeId = 7 },
                new Weapon { Id = 12, Name = "Long stick bow", NameHu = "Hosszú bot íj", BaseAttackTypeId = 8 },
                new Weapon { Id = 13, Name = "Short propped bow", NameHu = "Rövid támasztott íj", BaseAttackTypeId = 7 },
                new Weapon { Id = 14, Name = "Long propped bow", NameHu = "Hosszú támasztott íj", BaseAttackTypeId = 8 },
                new Weapon { Id = 15, Name = "Short plywood bow", NameHu = "Rövid rétegelt íj", BaseAttackTypeId = 7 },
                new Weapon { Id = 16, Name = "Long plywood bow", NameHu = "Hosszú támasztott íj", BaseAttackTypeId = 8 },
                new Weapon { Id = 17, Name = "Short compound bow", NameHu = "Rövid összetett íj", BaseAttackTypeId = 36 },
                new Weapon { Id = 18, Name = "Long compound bow", NameHu = "Hosszú összetett íj", BaseAttackTypeId = 36 },
                new Weapon { Id = 19, Name = "Short elven bow", NameHu = "Rövid tünde íj", BaseAttackTypeId = 36, BaseAttackModifier = 1 },
                new Weapon { Id = 20, Name = "Long elven bow", NameHu = "Hosszú tünde íj", BaseAttackTypeId = 36, BaseAttackModifier = 1 },
                new Weapon { Id = 21, Name = "One-handed battle axe", NameHu = "Egykezes csatabárd", BaseAttackTypeId = 5 },
                new Weapon { Id = 22, Name = "Two-handed battle axe", NameHu = "Kétkezes csatabárd", BaseAttackTypeId = 6 },
                new Weapon { Id = 23, Name = "Short sword", NameHu = "Rövid kard", BaseAttackTypeId = 4 },
                new Weapon { Id = 24, Name = "Long sword", NameHu = "Hosszú  kard", BaseAttackTypeId = 5 },
                new Weapon { Id = 25, Name = "Bastard sword", NameHu = "Másfél kezes kard", BaseAttackTypeId = 5 },
                new Weapon { Id = 26, Name = "Broadsword", NameHu = "Pallos", BaseAttackTypeId = 6 },
                new Weapon { Id = 27, Name = "Sabre", NameHu = "Szablya", BaseAttackTypeId = 5 },
                new Weapon { Id = 28, Name = "Knife", NameHu = "Kés", BaseAttackTypeId = 4 },
                new Weapon { Id = 29, Name = "Dagger", NameHu = "Tőr", BaseAttackTypeId = 4 },
                new Weapon { Id = 30, Name = "Fencing sword", NameHu = "Tőrkard", BaseAttackTypeId = 4 },
                new Weapon { Id = 31, Name = "Staff", NameHu = "Bot", BaseAttackTypeId = 4 },
                new Weapon { Id = 32, Name = "One-handed mace", NameHu = "Egykezes buzogány", BaseAttackTypeId = 5 },
                new Weapon { Id = 33, Name = "Two-handed mace", NameHu = "Kétkezes buzogány", BaseAttackTypeId = 6 },
                new Weapon { Id = 34, Name = "Chained mace", NameHu = "Láncos buzogány", BaseAttackTypeId = 5 },
                new Weapon { Id = 35, Name = "Combat hammer", NameHu = "Harci kalapács", BaseAttackTypeId = 6 },
                new Weapon { Id = 36, Name = "Halberd", NameHu = "Alabárd", BaseAttackTypeId = 6 },
                new Weapon { Id = 37, Name = "Lance", NameHu = "Lándzsa", BaseAttackTypeId = 5 },
                new Weapon { Id = 38, Name = "Equestrian lance", NameHu = "Lovas kopja", BaseAttackTypeId = 6 },
                new Weapon { Id = 39, Name = "Garotte", NameHu = "Garott", BaseAttackTypeId = 4 },
                new Weapon { Id = 40, Name = "Bite", NameHu = "Harapás", BaseAttackTypeId = 7 },
                new Weapon { Id = 41, Name = "Heavy Bite", NameHu = "Nehéz Harapás", BaseAttackTypeId = 8 },
                new Weapon { Id = 42, Name = "Mythic Bite", NameHu = "Mítikus Harapás", BaseAttackTypeId = 9 },
                new Weapon { Id = 43, Name = "Claws", NameHu = "Karmok", BaseAttackTypeId = 4 },
                new Weapon { Id = 44, Name = "Heavy Claws", NameHu = "Nehéz karmok", BaseAttackTypeId = 5 },
                new Weapon { Id = 45, Name = "Mythic Claws", NameHu = "Mítikus karmok", BaseAttackTypeId = 6 },
                new Weapon { Id = 46, Name = "Poison body", NameHu = "Mérgező test", BaseAttackTypeId = 37 },
                new Weapon { Id = 47, Name = "Death Touch", NameHu = "Halálos érintés", BaseAttackTypeId = 30 },
                new Weapon { Id = 48, Name = "Tentacle", NameHu = "Csáp", BaseAttackTypeId = 1 },
                new Weapon { Id = 49, Name = "Poison breath", NameHu = "Méregező lehelellet", BaseAttackTypeId = 37 },
                new Weapon { Id = 50, Name = "Ice breath", NameHu = "Fagycsóva", BaseAttackTypeId = 20 },
                new Weapon { Id = 51, Name = "Fire breath", NameHu = "Lángcsóva", BaseAttackTypeId = 26 },
                new Weapon { Id = 52, Name = "Poison spit", NameHu = "Méreg köpet", BaseAttackTypeId = 30},
                new Weapon { Id = 53, Name = "Acid spit", NameHu = "Sav köpet", BaseAttackTypeId = 30 },
                new Weapon { Id = 54, Name = "Posionous acid spit", NameHu = "Mérgező sav köpet", BaseAttackTypeId = 37 },
                new Weapon { Id = 55, Name = "Lightning breath", NameHu = "Villámgömb", BaseAttackTypeId = 25 },
                new Weapon { Id = 56, Name = "Horn", NameHu = "Szarv", BaseAttackTypeId = 7 },
                new Weapon { Id = 57, Name = "Small shield", NameHu = "Kis pajzs", BaseAttackTypeId = 1 },
                new Weapon { Id = 58, Name = "Shield", NameHu = "Közepes pajzs", BaseAttackTypeId = 1 },
                new Weapon { Id = 59, Name = "Tower shield", NameHu = "Nagy pajzs", BaseAttackTypeId = 1 },
                new Weapon { Id = 60, Name = "Net", NameHu = "Háló", BaseAttackTypeId = 38 }
            });
        }

        public static Task AddOrUpdateArmors(DbContext dbContext)
        {
            return dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Armor { Id = 1, Name = "Leather Armor", NameHu = "Bőrpáncél", BaseArmorClass = 1 },
                new Armor { Id = 2, Name = "Ring Armor", NameHu = "Gyűrűs vért", BaseArmorClass = 2, BaseMovementInhibitoryFactor = 1},
                new Armor { Id = 3, Name = "Chain shirt", NameHu = "Láncing", BaseArmorClass = 2, BaseMovementInhibitoryFactor = 1 },
                new Armor { Id = 4, Name = "Hauberk", NameHu = "Sodronying", BaseArmorClass = 3, BaseMovementInhibitoryFactor = 1 },
                new Armor { Id = 5, Name = "Scale mail", NameHu = "Pikkelyvért", BaseArmorClass = 3, BaseMovementInhibitoryFactor = 2 },
                new Armor { Id = 6, Name = "Breastplate", NameHu = "Mellvért", BaseArmorClass = 4, BaseMovementInhibitoryFactor = 3 },
                new Armor { Id = 7, Name = "Half plate", NameHu = "Félvért", BaseArmorClass = 5, BaseMovementInhibitoryFactor = 4 },
                new Armor { Id = 8, Name = "Plate", NameHu = "Teljesvért", BaseArmorClass = 6, BaseMovementInhibitoryFactor = 5 },
                new Armor { Id = 9, Name = "Imperial elite plate", NameHu = "Birodalmi elit vért", BaseArmorClass = 7, BaseMovementInhibitoryFactor = 6 },
                new Armor { Id = 10, Name = "Leather warhorse mail", NameHu = "Harci ló bőrvért", BaseArmorClass = 1, BaseMovementInhibitoryFactor = 0 },
                new Armor { Id = 11, Name = "Warhorse chain mail", NameHu = "Harci ló láncvért", BaseArmorClass = 2, BaseMovementInhibitoryFactor = 1 },
                new Armor { Id = 12, Name = "Warhorse heavy scale mail", NameHu = "Nehéz harci ló pikkelyvért", BaseArmorClass = 3, BaseMovementInhibitoryFactor = 2 },
                new Armor { Id = 13, Name = "Warhorse heavy plate", NameHu = "Nehéz harci ló merev vért", BaseArmorClass = 5, BaseMovementInhibitoryFactor = 4 },
                new Armor { Id = 14, Name = "Vambraces", NameHu = "Alkarvédő", BaseArmorClass = 1, BaseMovementInhibitoryFactor = 1 },
                new Armor { Id = 15, Name = "Rerebrace", NameHu = "Felkarvédő", BaseArmorClass = 1, BaseMovementInhibitoryFactor = 1 },
                new Armor { Id = 16, Name = "Pauldron", NameHu = "Válvédő", BaseArmorClass = 1, BaseMovementInhibitoryFactor = 1 },
                new Armor { Id = 17, Name = "Greaves", NameHu = "Lábszárvédő", BaseArmorClass = 1, BaseMovementInhibitoryFactor = 0 },
                new Armor { Id = 18, Name = "Battle skirt", NameHu = "Csataszoknya", BaseArmorClass = 1, BaseMovementInhibitoryFactor = 0 }
            });
        }
    }
}