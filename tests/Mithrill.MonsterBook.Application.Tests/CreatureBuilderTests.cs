﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Builders;
using Mithrill.MonsterBook.Domain;
using Xunit;
using Attribute = Mithrill.MonsterBook.Domain.Attribute;
using Difficulty = Mithrill.MonsterBook.Application.Common.Difficulty;

namespace Mithrill.MonsterBook.Application.Tests
{
    public class CreatureBuilderTests
    {
        private readonly IMonsterBookDbContext _monsterBookDbContext;
        private readonly INpcBuilder<IGeneratedCreature> _creatureBuilder;
        private static readonly CancellationToken CancellationToken = CancellationToken.None;

        public CreatureBuilderTests()
        {
            var mapperConfiguration = new MapperConfiguration(configure => configure.AddMaps(typeof(Common.Mappings.MappingProfile).Assembly));
            var mapper = new Mapper(mapperConfiguration);
            _monsterBookDbContext = new TestDbContext(
                new DbContextOptionsBuilder()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options);
            _creatureBuilder = new CreatureBuilder(mapper, _monsterBookDbContext);
        }

        #region Difficulty
        [Fact]
        public async Task Given_SetDefaultStatsIsCalledWithLowerDifficultyThenInDatabase_Then_DifficultyShouldBeEqualToWhatIsInTheDatabase()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats(Difficulty.Newbie);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Difficulty.Should().Be((Difficulty)npcTemplate.Difficulty);
        }

        [Fact]
        public async Task Given_SetDefaultStatsIsCalledWithHigherDifficultyThenInDatabase_Then_DifficultyShouldBeEqualToArgument()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats(Difficulty.Expert);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Difficulty.Should().Be(Difficulty.Expert);
        }

        [Fact]
        public async Task Given_SetDefaultStatsIsCalledWithOutDifficulty_Then_DifficultyShouldBeEqualToWhatItIsInDatabase()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats();
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Difficulty.Should().Be((Difficulty)npcTemplate.Difficulty);
        }
        #endregion

        #region Stats
        [Fact]
        public async Task Given_SetDefaultStatsCalledButMinMaxStatsAreBackWardsForAgility_Then_ShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.AgilityMax = 4;
            npcTemplate.AgilityMin = 8;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            Action action = () => _creatureBuilder.SetDefaultStats();

            //Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task Given_SetDefaultStatsIsCalledButMinMaxStatsAreBackWardsForAgility_Then_ShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.AgilityMax = 4;
            npcTemplate.AgilityMin = 8;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            Action action = () => _creatureBuilder.SetDefaultStats();

            //Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public async Task Given_SetRacialStatsIsCalledForLivingCreature_Then_ShouldNotIncreaseStrengthOrBody()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.AddRacialModifiers(false);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            using var assertionScope = new AssertionScope();
            generatedCreature.Strength.Should().Be(0);
            generatedCreature.Body.Should().Be(0);
        }

        [Fact]
        public async Task Given_SetRacialStatsIsCalledForUndeadCreatureThatIsStoredAsLiving_Then_ShouldIncreaseStrengthOrBody()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.AddRacialModifiers(true);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            using var assertionScope = new AssertionScope();
            generatedCreature.Strength.Should().Be(2);
            generatedCreature.Body.Should().Be(2);
        }

        [Fact]
        public async Task Given_SetRacialStatsIsCalledForUndeadCreatureThatIsStoredAsUndead_Then_ShouldNotIncreaseStrengthOrBody()
        {
            //Arrange
            var npcTemplate = new Seeds().UndeadNpcTemplate;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.AddRacialModifiers(true);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            using var assertionScope = new AssertionScope();
            generatedCreature.Strength.Should().Be(0);
            generatedCreature.Body.Should().Be(0);
        }
        #endregion

        #region Karma
        [Fact]
        public async Task Given_SetKarmaIsCalledForNewbieDifficultyForCreature_Then_KarmaShouldBeEqualToCreaturesBaseKarma()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.GenerateKarma(false, Difficulty.Newbie);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Karma.Should().Be(npcTemplate.KarmaMin);
        }

        [Fact]
        public async Task Given_SetKarmaIsCalledForVeteranDifficultyForCreatureWithNegativeKarma_Then_KarmaShouldBeNegativeAndDecreasedByTwoRelativeToCreaturesBaseKarma()
        {
            //Arrange
            var npcTemplate = new Seeds().UndeadNpcTemplate;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.GenerateKarma(true, Difficulty.Veteran);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Karma.Should().Be(npcTemplate.KarmaMin-2);
        }

        [Fact]
        public async Task Given_SetKarmaIsCalledForVeteranDifficultyForEvilCreatureWithNoKarma_Then_KarmaShouldBeNegativeAndDecreasedByTwoRelativeToCreaturesBaseKarma()
        {
            //Arrange
            var npcTemplate = new Seeds().UndeadNpcTemplate;
            npcTemplate.KarmaMax = 0;
            npcTemplate.KarmaMin = 0;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.GenerateKarma(true, Difficulty.Veteran);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Karma.Should().Be(-2);
        }

        [Fact]
        public async Task Given_SetKarmaIsCalledForVeteranDifficultyForGoodCreatureWithNoKarma_Then_KarmaShouldBePositiveAndIncreasedByTwoRelativeToCreaturesBaseKarma()
        {
            //Arrange
            var npcTemplate = new Seeds().UndeadNpcTemplate;
            npcTemplate.KarmaMax = 0;
            npcTemplate.KarmaMin = 0;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.GenerateKarma(false, Difficulty.Veteran);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Karma.Should().Be(2);
        }

        #endregion

        #region LifeSigns
        #region PowerPoint
        [Fact]
        public async Task Given_CalculateLifeSignsCalledForEvilCreature_Then_PowerPointsShouldBePositiveAndThreeTimesKarma()
        {
            //Arrange
            var npcTemplate = new Seeds().UndeadNpcTemplate;
            npcTemplate.KarmaMax = -3;
            npcTemplate.KarmaMin = -3;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.GenerateKarma(true);
            _creatureBuilder.CalculateLifeSigns(false);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.PowerPoint.Should().Be(9);
        }

        [Fact]
        public async Task Given_CalculateLifeSignsCalledForGoodCreature_Then_PowerPointsShouldCalculated()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.KarmaMax = 4;
            npcTemplate.KarmaMin = 4;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.GenerateKarma(false);
            _creatureBuilder.CalculateLifeSigns(false);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.PowerPoint.Should().Be(12);
        }
        #endregion

        #region ManaPoint
        [Fact]
        public async Task Given_CalculateLifeSignsCalledForCreatureBelowEightIntelligenceWithoutMerits_Then_ManaShouldBeCalculatedNormally()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.IntelligenceMax = 4;
            npcTemplate.IntelligenceMin = 4;
            npcTemplate.WillpowerMax = 4;
            npcTemplate.WillpowerMin = 4;
            npcTemplate.EmotionMax = 4;
            npcTemplate.EmotionMin = 4;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats();
            _creatureBuilder.CalculateLifeSigns(false);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.ManaPoint.Should().Be(12);
        }

        [Fact]
        public async Task Given_CalculateLifeSignsCalledForCreatureEightIntelligenceWithoutMerits_Then_IncreasedManaShouldBeCalculated()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.IntelligenceMax = 8;
            npcTemplate.IntelligenceMin = 8;
            npcTemplate.WillpowerMax = 4;
            npcTemplate.WillpowerMin = 4;
            npcTemplate.EmotionMax = 4;
            npcTemplate.EmotionMin = 4;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats();
            _creatureBuilder.CalculateLifeSigns(false);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.ManaPoint.Should().Be(24);
        }

        [Fact]
        public async Task Given_CalculateLifeSignsCalledForCreatureEightIntelligenceWithMerits_Then_IncreasedManaShouldBeCalculated()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.IntelligenceMax = 8;
            npcTemplate.IntelligenceMin = 8;
            npcTemplate.WillpowerMax = 4;
            npcTemplate.WillpowerMin = 4;
            npcTemplate.EmotionMax = 4;
            npcTemplate.EmotionMin = 4;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats();
            _creatureBuilder.AddMerits(Difficulty.Veteran);
            _creatureBuilder.CalculateLifeSigns(false);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.ManaPoint.Should().Be(35);
        }

        [Fact]
        public async Task Given_CalculateLifeSignsCalledForCreatureBelowEightIntelligenceWithMerits_Then_IncreasedManaShouldBeCalculated()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.IntelligenceMax = 4;
            npcTemplate.IntelligenceMin = 4;
            npcTemplate.WillpowerMax = 4;
            npcTemplate.WillpowerMin = 4;
            npcTemplate.EmotionMax = 4;
            npcTemplate.EmotionMin = 4;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats();
            _creatureBuilder.AddMerits(Difficulty.Veteran);
            _creatureBuilder.CalculateLifeSigns(false);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.ManaPoint.Should().Be(19);
        }
        #endregion

        #region HitPoints
        [Fact]
        public async Task Given_CalculateLifeSignsCalledForLivingCreatureBelowEightBodyWithoutMerits_Then_HpShouldBeCalculatedNormally()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.BodyMax = 4;
            npcTemplate.BodyMin = 4;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats();
            _creatureBuilder.CalculateLifeSigns(false);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.HitPoint.Should().Be(21);
        }

        [Fact]
        public async Task Given_CalculateLifeSignsCalledForLivingCreatureBelowEightBodyWithMerits_Then_HpShouldBeCalculatedNormally()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.BodyMax = 4;
            npcTemplate.BodyMin = 4;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats();
            _creatureBuilder.AddMerits(Difficulty.Veteran);
            _creatureBuilder.CalculateLifeSigns(false);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.HitPoint.Should().Be(25);
        }

        [Fact]
        public async Task Given_CalculateLifeSignsCalledForLivingCreatureWithEightBodyWithMerits_Then_IncreasedHpShouldBeCalculated()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.BodyMax = 8;
            npcTemplate.BodyMin = 8;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats();
            _creatureBuilder.AddMerits(Difficulty.Veteran);
            _creatureBuilder.CalculateLifeSigns(false);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.HitPoint.Should().Be(90);
        }

        [Fact]
        public async Task Given_CalculateLifeSignsCalledForLivingCreatureWithEightBodyWithoutMerits_Then_IncreasedHpShouldBeCalculated()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.BodyMax = 8;
            npcTemplate.BodyMin = 8;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats();
            _creatureBuilder.CalculateLifeSigns(false);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.HitPoint.Should().Be(74);
        }

        [Fact]
        public async Task Given_CalculateLifeSignsCalledForUndeadCreatureBelowEightBodyWithoutMerits_Then_UndeadHpShouldBeCalculated()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.StrengthMax = 4;
            npcTemplate.StrengthMin = 4;
            npcTemplate.BodyMax = 4;
            npcTemplate.BodyMin = 4;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats();
            _creatureBuilder.CalculateLifeSigns(true);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.HitPoint.Should().Be(40);
        }

        [Fact]
        public async Task Given_CalculateLifeSignsCalledForUndeadCreatureBelowEightBodyWithMerits_Then_UndeadHpShouldBeCalculated()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.StrengthMax = 4;
            npcTemplate.StrengthMin = 4;
            npcTemplate.BodyMax = 4;
            npcTemplate.BodyMin = 4;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats();
            _creatureBuilder.AddMerits(Difficulty.Veteran);
            _creatureBuilder.CalculateLifeSigns(true);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.HitPoint.Should().Be(40);
        }

        [Fact]
        public async Task Given_CalculateLifeSignsCalledForUndeadCreatureWithEightBodyWithMerits_Then_UndeadHpShouldBeCalculated()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.StrengthMax = 8;
            npcTemplate.StrengthMin = 8;
            npcTemplate.BodyMax = 8;
            npcTemplate.BodyMin = 8;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats();
            _creatureBuilder.AddMerits(Difficulty.Veteran);
            _creatureBuilder.CalculateLifeSigns(true);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.HitPoint.Should().Be(80);
        }

        [Fact]
        public async Task Given_CalculateLifeSignsCalledForUndeadCreatureWithEightBodyWithoutMerits_Then_UndeadHpShouldBeCalculated()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.StrengthMax = 8;
            npcTemplate.StrengthMin = 8;
            npcTemplate.BodyMax = 8;
            npcTemplate.BodyMin = 8;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.SetDefaultStats();
            _creatureBuilder.CalculateLifeSigns(true);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.HitPoint.Should().Be(80);
        }
        #endregion
        #endregion

        #region Skill
        [Fact]
        public async Task Given_AddSkillsCalledDifficultyNotSpecified_Then_SkillLevelShouldComeFromTheDatabase()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.CreatureSkills = new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = npcTemplate.Id,
                    NpcTemplate = npcTemplate,
                    SkillId = 1,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3,
                    GuaranteedSuccesses = 1,
                    Skill = new Skill
                    {
                        Id = 1,
                        Name = "Skill",
                        NameHu = "Skill",
                        Attribute1 = Attribute.Dexterity,
                        Attribute2 = Attribute.Strength,
                        Category = SkillCategory.Combat
                    }
                }
            };
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.AddSkills();
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Skills.Should().BeEquivalentTo(new[]
            {
                new Domain.Skill
                {
                    Name = npcTemplate.CreatureSkills.First().Skill.Name,
                    NameHu = npcTemplate.CreatureSkills.First().Skill.NameHu,
                    Level = 3,
                    GuaranteedSuccesses = npcTemplate.CreatureSkills.First().GuaranteedSuccesses,
                    Category = (Common.SkillCategory)npcTemplate.CreatureSkills.First().Skill.Category
                }
            });
        }

        [Fact]
        public async Task Given_AddSkillsCalledDifficultyExpert_Then_SkillLevelShouldBeIncreasedByOne()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.CreatureSkills = new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = npcTemplate.Id,
                    NpcTemplate = npcTemplate,
                    SkillId = 1,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3,
                    GuaranteedSuccesses = 1,
                    Skill = new Skill
                    {
                        Id = 1,
                        Name = "Skill",
                        NameHu = "Skill",
                        Attribute1 = Attribute.Dexterity,
                        Attribute2 = Attribute.Strength,
                        Category = SkillCategory.Combat
                    }
                }
            };
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.AddSkills(Difficulty.Expert);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Skills.Should().BeEquivalentTo(new[]
            {
                new Domain.Skill
                {
                    Name = npcTemplate.CreatureSkills.First().Skill.Name,
                    NameHu = npcTemplate.CreatureSkills.First().Skill.NameHu,
                    Level = 4,
                    GuaranteedSuccesses = npcTemplate.CreatureSkills.First().GuaranteedSuccesses,
                    Category = (Common.SkillCategory)npcTemplate.CreatureSkills.First().Skill.Category
                }
            });
        }
        #endregion

        #region Merits
        [Fact]
        public async Task Given_AddMeritsCalledDifficultyNotSpecified_Then_AllMeritsRegisteredToTheCreatureShouldBeAdded()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.AddMerits();
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Merits.Should().BeEquivalentTo(new []
            {
                new Domain.Merit
                {
                    Name = npcTemplate.CreatureMerits.First().Merit.Name,
                    NameHu = npcTemplate.CreatureMerits.First().Merit.NameHu
                },
                new Domain.Merit
                {
                    Name = npcTemplate.CreatureMerits.Last().Merit.Name,
                    NameHu = npcTemplate.CreatureMerits.Last().Merit.NameHu
                }
            });
        }

        [Fact]
        public async Task Given_AddMeritsCalledDifficultySetToNewbie_Then_OneMeritRegisteredToTheCreatureShouldBeAdded()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.AddMerits(Difficulty.Newbie);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Merits.Count().Should().Be(1);
        }

        [Fact]
        public async Task Given_AddMeritsCalledDifficultySetToDemigodly_Then_TwoMeritShouldBeAddedBecauseTheCreatureOnlyHaveTwoInDatabase()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.AddMerits(Difficulty.Demigodly);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Merits.Count().Should().Be(2);
            generatedCreature.Merits.Should().BeEquivalentTo(new []
            {
                new Domain.Merit
                {
                    Name = npcTemplate.CreatureMerits.First().Merit.Name,
                    NameHu = npcTemplate.CreatureMerits.First().Merit.NameHu
                },
                new Domain.Merit
                {
                    Name = npcTemplate.CreatureMerits.Last().Merit.Name,
                    NameHu = npcTemplate.CreatureMerits.Last().Merit.NameHu
                }
            });
        }
        #endregion

        #region Flaws

        private static List<CharacterFlaw> GetFlaws(int npcTemplateId)
        {
            return new List<CharacterFlaw>
            {
                new()
                {
                    NpcTemplateId = npcTemplateId,
                    FlawId = 1,
                    Flaw = new Flaw
                    {
                        Id = 1,
                        Name = "Flaw",
                        NameHu = "Flaw"
                    }
                },
                new()
                {
                    NpcTemplateId = npcTemplateId,
                    FlawId = 2,
                    Flaw = new Flaw
                    {
                        Id = 2,
                        Name = "Flaw",
                        NameHu = "Flaw"
                    }
                },
                new()
                {
                    NpcTemplateId = npcTemplateId,
                    FlawId = 3,
                    Flaw = new Flaw
                    {
                        Id = 3,
                        Name = "Flaw",
                        NameHu = "Flaw"
                    }
                },
                new()
                {
                    NpcTemplateId = npcTemplateId,
                    FlawId = 4,
                    Flaw = new Flaw
                    {
                        Id = 4,
                        Name = "Flaw",
                        NameHu = "Flaw"
                    }
                },
                new()
                {
                    NpcTemplateId = npcTemplateId,
                    FlawId = 5,
                    Flaw = new Flaw
                    {
                        Id = 5,
                        Name = "Flaw",
                        NameHu = "Flaw"
                    }
                },
                new()
                {
                    NpcTemplateId = npcTemplateId,
                    FlawId = 6,
                    Flaw = new Flaw
                    {
                        Id = 6,
                        Name = "Flaw",
                        NameHu = "Flaw"
                    }
                },
                new()
                {
                    NpcTemplateId = npcTemplateId,
                    FlawId = 7,
                    Flaw = new Flaw
                    {
                        Id = 7,
                        Name = "Flaw",
                        NameHu = "Flaw"
                    }
                }
            };
        }

        [Fact]
        public async Task Given_AddFlawsCalledDifficultyNotSpecified_Then_AllFlawsRegisteredToTheCreatureShouldBeAdded()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.CreatureFlaws = GetFlaws(npcTemplate.Id);
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.AddFlaws();
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Flaws.Count().Should().Be(7);
        }

        [Fact]
        public async Task Given_AddFlawsCalledDifficultySetToExpert_Then_ThreeOrFourFlawsShouldBeAddedToTheCreature()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.CreatureFlaws = GetFlaws(npcTemplate.Id);
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.AddFlaws(Difficulty.Expert);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Flaws.Count().Should().BeInRange(3, 4);
        }

        [Fact]
        public async Task Given_AddFlawsCalledDifficultySetToDemigodly_Then_ZeroFlawsShouldBeAddedToTheCreature()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            npcTemplate.CreatureFlaws = GetFlaws(npcTemplate.Id);
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.AddFlaws(Difficulty.Demigodly);
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Flaws.Count().Should().Be(0);
        }

        [Fact]
        public async Task Given_AddFlawsCalledWithOutDifficultySet_Then_OneFlawsShouldBeAddedToTheCreatureBecauseOnlyOneIsRegistredToItInTheDatabase()
        {
            //Arrange
            var npcTemplate = new Seeds().NpcTemplate;
            await _monsterBookDbContext.NpcTemplates.AddAsync(npcTemplate);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken);

            //Act
            await _creatureBuilder.GetMonsterFromDatabaseAsync(1, CancellationToken);
            _creatureBuilder.AddFlaws();
            var generatedCreature = _creatureBuilder.GetNpc();

            //Assert
            generatedCreature.Flaws.Count().Should().Be(1);
        }
        #endregion
    }
}