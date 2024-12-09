using System;
using System.Collections.Generic;
using System.Linq;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Domain;
using Merit = Mithrill.MonsterBook.Application.Domain.Merit;
using Skill = Mithrill.MonsterBook.Application.Domain.Skill;

namespace Mithrill.MonsterBook.Application.Common.Builders;

internal sealed class DevilBuilder : SummonBuilder
{
    private readonly Random _random = new();

    public DevilBuilder(IMonsterBookDbContext monsterBookDbContext)
        : base(monsterBookDbContext, SummonType.Unholy) { }

    public override void SetDefaultValues(int level)
    {
        if (QueriedCreature is null)
            return;

        Creature.Name = QueriedCreature.Name;
        Creature.Strength = level + 2;
        Creature.Vitality = level * 2;
        Creature.Body = level + 2;
        Creature.Agility = level + 2;
        Creature.Dexterity = level + 1;
        Creature.Intelligence = level;
        Creature.Willpower = level + 2;
        Creature.Emotion = level;
        Creature.Merits = QueriedCreature.CharacterMerits.Select(characterMerit => new Merit { Name = characterMerit.Merit.Name });
        Creature.Flaws = [];
        Creature.Karma = level;
        Creature.Skills = GetSkills(QueriedCreature.CharacterSkills, level);
    }

    private IEnumerable<Skill> GetSkills(ICollection<CharacterSkill> characterSkills, int level)
    {
        var skills = characterSkills.Where(characterSkill => !characterSkill.IsOptional || characterSkill.SkillLevelMin + level >= 1)
            .Select(characterSkill => new Skill
            {
                Category = (SkillCategory)characterSkill.Skill.Category,
                GuaranteedSuccesses = GetGuaranteedSuccess(level),
                Level = level + characterSkill.SkillLevelMin,
                Name = characterSkill.Skill.Name
            })
            .ToList();

        if (level >= 2)
        {
            var arcanumNumber = _random.Next(0, 7);
            skills.Add(new Skill
            {
                Category = SkillCategory.Scholar,
                GuaranteedSuccesses = GetGuaranteedSuccess(level),
                Level = level - 1,
                Name = $"{(Arcanum)arcanumNumber} arcane"
            });

            var mediumArms = characterSkills.SingleOrDefault(characterSkill => string.Equals(characterSkill.Skill.Name, MediumArms));
            if (mediumArms is not null)
            {
                skills.Add(new Skill
                {
                    Category = (SkillCategory)mediumArms.Skill.Category,
                    GuaranteedSuccesses = GetGuaranteedSuccess(level),
                    Level = level,
                    Name = mediumArms.Skill.Name
                });
            }
        }

        if (level >= 4)
        {
            var heavyArms = characterSkills.SingleOrDefault(characterSkill => string.Equals(characterSkill.Skill.Name, HeavyArms));
            if (heavyArms is not null)
            {
                skills.Add(new Skill
                {
                    Category = (SkillCategory)heavyArms.Skill.Category,
                    GuaranteedSuccesses = GetGuaranteedSuccess(level),
                    Level = level,
                    Name = heavyArms.Skill.Name
                });
            }
        }

        return skills;
    }
}