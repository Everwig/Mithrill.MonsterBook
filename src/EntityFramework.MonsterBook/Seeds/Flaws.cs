using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds
{
    public static class Flaws
    {
        public static Task AddOrUpdateFlaws(DbContext dbContext)
        {
            return dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Flaw { Id = 1, Name = "Ugly", NameHu = "Csúnya" },
                new Flaw { Id = 2, Name = "Deserter", NameHu = "Dezertőr" },
                new Flaw { Id = 3, Name = "Toothless", NameHu = "Fogatlan" },
                new Flaw { Id = 4, Name = "Soothsayer", NameHu = "Igazmondó" },
                new Flaw { Id = 5, Name = "Impotent", NameHu = "Impotens" },
                new Flaw { Id = 6, Name = "One-eyed\\One-Handed", NameHu = "Kéz, szem hiánya" },
                new Flaw { Id = 7, Name = "Minor bodily deficiency", NameHu = "Kisebb testi hiány" },
                new Flaw { Id = 8, Name = "Minor deformity", NameHu = "Kisebb testi torzulás" },
                new Flaw { Id = 9, Name = "Special peculiarity", NameHu = "Külső ismertetőjegy" },
                new Flaw { Id = 10, Name = "Slow recovery", NameHu = "Lassú gyógyulás" },
                new Flaw { Id = 11, Name = "Missing leg", NameHu = "Láb hiánya" },
                new Flaw { Id = 12, Name = "Sensitive to magic", NameHu = "Mágia érzékenység" },
                new Flaw { Id = 13, Name = "Deep sleeper", NameHu = "Mélyalvó" },
                new Flaw { Id = 14, Name = "Hard of hearing", NameHu = "Nagyotthalló" },
                new Flaw { Id = 15, Name = "Mute", NameHu = "Néma" },
                new Flaw { Id = 16, Name = "Hideous", NameHu = "Ocsmány" },
                new Flaw { Id = 17, Name = "Old", NameHu = "Öreg" },
                new Flaw { Id = 18, Name = "Slave", NameHu = "Rabszolga" },
                new Flaw { Id = 19, Name = "Lame", NameHu = "Sánta" },
                new Flaw { Id = 20, Name = "Major deformity", NameHu = "Nagyobb testi torzulás" },
                new Flaw { Id = 21, Name = "Deaf", NameHu = "Süket" },
                new Flaw { Id = 22, Name = "Brittle boned", NameHu = "Törékeny csontok" },
                new Flaw { Id = 23, Name = "Outlaw", NameHu = "Törvényen kívűli" },
                new Flaw { Id = 24, Name = "Bleeder", NameHu = "Vérzékeny" },
                new Flaw { Id = 25, Name = "Debt", NameHu = "Adósság" },
                new Flaw { Id = 26, Name = "Aggressive", NameHu = "Agresszív" },
                new Flaw { Id = 27, Name = "Allergy", NameHu = "Allergia" },
                new Flaw { Id = 28, Name = "Amnesic", NameHu = "Amnéziás" },
                new Flaw { Id = 29, Name = "Antisocial", NameHu = "Antiszociális" },
                new Flaw { Id = 30, Name = "Sleepy-head", NameHu = "Álomszuszék" },
                new Flaw { Id = 31, Name = "Curse", NameHu = "Átok" },
                new Flaw { Id = 32, Name = "Unlucky", NameHu = "Balszerencsés" },
                new Flaw { Id = 33, Name = "Speech impaired", NameHu = "Beszédhibás" },
                new Flaw { Id = 34, Name = "Sickly", NameHu = "Beteges" },
                new Flaw { Id = 35, Name = "Vengeful", NameHu = "Bosszúvágy" },
                new Flaw { Id = 36, Name = "Egoistic", NameHu = "Egoista" },
                new Flaw { Id = 37, Name = "Animal Antipathy", NameHu = "Ellenszenv az állatokkal" },
                new Flaw { Id = 38, Name = "Apathetic", NameHu = "Életunt" },
                new Flaw { Id = 39, Name = "Forgetful", NameHu = "Feledős" },
                new Flaw { Id = 40, Name = "Jealousy", NameHu = "Féltékenység" },
                new Flaw { Id = 41, Name = "Hotheaded", NameHu = "Forrófejű" },
                new Flaw { Id = 42, Name = "Phobia", NameHu = "Fóbia" },
                new Flaw { Id = 43, Name = "Addict", NameHu = "Függő" },
                new Flaw { Id = 44, Name = "Coward", NameHu = "Gyáva" },
                new Flaw { Id = 45, Name = "Liar", NameHu = "Hazug" },
                new Flaw { Id = 46, Name = "Hallucination", NameHu = "Halucinációk" },
                new Flaw { Id = 47, Name = "Gullible", NameHu = "Hiszékeny" },
                new Flaw { Id = 48, Name = "Inelegant", NameHu = "Igénytelen" },
                new Flaw { Id = 49, Name = "Bitter memories", NameHu = "Keserű emlékek" },
                new Flaw { Id = 50, Name = "Mayfly", NameHu = "Kérész" },
                new Flaw { Id = 51, Name = "Slow learner", NameHu = "Lassú tanuló" },
                new Flaw { Id = 52, Name = "Stubborn", NameHu = "Makacs" },
                new Flaw { Id = 53, Name = "Masochistic", NameHu = "Mazoista" },
                new Flaw { Id = 54, Name = "Thoughtless", NameHu = "Meggondolatlan" },
                new Flaw { Id = 55, Name = "Touchy", NameHu = "Mimóza" },
                new Flaw { Id = 56, Name = "Insane", NameHu = "Őrült" },
                new Flaw { Id = 57, Name = "Paranoid", NameHu = "Paranóriás" },
                new Flaw { Id = 58, Name = "Pyromaniac", NameHu = "Piromán" },
                new Flaw { Id = 59, Name = "Prey", NameHu = "Préda" },
                new Flaw { Id = 60, Name = "Unrequited love", NameHu = "Reménytelen szerelem" },
                new Flaw { Id = 61, Name = "Nightmares", NameHu = "Rémálmok" },
                new Flaw { Id = 62, Name = "Malignant acquaintances", NameHu = "Rosszakarók" },
                new Flaw { Id = 63, Name = "Sadistic", NameHu = "Szadista" },
                new Flaw { Id = 64, Name = "Poor", NameHu = "Szegény család" },
                new Flaw { Id = 65, Name = "Shy", NameHu = "Szégyenlős" },
                new Flaw { Id = 66, Name = "Subservient", NameHu = "Szolgalelkű" },
                new Flaw { Id = 67, Name = "Delusions", NameHu = "Téveszme" },
                new Flaw { Id = 68, Name = "Secret personality", NameHu = "Titkos személyiség" },
                new Flaw { Id = 69, Name = "Elemental dissonance", NameHu = "Elemi diszonancia" }
            });
        }
    }
}