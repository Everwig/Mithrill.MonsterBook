using System;
using System.Linq;
// ReSharper disable PossibleNullReferenceException

namespace Mithrill.MonsterBook.Domain
{
    public class Monster
    {
        private readonly Random _rnd = new Random();

        public Monster(int strength, int vitality, int body, int speed, int agility, int intelligence, int willpower, int sensation, int damageReduction, Difficulty difficulty, Merit[] merits, Weapon[] weapons, Skill[] skills)
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
        public Merit[] Merits { get; }
        public Weapon[] Weapons { get; }
        public Skill[] Skills { get; }
        public int PowerPoint { get; private set; }
        public int ManaPoint { get; private set; }
        public int HitPoint { get; private set; }
        
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

        public int SkillTrial(int skillId)
        {
            var skill = Skills.Single(s => s.Id == skillId);
            var attrOne = (int)this.GetType().GetProperty(skill.AttributeOne).GetValue(this, null);
            var attrTwo = (int)this.GetType().GetProperty(skill.AttributeTwo).GetValue(this, null);
            var dicePool = Math.Abs((attrOne + attrTwo) / 2);
            var success = (skill.Level - 5) % 2;

            for (var i = 0; i < dicePool; i++)
            {
                if(_rnd.Next(1, 7) > skill.Level)
                    continue;

                success++;
            }

            return success;
        }

        public void TakeDamage(int damage)
        {
            HitPoint -= damage;
        }

        public void ConjureSpell(int manaPointCost)
        {
            ManaPoint -= manaPointCost;
        }

        public void ConjureDivineInfluence(int powerPoint)
        {
            PowerPoint -= powerPoint;
        }

        public int CalculateDamage()
        {
            return Weapons[_rnd.Next(1, Weapons.Length)].AttackType.CalculateDamage();
        }
    }
}