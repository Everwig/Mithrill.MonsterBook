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

        public GeneratedMonster CreateMonster(Domain.Monster monster)
        {
            var strength = _random.Next(monster.StrengthMin, monster.StrengthMax + 1);
            var vitality = _random.Next(monster.VitalityMin, monster.VitalityMax + 1);
            var body = _random.Next(monster.BodyMin, monster.BodyMax + 1);
            var speed = _random.Next(monster.SpeedMin, monster.SpeedMax + 1);
            var agility = _random.Next(monster.AgilityMin, monster.AgilityMax + 1);
            var intelligence = _random.Next(monster.IntelligenceMin, monster.IntelligenceMax + 1);
            var willpower = _random.Next(monster.WillpowerMin, monster.WillpowerMax + 1);
            var sensation = _random.Next(monster.SensationMin, monster.SensationMax + 1);
            var damageReduction = _random.Next(monster.DamageReductionMin, monster.DamageReductionMax + 1);
            var merits = _mapper.Map<IEnumerable<Merit>>(monster.MonsterMerits);
            var weapons = _mapper.Map<IEnumerable<Weapon>>(monster.MonsterWeapons);
            var skills = _mapper.Map<IEnumerable<Skill>>(monster.MonsterSkills);

            return new GeneratedMonster(
                strength,
                vitality,
                body,
                speed,
                agility,
                intelligence,
                willpower,
                sensation,
                damageReduction,
                monster.Karma,
                monster.Difficulty,
                merits,
                weapons,
                skills);
        }
    }
}