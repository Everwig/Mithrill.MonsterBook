using System.Linq;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application.Common.Builders;

internal sealed class EarthElementalBuilder : SummonBuilder
{
    public EarthElementalBuilder(IMonsterBookDbContext monsterBookDbContext)
        : base(monsterBookDbContext, SummonType.Earth) { }

    public override void SetDefaultValues(int level)
    {
        if (QueriedCreature is null)
            return;

        Creature.Name = QueriedCreature.Name;
        Creature.Strength = level + 2;
        Creature.Body = level * 2;
        Creature.Agility = level;
        Creature.Dexterity = level;
        Creature.Intelligence = level < 3 ? 3 : level;
        Creature.Willpower = level < 3 ? 3 : level;
        Creature.Emotion = level < 3 ? 3 : level;
        Creature.Flaws = [];
        Creature.Merits = [];
        Creature.Skills = QueriedCreature.CharacterSkills.Select(characterSkill => new Skill
        {
            Category = SkillCategory.Combat,
            GuaranteedSuccesses = GetGuaranteedSuccess(level),
            Level = level,
            Name = characterSkill.Skill.Name
        });
        Creature.Weapons = QueriedCreature.CharacterWeapons.Select(characterWeapon => new Weapon
        {
            Name = characterWeapon.Weapon.Name,
            AttackType = new AttackType(DamageType.Bludgeoning, level, 0)
        });
    }
}