using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Monsters.Query.GetGeneratedMonster;
using Mithrill.MonsterBook.Domain;
using Merit = Mithrill.MonsterBook.Application.Monsters.Query.GetGeneratedMonster.Merit;

namespace Mithrill.MonsterBook.Application.Common.Factories
{
    public class MonsterBuilder : INpcBuilder<GeneratedMonster>
    {
        private readonly IMapper _mapper;
        private readonly IMonsterBookDbContext _monsterBookDbContext;
        private readonly Random _random;
        private GeneratedMonster _monster = new GeneratedMonster();
        private Creature _queriedCreature;

        public MonsterBuilder(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
        {
            _random = new Random();
            _mapper = mapper;
            _monsterBookDbContext = monsterBookDbContext;
            Reset();
        }

        public void Reset()
        {
            _monster = new GeneratedMonster();
            _queriedCreature = new Creature();
        }

        public async Task GetMonsterFromDatabaseAsync(int id, CancellationToken cancellationToken)
        {
            _queriedCreature = await _monsterBookDbContext.Monsters
                .Where(m => m.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public void SetDefaultStats()
        {
            _monster.Strength = _random.Next(_queriedCreature.StrengthMin, _queriedCreature.StrengthMax + 1);
            _monster.Vitality = _random.Next(_queriedCreature.VitalityMin, _queriedCreature.VitalityMax + 1);
            _monster.Body = _random.Next(_queriedCreature.BodyMin, _queriedCreature.BodyMax + 1);
            _monster.Dexterity = _random.Next(_queriedCreature.AgilityMin, _queriedCreature.AgilityMax + 1);
            _monster.Dexterity = _random.Next(_queriedCreature.DexterityMin, _queriedCreature.DexterityMax + 1);
            _monster.Intelligence = _random.Next(_queriedCreature.IntelligenceMin, _queriedCreature.IntelligenceMax + 1);
            _monster.Willpower = _random.Next(_queriedCreature.WillpowerMin, _queriedCreature.WillpowerMax + 1);
            _monster.Emotion = _random.Next(_queriedCreature.EmotionMin, _queriedCreature.EmotionMax + 1);
            _monster.Difficulty = _queriedCreature.Difficulty;
        }

        public void AddRacialModifiers(bool isUndead)
        {
            if (!isUndead || _queriedCreature.IsUndead)
                return;

            _monster.Strength += 2;
            _monster.Body += 2;
        }

        public void AddMerits(Difficulty? difficulty)
        {
            int meritsToAdd;
            var meritList = _queriedCreature.CreatureMerits.ToList();
            var merits = new List<Merit>();

            switch (difficulty)
            {
                case Difficulty.Newbie:
                case Difficulty.Novice:
                case Difficulty.Rookie:
                    meritsToAdd = 1;
                    break;
                case Difficulty.Beginner:
                case Difficulty.Talented:
                    meritsToAdd = 2;
                    break;
                case Difficulty.Skilled:
                case Difficulty.Intermediate:
                    meritsToAdd = 3;
                    break;
                case Difficulty.Skillful:
                case Difficulty.Seasoned:
                    meritsToAdd = 4;
                    break;
                case Difficulty.Proficient:
                case Difficulty.Experienced:
                    meritsToAdd = 5;
                    break;
                case Difficulty.Advanced:
                case Difficulty.Senior:
                    meritsToAdd = 6;
                    break;
                case Difficulty.Expert:
                    meritsToAdd = 7;
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
                merits.Add(_mapper.Map<Merit>(chosenMerit));
                meritList.Remove(chosenMerit);
            }

            _monster.Merits = merits;
        }

        public void AddFlaws(Difficulty? difficulty)
        {
            throw new NotImplementedException("Currently generated monster cannot have any flaws.");
        }

        public void AddSkills(Difficulty? difficulty)
        {
            
        }

        public void AddEquipment(Difficulty? difficulty)
        {
            
        }

        //TODO: Figure out on what base would you give karma to an NPC
        public void GenerateKarma(Difficulty? difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Newbie:
                case Difficulty.Novice:
                case Difficulty.Rookie:
                case Difficulty.Beginner:
                case Difficulty.Talented:
                    _monster.Karma = 3;
                    break;
                case Difficulty.Skilled:
                case Difficulty.Intermediate:
                    _monster.Karma = 4;
                    break;
                case Difficulty.Skillful:
                case Difficulty.Seasoned:
                    _monster.Karma = 5;
                    break;
                case Difficulty.Proficient:
                case Difficulty.Experienced:
                    _monster.Karma = 6;
                    break;
                case Difficulty.Advanced:
                case Difficulty.Senior:
                case Difficulty.Expert:
                    _monster.Karma = 7;
                    break;
                default:
                    _monster.Karma = 0;
                    break;
            }
        }

        public void CalculateLifeSigns(bool isUndead)
        {
            CalculateHitPoints(isUndead);
            CalculateManaPoints();
            CalculatePowerPoints();
        }

        public GeneratedMonster GetNpc()
        {
            var monster = _monster;
            Reset();

            return monster;
        }

        private void CalculateManaPoints()
        {
            var mp = _monster.Intelligence + _monster.Willpower + _monster.Emotion;
            
            if (_monster.Merits.Any(m => m.Name == "Mágikus kehely"))
                mp += _monster.Intelligence + 3;

            if (_monster.Intelligence > 7)
                mp += _monster.Intelligence;

            _monster.ManaPoint = mp;
        }

        private void CalculateHitPoints(bool isUndead)
        {
            if (isUndead)
                _monster.HitPoint = (_monster.Strength + _monster.Body) * 5;
            else
            {
                var hp = _monster.Vitality * 4 + 5;
                if (_monster.Merits.Any(m => m.Name == "Szívósság"))
                    hp += _monster.Vitality;

                if (_monster.Body > 7)
                    hp *= 2;

                _monster.HitPoint = hp;
            }
        }

        private void CalculatePowerPoints()
        {
            _monster.PowerPoint = _monster.Karma * 3;
        }
    }
}