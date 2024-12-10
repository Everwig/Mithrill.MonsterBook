using System;
using System.Collections.Generic;
using System.Linq;
using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application.Common.Builders;

internal static class Calculators
{
    public static int CalculatePowerPoints(int karma) => Math.Abs(karma * 3);

    public static int CalculateHitPoints(int strength, int body, bool isUndead, IEnumerable<string> meritNames)
    {
        if (isUndead)
        {
            return (strength + body) * 5;
        }

        var hp = body * GetHpMultiplier(meritNames) + 5;

        if (body > 7)
        {
            hp *= 2;
        }

        return hp;
    }

    public static int CalculateManaPoints(int intelligence, int willpower, int emotion, IEnumerable<Merit> merits)
    {
        return merits.Any(m => string.Equals(m.Name, AttributeTraits.ManaPointIncreaseTrait))
            ? CalculateManaPoints(intelligence, willpower, emotion, true)
            : CalculateManaPoints(intelligence, willpower, emotion, false);
    }

    public static int CalculateManaPoints(int intelligence, int willpower, int emotion, IEnumerable<MonsterBook.Domain.Entities.Merit> merits)
    {
        return merits.Any(m => string.Equals(m.Name, AttributeTraits.ManaPointIncreaseTrait))
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

    private static int GetHpMultiplier(IEnumerable<string> meritNames)
    {
        return meritNames.Contains(AttributeTraits.MythicToughness)
            ? 20
            : meritNames.Contains(AttributeTraits.DemonicToughness)
                ? 10
                : meritNames.Contains(AttributeTraits.Tough)
                    ? 5
                    : 4;
    }
}