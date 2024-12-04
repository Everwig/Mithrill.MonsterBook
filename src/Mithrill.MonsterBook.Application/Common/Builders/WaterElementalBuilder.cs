using System;
using System.Linq;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application.Common.Builders;

internal class WaterElementalBuilder : SummonBuilder
{
    public WaterElementalBuilder(IMonsterBookDbContext monsterBookDbContext)
        : base(monsterBookDbContext, SummonType.Water)
    {
    }

    public override void SetDefaultValues(int level)
    {
        if (QueriedCreature is null)
            return;

        Creature.Name = QueriedCreature.Name;
        Creature.Strength = level;
        Creature.Body = level + 2;
        Creature.Agility = level + 1;
        Creature.Dexterity = level + 1;
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
            AttackType = characterWeapon.IsOptional
                ? new AttackType(DamageType.Slashing, (int)Math.Round((double)level / 2), 0)
                : new AttackType(DamageType.Bludgeoning, level, 0)
        });
    }
}