using System.Collections.Generic;
using System.Linq;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Monsters.Query.GetGeneratedMonster
{
    public class GeneratedMonster
    {
        public GeneratedMonster(int strength, int vitality, int body, int speed, int agility, int intelligence, int willpower, int sensation, int damageReduction, int karma, Difficulty difficulty, IEnumerable<Merit> merits, IEnumerable<Weapon> weapons, IEnumerable<Skill> skills)
        {
            Strength = strength;
            Vitality = vitality;
            Body = body;
            Speed = speed;
            Agility = agility;
            Intelligence = intelligence;
            Willpower = willpower;
            Sensation = sensation;
            Difficulty = difficulty;
            Merits = merits;
            Weapons = weapons;
            Skills = skills;
            DamageReduction = damageReduction;
            PowerPoint = CalculatePowerPoints(karma);
            ManaPoint = CalculateManaPoints();
            HitPoint = CalculateHitPoints();
        }

        public int Strength { get; }
        public int Vitality { get; }
        public int Body { get; }
        public int Speed { get; }
        public int Agility { get; }
        public int Intelligence { get; }
        public int Willpower { get; }
        public int Sensation { get; }
        public int DamageReduction { get; }
        public Difficulty Difficulty { get; }
        public IEnumerable<Merit> Merits { get; }
        public IEnumerable<Weapon> Weapons { get; }
        public IEnumerable<Skill> Skills { get; }
        public int PowerPoint { get; }
        public int ManaPoint { get; }
        public int HitPoint { get; }
        
        private int CalculateManaPoints()
        {
            var mp = Intelligence + Willpower + Sensation;
            
            if (Merits.Any(m => m.Name == "Szívósság"))
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