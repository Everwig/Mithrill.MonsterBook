using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds
{
    public static class Weapons
    {
        public static Task AddOrUpdateWeapons(DbContext dbContext)
        {
            return dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Weapon { Id = 1, Name = "Javelin", NameHu = "Dárda" },
                new Weapon { Id = 2, Name = "Spear", NameHu = "Lándzsa" },
                new Weapon { Id = 3, Name = "Throwing knife", NameHu = "Dobótőr" },
                new Weapon { Id = 4, Name = "Throwing axe", NameHu = "Hajító bárd" },
                new Weapon { Id = 5, Name = "Throwing star", NameHu = "Hajító csillag" },
                new Weapon { Id = 6, Name = "Harpoon", NameHu = "Szigony" },
                new Weapon { Id = 7, Name = "Blow pipe", NameHu = "Fúvócső" },
                new Weapon { Id = 8, Name = "Crossbow", NameHu = "Nyílpuska" },
                new Weapon { Id = 9, Name = "Heavy crossbow", NameHu = "Nehéz nyílpuska" },
                new Weapon { Id = 10, Name = "Sling", NameHu = "Parittya" },
                new Weapon { Id = 11, Name = "Short stick bow", NameHu = "Rövid bot íj" },
                new Weapon { Id = 12, Name = "Long stick bow", NameHu = "Hosszú bot íj" },
                new Weapon { Id = 13, Name = "Short propped bow", NameHu = "Rövid támasztott íj" },
                new Weapon { Id = 14, Name = "Long propped bow", NameHu = "Hosszú támasztott íj" },
                new Weapon { Id = 15, Name = "Short plywood bow", NameHu = "Rövid rétegelt íj" },
                new Weapon { Id = 16, Name = "Long plywood bow", NameHu = "Hosszú támasztott íj" },
                new Weapon { Id = 17, Name = "Short compound bow", NameHu = "Rövid összetett íj" },
                new Weapon { Id = 18, Name = "Long compound bow", NameHu = "Hosszú összetett íj" },
                new Weapon { Id = 19, Name = "Short elven bow", NameHu = "Rövid tünde íj" },
                new Weapon { Id = 20, Name = "Long elven bow", NameHu = "Hosszú tünde íj" },
                new Weapon { Id = 21, Name = "One-handed battle axe", NameHu = "Egykezes csatabárd" },
                new Weapon { Id = 22, Name = "Two-handed battle axe", NameHu = "Többkezes csatabárd" },
                new Weapon { Id = 23, Name = "Short sword", NameHu = "Rövid kard" },
                new Weapon { Id = 24, Name = "Long sword", NameHu = "Hosszú  kard" },
                new Weapon { Id = 25, Name = "Bastard sword", NameHu = "Másfél kezes kard" },
                new Weapon { Id = 26, Name = "Broadsword", NameHu = "Pallós" },
                new Weapon { Id = 27, Name = "Sabre", NameHu = "Szablya" },
                new Weapon { Id = 28, Name = "Knife", NameHu = "Kés" },
                new Weapon { Id = 29, Name = "Dagger", NameHu = "Tőr" },
                new Weapon { Id = 30, Name = "Fencing sword", NameHu = "Tőrkard" },
                new Weapon { Id = 31, Name = "Staff", NameHu = "Bot" },
                new Weapon { Id = 32, Name = "One-handed mace", NameHu = "Egykezes buzogány" },
                new Weapon { Id = 33, Name = "Two-handed mace", NameHu = "Kétkezes buzogány" },
                new Weapon { Id = 34, Name = "Chained mace", NameHu = "Láncos buzogány" },
                new Weapon { Id = 35, Name = "Combat hammer", NameHu = "Harci kalapács" },
                new Weapon { Id = 36, Name = "Halberd", NameHu = "Alabárd" },
                new Weapon { Id = 37, Name = "Lance", NameHu = "Lándzsa" },
                new Weapon { Id = 38, Name = "Equestrian lance", NameHu = "Lovas kopja" },
                new Weapon { Id = 39, Name = "Garotte", NameHu = "Garott" },
                new Weapon { Id = 40, Name = "Bite", NameHu = "Harapás" },
                new Weapon { Id = 41, Name = "Heavy Bite", NameHu = "Nehéz Harapás" },
                new Weapon { Id = 42, Name = "Mythic Bite", NameHu = "Mítikus Harapás" },
                new Weapon { Id = 43, Name = "Claws", NameHu = "Karmok" },
                new Weapon { Id = 44, Name = "Heavy Claws", NameHu = "Nehéz karmok" },
                new Weapon { Id = 45, Name = "Mythic Claws", NameHu = "Mítikus karmok" },
                new Weapon { Id = 46, Name = "Poison body", NameHu = "Mérgező test" },
                new Weapon { Id = 47, Name = "Death Touch", NameHu = "Halálos érintés" },
                new Weapon { Id = 48, Name = "Tentacle", NameHu = "Csáp" }
            });
        }
    }
}