using System;
using System.Linq;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application.Common.Builders;

internal class IceElementalBuilder : SummonBuilder
{
    public IceElementalBuilder(IMonsterBookDbContext monsterBookDbContext)
        : base(monsterBookDbContext, SummonType.Ice) { }

    public override void SetDefaultValues(int level)
    {
        if (QueriedCreature is null)
            return;

        Creature.Name = QueriedCreature.Name;
        Creature.Strength = level;
        Creature.Body = (int)Math.Round((double)level * 3 / 2);
        Creature.Agility = level;
        Creature.Dexterity = level;
        Creature.Intelligence = level < 3 ? 3 : level;
        Creature.Willpower = level < 3 ? 3 : level;
        Creature.Emotion = level < 3 ? 3 : level;
        Creature.Flaws = [];
        Creature.Merits = [];
        Creature.DamageReduction = level / 2;
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
                ? new AttackType(DamageType.Slashing, level / 2, 0)
                : new AttackType(DamageType.Bludgeoning, level, 0)
        });
    }
}