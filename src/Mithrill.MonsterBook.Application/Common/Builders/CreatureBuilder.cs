﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Domain;
using Flaw = Mithrill.MonsterBook.Application.Domain.Flaw;
using Merit = Mithrill.MonsterBook.Application.Domain.Merit;
using Weapon = Mithrill.MonsterBook.Application.Domain.Weapon;

namespace Mithrill.MonsterBook.Application.Common.Builders
{
    internal sealed class CreatureBuilder : INpcBuilder<IGeneratedCreature>
    {
        private readonly IMapper _mapper;
        private readonly IMonsterBookDbContext _monsterBookDbContext;
        private readonly Random _random;
        private GeneratedCreature _creature = new();
        private MonsterBook.Domain.NpcTemplate? _queriedCreature;

        public CreatureBuilder(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
        {
            _random = new Random();
            _mapper = mapper;
            _monsterBookDbContext = monsterBookDbContext;
            Reset();
        }

        public void Reset()
        {
            _creature = new GeneratedCreature();
            _queriedCreature = new MonsterBook.Domain.NpcTemplate();
        }

        public async Task GetMonsterFromDatabaseAsync(int id, CancellationToken cancellationToken)
        {
            _queriedCreature = await _monsterBookDbContext.NpcTemplates
                .Include(c => c.CharacterSkillCategories)
                .Include(c => c.CreatureFlaws)
                .ThenInclude(cf => cf.Flaw)
                .Include(c => c.CreatureMerits)
                .ThenInclude(cm => cm.Merit)
                .Include(c => c.CreatureSkills)
                .ThenInclude(cs => cs.Skill)
                .Include(c => c.CreatureWeapons)
                .ThenInclude(cw => cw.Weapon)
                .Where(m => m.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public void SetDefaultStats(Difficulty? difficulty)
        {
            if(_queriedCreature == null)
                return;

            _creature.Strength = _random.Next(_queriedCreature.StrengthMin, _queriedCreature.StrengthMax + 1);
            _creature.Vitality = _random.Next(_queriedCreature.VitalityMin, _queriedCreature.VitalityMax + 1);
            _creature.Body = _random.Next(_queriedCreature.BodyMin, _queriedCreature.BodyMax + 1);
            _creature.Agility = _random.Next(_queriedCreature.AgilityMin, _queriedCreature.AgilityMax + 1);
            _creature.Dexterity = _random.Next(_queriedCreature.DexterityMin, _queriedCreature.DexterityMax + 1);
            _creature.Intelligence = _random.Next(_queriedCreature.IntelligenceMin, _queriedCreature.IntelligenceMax + 1);
            _creature.Willpower = _random.Next(_queriedCreature.WillpowerMin, _queriedCreature.WillpowerMax + 1);
            _creature.Emotion = _random.Next(_queriedCreature.EmotionMin, _queriedCreature.EmotionMax + 1);
            _creature.DamageReduction = _random.Next(_queriedCreature.DamageReductionMin, _queriedCreature.DamageReductionMax + 1);
            _creature.Name = _queriedCreature.Name;

            _creature.Difficulty = difficulty == null
                ? (Difficulty) _queriedCreature.Difficulty
                : (int)difficulty < (int)_queriedCreature.Difficulty
                    ? (Difficulty) _queriedCreature.Difficulty
                    : difficulty.Value;
        }

        public void SetSkillCategories()
        {
            if(_queriedCreature == null)
                return;

            _creature.CreatureSkillCategories = _mapper.Map<CreatureSkillCategories>(_queriedCreature.CharacterSkillCategories);
        }

        public void AddRacialModifiers(bool isUndead)
        {
            if(_queriedCreature == null)
                return;

            if (!isUndead || _queriedCreature.Race == MonsterBook.Domain.Race.Undead)
                return;

            _creature.Strength += 2;
            _creature.Body += 2;
        }

        public void AddMerits(Difficulty? difficulty)
        {
            if(_queriedCreature == null)
                return;

            int meritsToAdd;
            var meritList = _queriedCreature.CreatureMerits.ToList();
            var merits = new List<Merit>();

            switch (difficulty)
            {
                case Difficulty.Newbie:
                    meritsToAdd = 1;
                    break;
                case Difficulty.Experienced:
                    meritsToAdd = 2;
                    break;
                case Difficulty.Expert:
                    meritsToAdd = _random.Next(3, 5);
                    break;
                case Difficulty.Veteran:
                    meritsToAdd = _random.Next(5, 7);
                    break;
                case Difficulty.Demigodly:
                    meritsToAdd = _random.Next(7, 9);
                    break;
                default:
                    meritsToAdd = _queriedCreature.CreatureMerits.Count;
                    break;
            }

            if (meritsToAdd > _queriedCreature.CreatureMerits.Count)
                meritsToAdd = _queriedCreature.CreatureMerits.Count;

            for (var i = 0; i < meritsToAdd; i++)
            {
                var meritIndex = _random.Next(0, meritList.Count);
                var chosenMerit = meritList.ElementAt(meritIndex);
                merits.Add(_mapper.Map<Merit>(chosenMerit.Merit));
                meritList.Remove(chosenMerit);
            }

            _creature.Merits = merits;
        }

        public void AddFlaws(Difficulty? difficulty)
        {
            if(_queriedCreature == null)
                return;

            int flawsToAdd;
            var flawList = _queriedCreature.CreatureFlaws.ToList();
            var flaws = new List<Flaw>();

            switch (difficulty)
            {
                case Difficulty.Newbie:
                    flawsToAdd = _random.Next(6, 8);
                    break;
                case Difficulty.Experienced:
                    flawsToAdd = _random.Next(5, 7);
                    break;
                case Difficulty.Expert:
                    flawsToAdd = _random.Next(3, 5);
                    break;
                case Difficulty.Veteran:
                    flawsToAdd = _random.Next(1, 3);
                    break;
                case Difficulty.Demigodly:
                case Difficulty.Godly:
                    flawsToAdd = 0;
                    break;
                default:
                    flawsToAdd = _queriedCreature.CreatureFlaws.Count;
                    break;
            }

            if (flawsToAdd > _queriedCreature.CreatureFlaws.Count)
                flawsToAdd = _queriedCreature.CreatureFlaws.Count;

            for (var i = 0; i < flawsToAdd; i++)
            {
                var flawIndex = _random.Next(0, flawList.Count);
                var chosenFlaw = flawList.ElementAt(flawIndex);
                flaws.Add(_mapper.Map<Flaw>(chosenFlaw.Flaw));
                flawList.Remove(chosenFlaw);
            }

            _creature.Flaws = flaws;
        }

        public void AddSkills(Difficulty? difficulty)
        {
            if(_queriedCreature == null)
                return;

            var difficultyIncrease = 0;

            switch (difficulty)
            {
                case Difficulty.Newbie:
                case Difficulty.Experienced:
                    break;
                case Difficulty.Expert:
                    difficultyIncrease = 1;
                    break;
                case Difficulty.Veteran:
                    difficultyIncrease = 2;
                    break;
                case Difficulty.Demigodly:
                    difficultyIncrease = 3;
                    break;
                case Difficulty.Godly:
                    difficultyIncrease = 4;
                    break;
            }

            var skills = new List<Skill>();

            foreach (var characterSkill in _queriedCreature.CreatureSkills)
            {
                var mappedSkill = _mapper.Map<Skill>(characterSkill.Skill);
                mappedSkill.Level = _random.Next(characterSkill.SkillLevelMin, characterSkill.SkillLevelMax + 1) + difficultyIncrease;
                mappedSkill.GuaranteedSuccesses = characterSkill.GuaranteedSuccesses;
                skills.Add(mappedSkill);
            }

            _creature.Skills = skills;
        }

        // TODO: Create service that can handle different difficulty and update the weapons if necessary
        public void AddWeapons(Difficulty? difficulty)
        {
            if(_queriedCreature == null)
                return;

            var weapons = _queriedCreature.CreatureWeapons.Select(queriedCreatureCreatureWeapon => _mapper.Map<Weapon>(queriedCreatureCreatureWeapon.Weapon)).ToList();
            _creature.Weapons = weapons;
        }

        public void GenerateKarma(bool isEvil, Difficulty? difficulty)
        {
            if(_queriedCreature == null)
                return;

            var absoluteKarma = _random.Next(Math.Abs(_queriedCreature.KarmaMin), Math.Abs(_queriedCreature.KarmaMax));

            switch (difficulty)
            {
                case Difficulty.Newbie:
                case Difficulty.Experienced:
                    break;
                case Difficulty.Expert:
                    absoluteKarma += 1;
                    break;
                case Difficulty.Veteran:
                    absoluteKarma += 2;
                    break;
                case Difficulty.Demigodly:
                    absoluteKarma += 3;
                    break;
                case Difficulty.Godly:
                    absoluteKarma += 4;
                    break;
            }

            _creature.Karma = isEvil || _queriedCreature.KarmaMin < 0
                ? absoluteKarma * -1
                : absoluteKarma;
        }

        public void CalculateLifeSigns(bool isUndead)
        {
            if(_queriedCreature == null)
                return;

            _creature.HitPoint = Calculators.CalculateHitPoints(
                _creature.Strength,
                _creature.Body,
                isUndead,
                _creature.Merits);

            _creature.ManaPoint = Calculators.CalculateManaPoints(
                _creature.Intelligence,
                _creature.Willpower,
                _creature.Emotion,
                _creature.Merits);

            _creature.PowerPoint = Calculators.CalculatePowerPoints(_creature.Karma);
        }

        public IGeneratedCreature GetNpc()
        {
            if(_queriedCreature == null)
                return GeneratedCreature.NullCreature();

            var monster = _creature;
            Reset();

            return monster;
        }
    }
}