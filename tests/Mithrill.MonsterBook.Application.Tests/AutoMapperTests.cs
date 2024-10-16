using System.Linq;
using AutoFixture;
using AutoFixture.Kernel;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using Mithrill.MonsterBook.Application.Common;
using Xunit;

namespace Mithrill.MonsterBook.Application.Tests
{
    public class AutoMapperTests
    {
        private readonly IMapper _mapper;
        private readonly Fixture _fixture;

        public AutoMapperTests()
        {
            var mapperConfiguration = new MapperConfiguration(configure => configure.AddMaps(typeof(Common.Mappings.MappingProfile).Assembly));
            _mapper = new Mapper(mapperConfiguration);

            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _fixture.Customizations.Add(new TypeRelay(typeof(Common.Adapters.IMeritFlaw), typeof(Domain.Merit)));
            _fixture.Customizations.Add(new TypeRelay(typeof(Common.Adapters.IMeritFlaw), typeof(Domain.Flaw)));
            _fixture.Customizations.Add(new TypeRelay(typeof(Common.Adapters.IWeapon), typeof(Domain.Weapon)));
            _fixture.Customizations.Add(new TypeRelay(typeof(Common.Adapters.IAttackType), typeof(AttackType)));
            _fixture.Customizations.Add(new TypeRelay(typeof(Common.Adapters.ISkill), typeof(Domain.Skill)));
            _fixture.RepeatCount = 1;
        }

        [Fact]
        public void AssertConfiguration()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Fact]
        public void DomainAttackType_To_ApplicationDomainAttackType()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            fixture.RepeatCount = 1;
            var attackType = fixture.Create<MonsterBook.Domain.AttackType>();


            //Act
            var mappedObject = _mapper.Map<AttackType>(attackType);

            //Assert
            mappedObject.Should().BeEquivalentTo(new AttackType
            {
                NumberOfDices = attackType.NumberOfDices,
                DamageType = (DamageType)attackType.DamageType,
                GuaranteedDamage = attackType.GuaranteedDamage,
            });
        }

        [Fact]
        public void DomainCreatureSkillCategories_To_ApplicationDomainCreatureSkillCategories()
        {
            //Arrange
            var creatureSkillCategories = _fixture.Create<MonsterBook.Domain.CharacterSkillCategories>();

            //Act
            var mappedObject = _mapper.Map<SkillCategories>(creatureSkillCategories);

            //Assert
            mappedObject.Should().BeEquivalentTo(new SkillCategories
            {
                Primary = (SkillCategory)creatureSkillCategories.Primary,
                FirstSecondary = (SkillCategory)creatureSkillCategories.FirstSecondary,
                SecondSecondary = (SkillCategory)creatureSkillCategories.SecondSecondary,
                Tertiary = (SkillCategory)creatureSkillCategories.Tertiary
            });
        }
        
        [Fact]
        public void DomainFlaw_To_ApplicationDomainFlaw()
        {
            //Arrange
            var flaw = _fixture.Create<MonsterBook.Domain.Flaw>();

            //Act
            var mappedObject = _mapper.Map<Domain.Flaw>(flaw);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Domain.Flaw
            {
                Name = flaw.Name,
                NameHu = flaw.NameHu
            });
        }
        
        [Fact]
        public void DomainMerit_To_ApplicationDomainMerit()
        {
            //Arrange
            var merit = _fixture.Create<MonsterBook.Domain.Merit>();

            //Act
            var mappedObject = _mapper.Map<Domain.Merit>(merit);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Domain.Merit
            {
                Name = merit.Name,
                NameHu = merit.NameHu
            });
        }
        
        [Fact]
        public void DomainSkill_To_ApplicationDomainSkill()
        {
            //Arrange
            var skill = _fixture.Create<MonsterBook.Domain.Skill>();

            //Act
            var mappedObject = _mapper.Map<Domain.Skill>(skill);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Domain.Skill
            {
                Name = skill.Name,
                NameHu = skill.NameHu,
                Level = 0,
                Category = (SkillCategory)skill.Category
            });
        }
        
        [Fact]
        public void DomainWeapon_To_ApplicationDomainWeapon()
        {
            //Arrange
            var weapon = _fixture.Create<MonsterBook.Domain.Weapon>();

            //Act
            var mappedObject = _mapper.Map<Domain.Weapon>(weapon);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Domain.Weapon
            {
                Name = weapon.Name,
                NameHu = weapon.NameHu
            });
        }
        
        [Theory, AutoData]
        internal void ApplicationDomainAttackType_To_GeneratedNpcAttackType(AttackType attackType)
        {
            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedNpc.AttackType>(attackType);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedNpc.AttackType
            {
                GuaranteedDamage = attackType.GuaranteedDamage,
                NumberOfDices = attackType.NumberOfDices
            });
        }

        [Theory, AutoData]
        internal void ApplicationDomainSkill_To_GeneratedNpcSkill(Domain.Skill skill)
        {
            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedNpc.Skill>(skill);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedNpc.Skill
            {
                Name = skill.Name,
                NameHu = skill.NameHu,
                Level = skill.Level,
                Category = skill.Category,
                GuaranteedSuccesses = skill.GuaranteedSuccesses
            });
        }

        [Fact]
        internal void ApplicationDomainWeapon_To_GeneratedNpcWeapon()
        {
            //Arrange
            var weapon = _fixture.Create<Domain.Weapon>();

            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedNpc.Weapon>(weapon);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedNpc.Weapon
            {
                Name = weapon.Name,
                NameHu = weapon.NameHu,
                AttackType = new Npc.Query.GetGeneratedNpc.AttackType
                {
                    GuaranteedDamage = weapon.AttackType.GuaranteedDamage,
                    NumberOfDices = weapon.AttackType.NumberOfDices
                }
            });
        }

        [Fact]
        internal void ApplicationDomainGeneratedCreature_To_GeneratedNpc()
        {
            //Arrange
            var generatedCreature = _fixture.Create<Domain.GeneratedCreature>();

            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedNpc.GeneratedNpc>(generatedCreature);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedNpc.GeneratedNpc
            {
                Agility = generatedCreature.Agility,
                Body = generatedCreature.Body,
                DamageReduction = generatedCreature.DamageReduction,
                Dexterity = generatedCreature.Dexterity,
                Difficulty = generatedCreature.Difficulty,
                Emotion = generatedCreature.Emotion,
                HitPoint = generatedCreature.HitPoint,
                Intelligence = generatedCreature.Intelligence,
                ManaPoint = generatedCreature.ManaPoint,
                Strength = generatedCreature.Strength,
                Vitality = generatedCreature.Vitality,
                Willpower = generatedCreature.Willpower,
                Skills = new []
                {
                    new Npc.Query.GetGeneratedNpc.Skill
                    {
                        Name = generatedCreature.Skills.First().Name,
                        NameHu = generatedCreature.Skills.First().NameHu,
                        Level = generatedCreature.Skills.First().Level,
                        Category = generatedCreature.Skills.First().Category,
                        GuaranteedSuccesses = generatedCreature.Skills.First().GuaranteedSuccesses
                    }
                },
                Weapons = new []
                {
                    new Npc.Query.GetGeneratedNpc.Weapon
                    {
                        Name = generatedCreature.Weapons.First().Name,
                        NameHu = generatedCreature.Weapons.First().NameHu,
                        AttackType = new Npc.Query.GetGeneratedNpc.AttackType
                        {
                            GuaranteedDamage = generatedCreature.Weapons.First().AttackType.GuaranteedDamage,
                            NumberOfDices = generatedCreature.Weapons.First().AttackType.NumberOfDices
                        } 
                    }
                }
            });
        }

        [Theory, AutoData]
        internal void ApplicationDomainAttackType_To_GeneratedNpcWithKarmaAttackType(AttackType attackType)
        {
            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedNpcWithKarma.AttackType>(attackType);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedNpcWithKarma.AttackType
            {
                GuaranteedDamage = attackType.GuaranteedDamage,
                NumberOfDices = attackType.NumberOfDices
            });
        }

        [Theory, AutoData]
        internal void ApplicationDomainSkill_To_GetGeneratedNpcWithKarmaSkill(Domain.Skill skill)
        {
            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedNpcWithKarma.Skill>(skill);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedNpcWithKarma.Skill
            {
                Name = skill.Name,
                NameHu = skill.NameHu,
                Level = skill.Level,
                Category = skill.Category,
                GuaranteedSuccesses = skill.GuaranteedSuccesses
            });
        }

        [Fact]
        internal void ApplicationDomainWeapon_To_GetGeneratedNpcWithKarmaWeapon()
        {
            //Arrange
            var weapon = _fixture.Create<Domain.Weapon>();

            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedNpcWithKarma.Weapon>(weapon);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedNpcWithKarma.Weapon
            {
                Name = weapon.Name,
                NameHu = weapon.NameHu,
                AttackType = new Npc.Query.GetGeneratedNpc.AttackType
                {
                    GuaranteedDamage = weapon.AttackType.GuaranteedDamage,
                    NumberOfDices = weapon.AttackType.NumberOfDices
                }
            });
        }

        [Fact]
        internal void ApplicationDomainGeneratedCreature_To_GetGeneratedNpcWithKarma()
        {
            //Arrange
            var generatedCreature = _fixture.Create<Domain.GeneratedCreature>();

            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedNpcWithKarma.GeneratedNpcWithKarma>(generatedCreature);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedNpcWithKarma.GeneratedNpcWithKarma
            {
                Agility = generatedCreature.Agility,
                Body = generatedCreature.Body,
                DamageReduction = generatedCreature.DamageReduction,
                Dexterity = generatedCreature.Dexterity,
                Difficulty = generatedCreature.Difficulty,
                Emotion = generatedCreature.Emotion,
                HitPoint = generatedCreature.HitPoint,
                Intelligence = generatedCreature.Intelligence,
                ManaPoint = generatedCreature.ManaPoint,
                Strength = generatedCreature.Strength,
                Vitality = generatedCreature.Vitality,
                Willpower = generatedCreature.Willpower,
                Skills = new []
                {
                    new Npc.Query.GetGeneratedNpc.Skill
                    {
                        Name = generatedCreature.Skills.First().Name,
                        NameHu = generatedCreature.Skills.First().NameHu,
                        Level = generatedCreature.Skills.First().Level,
                        Category = generatedCreature.Skills.First().Category,
                        GuaranteedSuccesses = generatedCreature.Skills.First().GuaranteedSuccesses
                    }
                },
                Weapons = new []
                {
                    new Npc.Query.GetGeneratedNpc.Weapon
                    {
                        Name = generatedCreature.Weapons.First().Name,
                        NameHu = generatedCreature.Weapons.First().NameHu,
                        AttackType = new Npc.Query.GetGeneratedNpc.AttackType
                        {
                            GuaranteedDamage = generatedCreature.Weapons.First().AttackType.GuaranteedDamage,
                            NumberOfDices = generatedCreature.Weapons.First().AttackType.NumberOfDices
                        } 
                    }
                },
                PowerPoint = generatedCreature.PowerPoint,
                Karma = generatedCreature.Karma
            });
        }

        [Theory, AutoData]
        internal void ApplicationDomainAttackType_To_GeneratedProminentNpcAttackType(AttackType attackType)
        {
            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedProminentNpc.AttackType>(attackType);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedProminentNpc.AttackType
            {
                GuaranteedDamage = attackType.GuaranteedDamage,
                NumberOfDices = attackType.NumberOfDices
            });
        }

        [Theory, AutoData]
        internal void ApplicationDomainSkill_To_GeneratedProminentNpcSkill(Domain.Skill skill)
        {
            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedProminentNpc.Skill>(skill);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedProminentNpc.Skill
            {
                Name = skill.Name,
                NameHu = skill.NameHu,
                Level = skill.Level,
                Category = skill.Category,
                GuaranteedSuccesses = skill.GuaranteedSuccesses
            });
        }

        [Fact]
        internal void ApplicationDomainWeapon_To_GeneratedProminentNpcWeapon()
        {
            //Arrange
            var weapon = _fixture.Create<Domain.Weapon>();

            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedProminentNpc.Weapon>(weapon);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedProminentNpc.Weapon
            {
                Name = weapon.Name,
                NameHu = weapon.NameHu,
                AttackType = new Npc.Query.GetGeneratedNpc.AttackType
                {
                    GuaranteedDamage = weapon.AttackType.GuaranteedDamage,
                    NumberOfDices = weapon.AttackType.NumberOfDices
                }
            });
        }

        [Fact]
        public void ApplicationDomainFlaw_To_GeneratedProminentNpcFlaw()
        {
            //Arrange
            var flaw = _fixture.Create<Domain.Flaw>();

            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedProminentNpc.Flaw>(flaw);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedProminentNpc.Flaw
            {
                Name = flaw.Name,
                NameHu = flaw.NameHu
            });
        }
        
        [Fact]
        public void ApplicationDomainMerit_To_GeneratedProminentNpcMerit()
        {
            //Arrange
            var merit = _fixture.Create<Domain.Merit>();

            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedProminentNpc.Merit>(merit);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedProminentNpc.Merit
            {
                Name = merit.Name,
                NameHu = merit.NameHu
            });
        }

        [Fact]
        internal void ApplicationDomainGeneratedCreature_To_GeneratedProminentNpc()
        {
            //Arrange
            var generatedCreature = _fixture.Create<Domain.GeneratedCreature>();

            //Act
            var mappedObject = _mapper.Map<Npc.Query.GetGeneratedProminentNpc.GeneratedProminentNpc>(generatedCreature);

            //Assert
            mappedObject.Should().BeEquivalentTo(new Npc.Query.GetGeneratedProminentNpc.GeneratedProminentNpc
            {
                Agility = generatedCreature.Agility,
                Body = generatedCreature.Body,
                DamageReduction = generatedCreature.DamageReduction,
                Dexterity = generatedCreature.Dexterity,
                Difficulty = generatedCreature.Difficulty,
                Emotion = generatedCreature.Emotion,
                HitPoint = generatedCreature.HitPoint,
                Intelligence = generatedCreature.Intelligence,
                ManaPoint = generatedCreature.ManaPoint,
                Strength = generatedCreature.Strength,
                Vitality = generatedCreature.Vitality,
                Willpower = generatedCreature.Willpower,
                Skills = new []
                {
                    new Npc.Query.GetGeneratedProminentNpc.Skill
                    {
                        Name = generatedCreature.Skills.First().Name,
                        NameHu = generatedCreature.Skills.First().NameHu,
                        Level = generatedCreature.Skills.First().Level,
                        Category = generatedCreature.Skills.First().Category,
                        GuaranteedSuccesses = generatedCreature.Skills.First().GuaranteedSuccesses
                    }
                },
                Weapons = new []
                {
                    new Npc.Query.GetGeneratedProminentNpc.Weapon
                    {
                        Name = generatedCreature.Weapons.First().Name,
                        NameHu = generatedCreature.Weapons.First().NameHu,
                        AttackType = new Npc.Query.GetGeneratedProminentNpc.AttackType
                        {
                            GuaranteedDamage = generatedCreature.Weapons.First().AttackType.GuaranteedDamage,
                            NumberOfDices = generatedCreature.Weapons.First().AttackType.NumberOfDices
                        } 
                    }
                },
                Flaws = new []
                {
                    new Npc.Query.GetGeneratedProminentNpc.Flaw
                    {
                        Name = generatedCreature.Flaws.First().Name,
                        NameHu = generatedCreature.Flaws.First().NameHu
                    }
                },
                Merits = new []
                {
                    new Npc.Query.GetGeneratedProminentNpc.Merit
                    {
                        Name = generatedCreature.Merits.First().Name,
                        NameHu = generatedCreature.Merits.First().NameHu
                    }
                },
                PowerPoint = generatedCreature.PowerPoint,
                Karma = generatedCreature.Karma
            });
        }
    }
}