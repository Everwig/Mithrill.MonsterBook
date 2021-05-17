using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Builders;
using Xunit;

namespace Mithrill.MonsterBook.Application.Tests
{
    public class NpcDesignerTests
    {
        private readonly NpcDesigner<IGeneratedCreature> _npcDesigner;
        private readonly IMonsterBookDbContext _monsterBookDbContext;

        public NpcDesignerTests()
        {
            var mapperConfiguration = new MapperConfiguration(configure => configure.AddMaps(typeof(Common.Mappings.MappingProfile).Assembly));
            var mapper = new Mapper(mapperConfiguration);
            _monsterBookDbContext = new TestDbContext(
                new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            INpcBuilder<IGeneratedCreature> creatureBuilder = new CreatureBuilder(mapper, _monsterBookDbContext);
            _npcDesigner = new NpcDesigner<IGeneratedCreature>(creatureBuilder);
        }

        [Fact]
        public async Task Given_NoCreatureExitsInTheDatabase_Then_ReturnNullCreature()
        {
            //Arrange - Act
            await _npcDesigner.DesignNpcAsync(1, false, null, CancellationToken.None);
            var generatedCreature = _npcDesigner.GetNpc();

            //Assert
            generatedCreature.Should().BeNull();
        }

        [Fact]
        public async Task Given_DesignNpcAsyncCalled_Then_ReturnBasicCreature()
        {
            //Arrange
            var creature = new Seeds().Creature;
            var difficulty = creature.Difficulty;
            await _monsterBookDbContext.Creatures.AddAsync(creature);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken.None);

            //Act
            await _npcDesigner.DesignNpcAsync(1, false, null, CancellationToken.None);
            var c = _npcDesigner.GetNpc();

            //Assert
            using var assertionScope = new AssertionScope();
            c.Should().NotBeNull();
            c.Skills.Should().NotBeEmpty();
            c.Weapons.Should().NotBeEmpty();
            c.HitPoint.Should().BeGreaterThan(0);
            c.ManaPoint.Should().BeGreaterThan(0);
            c.PowerPoint.Should().Be(0);
            c.Karma.Should().Be(0);
            c.Flaws.Should().BeNull();
            c.Merits.Should().BeNull();
            c.CreatureSkillCategories.Should().BeNull();
            c.Difficulty.Should().Be(difficulty);
        }

        [Fact]
        public async Task Given_DesignNpcWithKarmaAsyncCalled_Then_ReturnCreatureWithKarma()
        {
            //Arrange
            const int karma = 4;
            var creature = new Seeds().Creature;
            creature.KarmaMax = karma;
            creature.KarmaMin = karma;
            var difficulty = creature.Difficulty;
            await _monsterBookDbContext.Creatures.AddAsync(creature);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken.None);

            //Act
            await _npcDesigner.DesignNpcWithKarmaAsync(1, false,false, null, CancellationToken.None);
            var c = _npcDesigner.GetNpc();

            //Assert
            using var assertionScope = new AssertionScope();
            c.Should().NotBeNull();
            c.Skills.Should().NotBeEmpty();
            c.Weapons.Should().NotBeEmpty();
            c.HitPoint.Should().BeGreaterThan(0);
            c.ManaPoint.Should().BeGreaterThan(0);
            c.PowerPoint.Should().Be(karma * 3);
            c.Karma.Should().Be(karma);
            c.Flaws.Should().BeNull();
            c.Merits.Should().BeNull();
            c.CreatureSkillCategories.Should().BeNull();
            c.Difficulty.Should().Be(difficulty);
        }

        [Fact]
        public async Task Given_DesignProminentNpcAsyncCalled_Then_ReturnProminentCreature()
        {
            //Arrange
            const int karma = 4;
            var creature = new Seeds().Creature;
            creature.KarmaMax = karma;
            creature.KarmaMin = karma;
            var difficulty = creature.Difficulty;
            await _monsterBookDbContext.Creatures.AddAsync(creature);
            await _monsterBookDbContext.SaveChangesAsync(CancellationToken.None);

            //Act
            await _npcDesigner.DesignProminentNpcAsync(1, false, false, Difficulty.Newbie, CancellationToken.None);
            var c = _npcDesigner.GetNpc();

            //Assert
            using var assertionScope = new AssertionScope();
            c.Should().NotBeNull();
            c.Skills.Should().NotBeEmpty();
            c.Weapons.Should().NotBeEmpty();
            c.HitPoint.Should().BeGreaterThan(0);
            c.ManaPoint.Should().BeGreaterThan(0);
            c.PowerPoint.Should().Be(karma * 3);
            c.Karma.Should().Be(karma);
            c.Flaws.Should().NotBeNullOrEmpty();
            c.Flaws.Should().NotBeNullOrEmpty();
            c.CreatureSkillCategories.Should().BeEquivalentTo(new CreatureSkillCategories
            {
                Primary = (SkillCategories)creature.CreatureSkillCategories.Primary,
                FirstSecondary = (SkillCategories)creature.CreatureSkillCategories.FirstSecondary,
                SecondSecondary = (SkillCategories)creature.CreatureSkillCategories.SecondSecondary,
                Tertiary = (SkillCategories)creature.CreatureSkillCategories.Tertiary
            });
            c.Difficulty.Should().Be(difficulty);
        }
    }
}