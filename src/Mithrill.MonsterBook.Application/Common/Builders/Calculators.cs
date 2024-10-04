using Mithrill.MonsterBook.Application.Common.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mithrill.MonsterBook.Application.Common.Builders
{
    internal static class Calculators
    {
        public static int CalculatePowerPoints(int karma) => Math.Abs(karma * 3);

        public static int CalculateHitPoints(int strength, int body, bool isUndead, IEnumerable<IMeritFlaw> merits)
        {
            return merits.Any(merit => string.Equals(merit.NameHu, AttributeTraits.HitPointIncreaseTrait))
                    ? CalculateHitPoints(strength, body, isUndead, true)
                    : CalculateHitPoints(strength, body, isUndead, false);
        }

        public static int CalculateHitPoints(int strength, int body, MonsterBook.Domain.Race race, IEnumerable<MonsterBook.Domain.Merit> merits)
        {
            return merits.Any(merit => string.Equals(merit.NameHu, AttributeTraits.HitPointIncreaseTrait))
                    ? CalculateHitPoints(strength, body, race == MonsterBook.Domain.Race.Undead, true)
                    : CalculateHitPoints(strength, body, race == MonsterBook.Domain.Race.Undead, false);
        }

        public static int CalculateManaPoints(int intelligence, int willpower, int emotion, IEnumerable<IMeritFlaw> merits)
        {
            return merits.Any(m => string.Equals(m.NameHu, AttributeTraits.ManaPointIncreaseTrait))
                ? CalculateManaPoints(intelligence, willpower, emotion, true)
                : CalculateManaPoints(intelligence, willpower, emotion, false);
        }

        public static int CalculateManaPoints(int intelligence, int willpower, int emotion, IEnumerable<MonsterBook.Domain.Merit> merits)
        {
            return merits.Any(m => string.Equals(m.NameHu, AttributeTraits.ManaPointIncreaseTrait))
                ? CalculateManaPoints(intelligence, willpower, emotion, true)
                : CalculateManaPoints(intelligence, willpower, emotion, false);
        }

        private static int CalculateManaPoints(int intelligence, int willpower, int emotion, bool hasManaPointIncreaseTrait)
        {
            var mp = intelligence + willpower + emotion;

            if (hasManaPointIncreaseTrait)
            {
                mp += intelligence + 3;
            }

            if (intelligence > 7)
            {
                mp += intelligence;
            }

            return mp;
        }

        private static int CalculateHitPoints(int strength, int body, bool isUndead, bool hasHitPointIncreaseTrait)
        {
            if (isUndead)
            {
                return (strength + body) * 5;
            }

            var hp = body * 4 + 5;
            if (hasHitPointIncreaseTrait)
            {
                hp += body;
            }

            if (body > 7)
            {
                hp *= 2;
            }

            return hp;
        }
    }
}