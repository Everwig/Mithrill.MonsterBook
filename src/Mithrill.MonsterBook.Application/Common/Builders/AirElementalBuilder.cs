using System;
using System.Linq;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application.Common.Builders;

internal class AirElementalBuilder : SummonBuilder
{
    public AirElementalBuilder(IMonsterBookDbContext monsterBookDbContext)
        : base(monsterBookDbContext, SummonType.Air) { }

    public override void SetDefaultValues(int level)
    {
        if (QueriedCreature is null)
            return;

        Creature.Name = QueriedCreature.Name;
        Creature.Body = (int)Math.Round((double)level / 2);
        Creature.Agility = level * 2;
        Creature.Dexterity = level * 2;
        Creature.Intelligence = level < 3 ? 3 : level;
        Creature.Willpower = level < 3 ? 3 : level;
        Creature.Emotion = level < 3 ? 3 : level;
        Creature.Flaws = [];
        Creature.Merits = [];
        Creature.DamageReduction = (int)Math.Round((double)level / 2);
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