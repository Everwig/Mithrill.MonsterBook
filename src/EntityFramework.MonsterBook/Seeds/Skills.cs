using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds
{
    public static class Skills
    {
        public static Task AddOrUpdateSkills(DbContext context)
        {
            return context.BulkInsertOrUpdateAsync(new[]
            {
                new Skill { Id  = 1, Name = "Small arms", NameHu = "Könnyű fegyver használat", Category = SkillCategories.Combat, Attribute1 = Attribute.Agility, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 2, Name = "Medium arms", NameHu = "Közepes fegyver használat", Category = SkillCategories.Combat, Attribute1 = Attribute.Agility, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 3, Name = "Medium arms", NameHu = "Közepes fegyver használat", Category = SkillCategories.Combat, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 4, Name = "Heavy arms", NameHu = "Nehéz fegyver használat", Category = SkillCategories.Combat, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 5, Name = "Wrestling", NameHu = "Birkózás", Category = SkillCategories.Combat, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Strength},
                new Skill { Id  = 6, Name = "Aiming", NameHu = "Célzás", Category = SkillCategories.Combat, Attribute1 = Attribute.Dexterity, Attribute2 = Attribute.Willpower},
                new Skill { Id  = 7, Name = "Toughness", NameHu = "Edzettség", Category = SkillCategories.Combat, Attribute1 = Attribute.Body, Attribute2 = Attribute.Willpower},
                new Skill { Id  = 8, Name = "Vigilance", NameHu = "Éberség", Category = SkillCategories.Combat, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 9, Name = "Pain tolerance", NameHu = "Fájdalomtűrés", Category = SkillCategories.Combat, Attribute1 = Attribute.Body, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 10, Name = "Military leadership", NameHu = "Hadvezetés", Category = SkillCategories.Combat, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Willpower},
                new Skill { Id  = 11, Name = "Two-handed fighting", NameHu = "Kétkezes harc", Category = SkillCategories.Combat, Attribute1 = Attribute.Agility, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 12, Name = "Dodge", NameHu = "Kitérés", Category = SkillCategories.Combat, Attribute1 = Attribute.Agility, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 13, Name = "Shield use", NameHu = "Pajzshasználat", Category = SkillCategories.Combat, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 14, Name = "Bare-handed fighting", NameHu = "Pusztakezes harc", Category = SkillCategories.Combat, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 15, Name = "Bare-handed fighting", NameHu = "Pusztakezes harc", Category = SkillCategories.Combat, Attribute1 = Attribute.Agility, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 16, Name = "Wound treatment", NameHu = "Sebgyógyítás", Category = SkillCategories.Combat, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 17, Name = "Blind fight", NameHu = "Vakharc", Category = SkillCategories.Combat, Attribute1 = Attribute.Dexterity, Attribute2 = Attribute.Intelligence},
                new Skill { Id  = 18, Name = "Armor wear", NameHu = "Vértviselet", Category = SkillCategories.Combat, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Strength},

                new Skill { Id  = 19, Name = "Athletics", NameHu = "Atlétika", Category = SkillCategories.Secular, Attribute1 = Attribute.Dexterity, Attribute2 = Attribute.Strength},
                new Skill { Id  = 20, Name = "Etiquette", NameHu = "Etikett", Category = SkillCategories.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 21, Name = "Singing/Music", NameHu = "Ének/Zene", Category = SkillCategories.Secular, Attribute1 = Attribute.Emotion, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 22, Name = "Carriage driving", NameHu = "Fogathajtás", Category = SkillCategories.Secular, Attribute1 = Attribute.Dexterity, Attribute2 = Attribute.Willpower},
                new Skill { Id  = 23, Name = "Sailing", NameHu = "Hajózás", Category = SkillCategories.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 24, Name = "Animal training/taiming", NameHu = "Idomítás/Szelidítés", Category = SkillCategories.Secular, Attribute1 = Attribute.Emotion, Attribute2 = Attribute.Willpower},
                new Skill { Id  = 25, Name = "Intrigue", NameHu = "Intrika", Category = SkillCategories.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 26, Name = "Trading", NameHu = "Kereskedelem", Category = SkillCategories.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Willpower},
                new Skill { Id  = 27, Name = "Riding", NameHu = "Lovaglás", Category = SkillCategories.Secular, Attribute1 = Attribute.Dexterity, Attribute2 = Attribute.Willpower},
                new Skill { Id  = 28, Name = "Craftsmanship", NameHu = "Mesterség", Category = SkillCategories.Secular, Attribute1 = Attribute.Optional, Attribute2 = Attribute.Optional},
                new Skill { Id  = 29, Name = "Tracing and trail hiding", NameHu = "Nyomolvasás/rejtés", Category = SkillCategories.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 30, Name = "Dance", NameHu = "Tánc", Category = SkillCategories.Secular, Attribute1 = Attribute.Dexterity, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 31, Name = "Survival", NameHu = "Túlélés", Category = SkillCategories.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Willpower},

                new Skill { Id  = 32, Name = "Underworld knowledge", NameHu = "Alvilági ismeretek", Category = SkillCategories.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 33, Name = "Camouflaging", NameHu = "Álcázás", Category = SkillCategories.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 34, Name = "Traps/Secret doors", NameHu = "Csapdák és tikos ajtók", Category = SkillCategories.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 35, Name = "Vigilance", NameHu = "Éberség", Category = SkillCategories.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 36, Name = "Poison mixing", NameHu = "Méregkeverés", Category = SkillCategories.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence},
                new Skill { Id  = 37, Name = "Sneaking/Hiding", NameHu = "Osonás", Category = SkillCategories.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 38, Name = "Assassination", NameHu = "Orvgyilkolás", Category = SkillCategories.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 39, Name = "Gambling", NameHu = "Szerencsejáték", Category = SkillCategories.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 40, Name = "Lock picking", NameHu = "Zárnyitás", Category = SkillCategories.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 41, Name = "Pickpocketing", NameHu = "Zsebmetszés", Category = SkillCategories.Underworld, Attribute1 = Attribute.Agility, Attribute2 = Attribute.Dexterity},

                new Skill { Id  = 42, Name = "Alchemy", NameHu = "Alkímia", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 43, Name = "Demonology", NameHu = "Démonológia", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Willpower},
                new Skill { Id  = 44, Name = "Meditation", NameHu = "Elmélyülés", Category = SkillCategories.Scholar, Attribute1 = Attribute.Willpower, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 45, Name = "Physiology", NameHu = "Élettan", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence},
                new Skill { Id  = 46, Name = "Extrasensory Perception", NameHu = "Érzéken túli érzékelés", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 47, Name = "Herbalism", NameHu = "Herbalizmus", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence},
                new Skill { Id  = 48, Name = "Theology", NameHu = "Hittan", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 49, Name = "Prognostication", NameHu = "Jóslás", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 50, Name = "Legendary", NameHu = "Legendaismeret", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 51, Name = "Mechanics", NameHu = "Mechanika", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 52, Name = "Poison mixing", NameHu = "Méregkeverés", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence},
                new Skill { Id  = 53, Name = "Language", NameHu = "Nyelvismeret", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence},
                new Skill { Id  = 54, Name = "Rune magic", NameHu = "Rúnamágia", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 55, Name = "Wound treatment", NameHu = "Sebgyógyítás", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity},
                new Skill { Id  = 56, Name = "Cartography", NameHu = "Térképészet", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence},
                new Skill { Id  = 57, Name = "Will arcane", NameHu = "Akaraterő arkánum", Category = SkillCategories.Scholar, Attribute1 = Attribute.Willpower, Attribute2 = Attribute.Willpower},
                new Skill { Id  = 58, Name = "Emotion arcane", NameHu = "Érzelem arkánum", Category = SkillCategories.Scholar, Attribute1 = Attribute.Emotion, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 59, Name = "Earth arcane", NameHu = "Föld arkánum", Category = SkillCategories.Scholar, Attribute1 = Attribute.Willpower, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 60, Name = "Air arcane", NameHu = "Levegő arkánum", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 61, Name = "Fire arcane", NameHu = "Tűz arkánum", Category = SkillCategories.Scholar, Attribute1 = Attribute.Willpower, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 62, Name = "Water arcane", NameHu = "Víz arkánum", Category = SkillCategories.Scholar, Attribute1 = Attribute.Emotion, Attribute2 = Attribute.Emotion},
                new Skill { Id  = 63, Name = "Time arcane", NameHu = "Idő arkánum", Category = SkillCategories.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence},
                new Skill { Id  = 64, Name = "Path of Light", NameHu = "Jóság ösvénye", Category = SkillCategories.Scholar, Attribute1 = Attribute.Karma, Attribute2 = Attribute.Karma},
                new Skill { Id  = 65, Name = "Path of Dark", NameHu = "Gonoszság ösvénye", Category = SkillCategories.Scholar, Attribute1 = Attribute.Karma, Attribute2 = Attribute.Karma}
            });
        }
    }
}