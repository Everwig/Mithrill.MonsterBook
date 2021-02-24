using System.Collections.Generic;
using System.Linq;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Monsters.Query.GetGeneratedMonster
{
    public class GeneratedMonster
    {
        //Factory Ctor
        public GeneratedMonster(int strength, int vitality, int body, int agility, int dexterity, int intelligence, int willpower, int emotion, int damageReduction, int karma, Difficulty difficulty, IEnumerable<Merit> merits, IEnumerable<Weapon> weapons, IEnumerable<Skill> skills)
        {
            Strength = strength;
            Vitality = vitality;
            Body = body;
            Agility = agility;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Willpower = willpower;
            Emotion = emotion;
            Difficulty = difficulty;
            Merits = merits;
            Weapons = weapons;
            Skills = skills;
            DamageReduction = damageReduction;
            Karma = karma;
            PowerPoint = CalculatePowerPoints(karma);
            ManaPoint = CalculateManaPoints();
            HitPoint = CalculateHitPoints();
        }

        //Builder Pattern Ctor
        public GeneratedMonster()
        {
            Merits = new List<Merit>();
            Weapons = new List<Weapon>();
            Skills = new List<Skill>();
        }

        public int Strength { get; set; }
        public int Vitality { get; set; }
        public int Body { get; set; }
        public int Agility { get; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Willpower { get; set; }
        public int Emotion { get; set; }
        public int DamageReduction { get; }
        public int Karma { get; set; }
        public Difficulty Difficulty { get; set; }
        public IEnumerable<Merit> Merits { get; set; }
        public IEnumerable<Weapon> Weapons { get; }
        public IEnumerable<Skill> Skills { get; }
        public int PowerPoint { get; set; }
        public int ManaPoint { get; set; }
        public int HitPoint { get; set; }

        private int CalculateManaPoints()
        {
            var mp = Intelligence + Willpower + Emotion;
            
            if (Merits.Any(m => m.Name == "Mágikus kehely"))
                mp += Intelligence + 3;

            if (Intelligence > 7)
                mp += Intelligence;

            return mp;
        }

        private int CalculateHitPoints()
        {
            var hp = Vitality * 4 + 5;
            if (Merits.Any(m => m.Name == "Szívósság"))
                hp += Vitality;

            if (Body > 7)
                hp *= 2;

            return hp;
        }

        private int CalculatePowerPoints(int karma)
        {
            return karma * 3;
        }
    }
}