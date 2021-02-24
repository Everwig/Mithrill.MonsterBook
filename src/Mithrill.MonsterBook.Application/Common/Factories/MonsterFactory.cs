using System;
using System.Collections.Generic;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Monsters.Query.GetGeneratedMonster;

namespace Mithrill.MonsterBook.Application.Common.Factories
{
    public class MonsterFactory : IMonsterFactory
    {
        private readonly IMapper _mapper;
        private readonly Random _random;

        public MonsterFactory(IMapper mapper)
        {
            _mapper = mapper;
            _random = new Random();
        }

        public GeneratedMonster CreateMonster(Domain.Creature creature)
        {
            var strength = _random.Next(creature.StrengthMin, creature.StrengthMax + 1);
            var vitality = _random.Next(creature.VitalityMin, creature.VitalityMax + 1);
            var body = _random.Next(creature.BodyMin, creature.BodyMax + 1);
            var agility = _random.Next(creature.AgilityMin, creature.AgilityMax + 1);
            var dexterity = _random.Next(creature.DexterityMin, creature.DexterityMax + 1);
            var intelligence = _random.Next(creature.IntelligenceMin, creature.IntelligenceMax + 1);
            var willpower = _random.Next(creature.WillpowerMin, creature.WillpowerMax + 1);
            var emotion = _random.Next(creature.EmotionMin, creature.EmotionMax + 1);
            var damageReduction = _random.Next(creature.DamageReductionMin, creature.DamageReductionMax + 1);
            var merits = _mapper.Map<IEnumerable<Merit>>(creature.CreatureMerits);
            var weapons = _mapper.Map<IEnumerable<Weapon>>(creature.CreatureWeapons);
            var skills = _mapper.Map<IEnumerable<Skill>>(creature.CreatureSkills);

            return new GeneratedMonster(
                strength,
                vitality,
                body,
                agility,
                dexterity,
                intelligence,
                willpower,
                emotion,
                damageReduction,
                creature.Karma,
                creature.Difficulty,
                merits,
                weapons,
                skills);
        }
    }
}