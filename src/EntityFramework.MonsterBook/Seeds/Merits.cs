﻿using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds
{
    public static class Merits
    {
        public static Task AddOrUpdateMerits(DbContext context)
        {
            return context.BulkInsertOrUpdateAsync(new[]
            {
                new Merit { Id = 1, Name = "Steel bones", NameHu = "Acélos csontok" },
                new Merit { Id = 2, Name = "Forest walker", NameHu = "Erdőjáró" },
                new Merit { Id = 3, Name = "Undead", NameHu = "Élőholt" },
                new Merit { Id = 4, Name = "Wealthy family", NameHu = "Gazdag család" },
                new Merit { Id = 5, Name = "Skilled marksman", NameHu = "Gyakorlott céllövő" },
                new Merit { Id = 6, Name = "Heat vision", NameHu = "Hőlátás" },
                new Merit { Id = 7, Name = "Flexible joints", NameHu = "Hajlékony izületek" },
                new Merit { Id = 8, Name = "Longevity", NameHu = "Hosszúélet" },
                new Merit { Id = 9, Name = "Sense of time", NameHu = "Időérzék" },
                new Merit { Id = 10, Name = "Sense of direction", NameHu = "Irányérzék" },
                new Merit { Id = 11, Name = "Muscle brain", NameHu = "Izomagyú" },
                new Merit { Id = 12, Name = "Literate", NameHu = "Írástudó" },
                new Merit { Id = 13, Name = "Excellent memory", NameHu = "Kitűnő memória" },
                new Merit { Id = 14, Name = "Little need for rest", NameHu = "Kevés alvás igény" },
                new Merit { Id = 15, Name = "Fit as a fiddle", NameHu = "Makk egészség" },
                new Merit { Id = 16, Name = "Exceptionally beautiful", NameHu = "Meseszép" },
                new Merit { Id = 17, Name = "Omnivorous", NameHu = "Mindenevő" },
                new Merit { Id = 18, Name = "Noble family", NameHu = "Nemesi család" },
                new Merit { Id = 19, Name = "Linguist", NameHu = "Nyelvismeret" },
                new Merit { Id = 20, Name = "Heirdom", NameHu = "Örökség" },
                new Merit { Id = 21, Name = "Regeneration", NameHu = "Regeneráció" },
                new Merit { Id = 22, Name = "Eagle eye", NameHu = "Sasszem" },
                new Merit { Id = 23, Name = "Excellent smelling", NameHu = "Kitűnő szaglás" },
                new Merit { Id = 24, Name = "Beautiful", NameHu = "Szép" },
                new Merit { Id = 25, Name = "Animal Sympathy", NameHu = "Szimpátia az állatokkal" },
                new Merit { Id = 26, Name = "Tough", NameHu = "Szívós" },
                new Merit { Id = 27, Name = "Thief", NameHu = "Tolvaj" },
                new Merit { Id = 28, Name = "Hunter", NameHu = "Vadász" },
                new Merit { Id = 29, Name = "Magic book", NameHu = "Varázskönyv" },
                new Merit { Id = 30, Name = "Wizarding university", NameHu = "Varázslóegyetem" },
                new Merit { Id = 31, Name = "Headstrong", NameHu = "Akaratos" },
                new Merit { Id = 32, Name = "Acrobat", NameHu = "Akrobata" },
                new Merit { Id = 33, Name = "Shapeshifter", NameHu = "Alakváltó" },
                new Merit { Id = 34, Name = "Anti-magic aura", NameHu = "Antimágikus aura" },
                new Merit { Id = 35, Name = "The gift of fortune", NameHu = "Aranyeső" },
                new Merit { Id = 36, Name = "Rook", NameHu = "Bástya" },
                new Merit { Id = 37, Name = "Brave", NameHu = "Bátor" },
                new Merit { Id = 38, Name = "Infiltrator", NameHu = "Beszivárgó" },
                new Merit { Id = 39, Name = "Grifter", NameHu = "Blöff" },
                new Merit { Id = 40, Name = "Teamwork", NameHu = "Csapatmunka" },
                new Merit { Id = 41, Name = "First strike", NameHu = "Első csapás" },
                new Merit { Id = 42, Name = "Light sleeper", NameHu = "Éber alvó" },
                new Merit { Id = 43, Name = "Peace of mind", NameHu = "Ép elme" },
                new Merit { Id = 44, Name = "Nimble fingers", NameHu = "Érzékeny ujjak" },
                new Merit { Id = 45, Name = "Loss of appetite", NameHu = "Étvágytalan" },
                new Merit { Id = 46, Name = "Frost resistant", NameHu = "Fagyálló" },
                new Merit { Id = 47, Name = "Terrifying presence", NameHu = "Fenyegető jelenlét" },
                new Merit { Id = 48, Name = "Recognition", NameHu = "Felismerés" },
                new Merit { Id = 49, Name = "Eater of light", NameHu = "Fényevő" },
                new Merit { Id = 50, Name = "Immortal", NameHu = "Halhatatlan" },
                new Merit { Id = 51, Name = "Holy founding member", NameHu = "Házi szent" },
                new Merit { Id = 52, Name = "Fame", NameHu = "Hírnév" },
                new Merit { Id = 53, Name = "Good people skills", NameHu = "Jó emberismerő" },
                new Merit { Id = 54, Name = "Favorite weapon", NameHu = "Kedvenc fegyver" },
                new Merit { Id = 55, Name = "Merciless", NameHu = "Kegyetlen" },
                new Merit { Id = 56, Name = "Ambidextrous", NameHu = "Kétekezes" },
                new Merit { Id = 57, Name = "Chosen", NameHu = "Kiválasztott" },
                new Merit { Id = 58, Name = "Outburst", NameHu = "Kitörés" },
                new Merit { Id = 59, Name = "Unshakable", NameHu = "Kizökkenthetetlen" },
                new Merit { Id = 60, Name = "Circular blow", NameHu = "Körcsapás" },
                new Merit { Id = 61, Name = "Magic chalice", NameHu = "Mágikus kehely" },
                new Merit { Id = 62, Name = "Burly", NameHu = "Melák" },
                new Merit { Id = 63, Name = "Escapist", NameHu = "Menekülés" },
                new Merit { Id = 64, Name = "Poison resistance", NameHu = "Méregellenállás" },
                new Merit { Id = 65, Name = "Moral", NameHu = "Morál" },
                new Merit { Id = 66, Name = "Arrow storm", NameHu = "Nyílzápor" },
                new Merit { Id = 67, Name = "Careful reveler", NameHu = "Óvatos duhaj" },
                new Merit { Id = 68, Name = "Protective forces", NameHu = "Óvó erők" },
                new Merit { Id = 69, Name = "Concentration", NameHu = "Összpontosítás" },
                new Merit { Id = 70, Name = "Dirty trick", NameHu = "Pisztkos trükk" },
                new Merit { Id = 71, Name = "Poker face", NameHu = "Póker arc" },
                new Merit { Id = 72, Name = "Hidden weapon", NameHu = "Rejtett fegyver" },
                new Merit { Id = 73, Name = "Lucky", NameHu = "Szerencsés" },
                new Merit { Id = 74, Name = "Turtle", NameHu = "Teknős" },
                new Merit { Id = 75, Name = "Telepathic", NameHu = "Telepata" },
                new Merit { Id = 76, Name = "Child of nature", NameHu = "Természet gyermeke" },
                new Merit { Id = 77, Name = "Secret trick", NameHu = "Titkos csel" },
                new Merit { Id = 78, Name = "Secret hideout", NameHu = "Titkos rejtekhely" },
                new Merit { Id = 79, Name = "Jack of all trades", NameHu = "Tótumfaktum" },
                new Merit { Id = 80, Name = "Cannot be hoodwinked", NameHu = "Tőrbe csalhatatlan" },
                new Merit { Id = 81, Name = "Otherwordly senses", NameHu = "Túlvilági érzékek" },
                new Merit { Id = 82, Name = "Firewalker", NameHu = "Tűzjáró" },
                new Merit { Id = 83, Name = "Living in the wild", NameHu = "Vadonélő" },
                new Merit { Id = 84, Name = "Protector", NameHu = "Védelmező" },
                new Merit { Id = 85, Name = "Lightning reflexes", NameHu = "Villámreflex" }
            });
        }
    }
}