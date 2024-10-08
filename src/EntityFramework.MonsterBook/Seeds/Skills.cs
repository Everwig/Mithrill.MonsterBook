using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds
{
    public static class Skills
    {
        public static Task AddOrUpdateSkills(DbContext dbContext)
        {
            return dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Skill { Id = 1, Name = "Small arms", NameHu = "Könnyű fegyver használat", Category = SkillCategory.Combat, Attribute1 = Attribute.Agility, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 2, Name = "Medium arms", NameHu = "Közepes fegyver használat", Category = SkillCategory.Combat, Attribute1 = Attribute.Agility, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 3, Name = "Medium arms", NameHu = "Közepes fegyver használat", Category = SkillCategory.Combat, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 4, Name = "Heavy arms", NameHu = "Nehéz fegyver használat", Category = SkillCategory.Combat, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 5, Name = "Wrestling", NameHu = "Birkózás", Category = SkillCategory.Combat, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Strength },
                new Skill { Id = 6, Name = "Aiming", NameHu = "Célzás", Category = SkillCategory.Combat, Attribute1 = Attribute.Dexterity, Attribute2 = Attribute.Willpower },
                new Skill { Id = 7, Name = "Toughness", NameHu = "Edzettség", Category = SkillCategory.Combat, Attribute1 = Attribute.Body, Attribute2 = Attribute.Willpower },
                new Skill { Id = 8, Name = "Vigilance", NameHu = "Éberség", Category = SkillCategory.Combat, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion },
                new Skill { Id = 9, Name = "Pain tolerance", NameHu = "Fájdalomtűrés", Category = SkillCategory.Combat, Attribute1 = Attribute.Body, Attribute2 = Attribute.Emotion },
                new Skill { Id = 10, Name = "Military leadership", NameHu = "Hadvezetés", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Willpower },
                new Skill { Id = 11, Name = "Two-handed fighting", NameHu = "Kétkezes harc", Category = SkillCategory.Combat, Attribute1 = Attribute.Agility, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 12, Name = "Dodge", NameHu = "Kitérés", Category = SkillCategory.Combat, Attribute1 = Attribute.Agility, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 13, Name = "Shield use", NameHu = "Pajzshasználat", Category = SkillCategory.Combat, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 14, Name = "Bare-handed fighting", NameHu = "Pusztakezes harc", Category = SkillCategory.Combat, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 15, Name = "Bare-handed fighting", NameHu = "Pusztakezes harc", Category = SkillCategory.Combat, Attribute1 = Attribute.Agility, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 16, Name = "Wound treatment", NameHu = "Sebgyógyítás", Category = SkillCategory.Combat, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 17, Name = "Blind fight", NameHu = "Vakharc", Category = SkillCategory.Combat, Attribute1 = Attribute.Dexterity, Attribute2 = Attribute.Intelligence },
                new Skill { Id = 18, Name = "Armor wear", NameHu = "Vértviselet", Category = SkillCategory.Combat, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Strength },

                new Skill { Id = 19, Name = "Swimming", NameHu = "Uszás", Category = SkillCategory.Secular, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Willpower },
                new Skill { Id = 20, Name = "Climbing", NameHu = "Mászás", Category = SkillCategory.Secular, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 21, Name = "Running", NameHu = "Futás", Category = SkillCategory.Secular, Attribute1 = Attribute.Willpower, Attribute2 = Attribute.Vitality },
                new Skill { Id = 22, Name = "Jumping", NameHu = "Ugrás", Category = SkillCategory.Secular, Attribute1 = Attribute.Strength, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 23, Name = "Etiquette", NameHu = "Etikett", Category = SkillCategory.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion },
                new Skill { Id = 24, Name = "Singing/Music", NameHu = "Ének/Zene", Category = SkillCategory.Secular, Attribute1 = Attribute.Emotion, Attribute2 = Attribute.Emotion },
                new Skill { Id = 25, Name = "Carriage driving", NameHu = "Fogathajtás", Category = SkillCategory.Secular, Attribute1 = Attribute.Dexterity, Attribute2 = Attribute.Willpower },
                new Skill { Id = 26, Name = "Sailing", NameHu = "Hajózás", Category = SkillCategory.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 27, Name = "Animal training/taiming", NameHu = "Idomítás/Szelidítés", Category = SkillCategory.Secular, Attribute1 = Attribute.Emotion, Attribute2 = Attribute.Willpower },
                new Skill { Id = 28, Name = "Intrigue", NameHu = "Intrika", Category = SkillCategory.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion },
                new Skill { Id = 29, Name = "Trading", NameHu = "Kereskedelem", Category = SkillCategory.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Willpower },
                new Skill { Id = 30, Name = "Riding", NameHu = "Lovaglás", Category = SkillCategory.Secular, Attribute1 = Attribute.Dexterity, Attribute2 = Attribute.Willpower },
                new Skill { Id = 31, Name = "Craftsmanship", NameHu = "Mesterség", Category = SkillCategory.Secular, Attribute1 = Attribute.Optional, Attribute2 = Attribute.Optional },
                new Skill { Id = 32, Name = "Tracing and trail hiding", NameHu = "Nyomolvasás/rejtés", Category = SkillCategory.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 33, Name = "Dance", NameHu = "Tánc", Category = SkillCategory.Secular, Attribute1 = Attribute.Dexterity, Attribute2 = Attribute.Emotion },
                new Skill { Id = 34, Name = "Survival", NameHu = "Túlélés", Category = SkillCategory.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Willpower },

                new Skill { Id = 35, Name = "Underworld knowledge", NameHu = "Alvilági ismeretek", Category = SkillCategory.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion },
                new Skill { Id = 36, Name = "Camouflaging", NameHu = "Álcázás", Category = SkillCategory.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 37, Name = "Traps/Secret doors", NameHu = "Csapdák és tikos ajtók", Category = SkillCategory.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion },
                new Skill { Id = 38, Name = "Vigilance", NameHu = "Éberség", Category = SkillCategory.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion },
                new Skill { Id = 39, Name = "Poison mixing", NameHu = "Méregkeverés", Category = SkillCategory.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence },
                new Skill { Id = 40, Name = "Sneaking/Hiding", NameHu = "Osonás", Category = SkillCategory.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 41, Name = "Assassination", NameHu = "Orvgyilkolás", Category = SkillCategory.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 42, Name = "Gambling", NameHu = "Szerencsejáték", Category = SkillCategory.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 43, Name = "Lock picking", NameHu = "Zárnyitás", Category = SkillCategory.Underworld, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 44, Name = "Pickpocketing", NameHu = "Zsebmetszés", Category = SkillCategory.Underworld, Attribute1 = Attribute.Agility, Attribute2 = Attribute.Dexterity },

                new Skill { Id = 45, Name = "Alchemy", NameHu = "Alkímia", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 46, Name = "Demonology", NameHu = "Démonológia", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Willpower },
                new Skill { Id = 47, Name = "Meditation", NameHu = "Elmélyülés", Category = SkillCategory.Scholar, Attribute1 = Attribute.Willpower, Attribute2 = Attribute.Emotion },
                new Skill { Id = 48, Name = "Physiology", NameHu = "Élettan", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence },
                new Skill { Id = 49, Name = "Extrasensory Perception", NameHu = "Érzéken túli érzékelés", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion },
                new Skill { Id = 50, Name = "Herbalism", NameHu = "Herbalizmus", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence },
                new Skill { Id = 51, Name = "Theology", NameHu = "Hittan", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion },
                new Skill { Id = 52, Name = "Prognostication", NameHu = "Jóslás", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion },
                new Skill { Id = 53, Name = "Legendary", NameHu = "Legendaismeret", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion },
                new Skill { Id = 54, Name = "Mechanics", NameHu = "Mechanika", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 55, Name = "Poison mixing", NameHu = "Méregkeverés", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence },
                new Skill { Id = 56, Name = "Language", NameHu = "Nyelvismeret", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence },
                new Skill { Id = 57, Name = "Rune magic", NameHu = "Rúnamágia", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 58, Name = "Wound treatment", NameHu = "Sebgyógyítás", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 59, Name = "Cartography", NameHu = "Térképészet", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence },
                new Skill { Id = 60, Name = "Will arcane", NameHu = "Akaraterő arkánum", Category = SkillCategory.Scholar, Attribute1 = Attribute.Willpower, Attribute2 = Attribute.Willpower },
                new Skill { Id = 61, Name = "Emotion arcane", NameHu = "Érzelem arkánum", Category = SkillCategory.Scholar, Attribute1 = Attribute.Emotion, Attribute2 = Attribute.Emotion },
                new Skill { Id = 62, Name = "Earth arcane", NameHu = "Föld arkánum", Category = SkillCategory.Scholar, Attribute1 = Attribute.Willpower, Attribute2 = Attribute.Emotion },
                new Skill { Id = 63, Name = "Air arcane", NameHu = "Levegő arkánum", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion },
                new Skill { Id = 64, Name = "Fire arcane", NameHu = "Tűz arkánum", Category = SkillCategory.Scholar, Attribute1 = Attribute.Willpower, Attribute2 = Attribute.Emotion },
                new Skill { Id = 65, Name = "Water arcane", NameHu = "Víz arkánum", Category = SkillCategory.Scholar, Attribute1 = Attribute.Emotion, Attribute2 = Attribute.Emotion },
                new Skill { Id = 66, Name = "Time arcane", NameHu = "Idő arkánum", Category = SkillCategory.Scholar, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Intelligence },
                new Skill { Id = 67, Name = "Path of Light", NameHu = "Jóság ösvénye", Category = SkillCategory.Scholar, Attribute1 = Attribute.Karma, Attribute2 = Attribute.Karma },
                new Skill { Id = 68, Name = "Path of Dark", NameHu = "Gonoszság ösvénye", Category = SkillCategory.Scholar, Attribute1 = Attribute.Karma, Attribute2 = Attribute.Karma },
               
                new Skill { Id = 69, Name = "Sexual culture", NameHu = "Szexuális kultúra", Category = SkillCategory.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Emotion },
                new Skill { Id = 70, Name = "Flying", NameHu = "Repülés", Category = SkillCategory.Secular, Attribute1 = Attribute.Agility, Attribute2 = Attribute.Dexterity },
                new Skill { Id = 71, Name = "Metamorphing", NameHu = "Átalakulás", Category = SkillCategory.Secular, Attribute1 = Attribute.Body, Attribute2 = Attribute.Emotion },
                new Skill { Id = 72, Name = "Howling", NameHu = "Vonyítás", Category = SkillCategory.Underworld, Attribute1 = Attribute.Emotion, Attribute2 = Attribute.Emotion },
                new Skill { Id = 73, Name = "Weapon Proficiency", NameHu = "Fegyverismeret", Category = SkillCategory.Secular, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Optional },
                new Skill { Id = 74, Name = "Commanding", NameHu = "Parancsnoklás", Category = SkillCategory.Combat, Attribute1 = Attribute.Intelligence, Attribute2 = Attribute.Willpower }
            });
        }
    }
}