using System.Collections.Generic;

namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface IGeneratedCreature
    {
        string Name { get; }
        string NameHu { get; }
        int Strength { get; }
        int Vitality { get; }
        int Body { get; }
        int Agility { get; }
        int Dexterity { get; }
        int Intelligence { get; }
        int Willpower { get; }
        int Emotion { get; }
        int DamageReduction { get; }
        int Karma { get; }
        Difficulty Difficulty { get; }
        CreatureSkillCategories CreatureSkillCategories { get; }
        IEnumerable<IMeritFlaw> Merits { get; }
        IEnumerable<IMeritFlaw> Flaws { get; }
        IEnumerable<IWeapon> Weapons { get; }
        IEnumerable<ISkill> Skills { get; }
        int PowerPoint { get; }
        int ManaPoint { get; }
        int HitPoint { get; }
    }
}