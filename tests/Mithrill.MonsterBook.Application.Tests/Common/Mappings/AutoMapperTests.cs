using System.Linq;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;
using Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedSummon;
using Mithrill.MonsterBook.Domain;
using Mithrill.MonsterBook.Domain.Entities;
using Xunit;
using AttackType = Mithrill.MonsterBook.Application.Common.AttackType;
using Attribute = Mithrill.MonsterBook.Application.Common.Attribute;
using DamageType = Mithrill.MonsterBook.Application.Common.DamageType;
using Difficulty = Mithrill.MonsterBook.Application.Common.Difficulty;
using GeneratedNpcFlaw = Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc.Flaw;
using GeneratedNpcMerit = Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc.Merit;
using GeneratedNpcSkill = Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc.Skill;
using GeneratedNpcWeapon = Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc.Weapon;
using GeneratedNpcArmor = Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc.Armor;
using GeneratedSummonMerit = Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedSummon.Merit;
using GeneratedSummonSkill = Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedSummon.Skill;
using GeneratedSummonWeapon = Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedSummon.Weapon;
using GetNpcTemplate = Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate.NpcTemplate;
using GetNpcTemplateMerit = Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate.Merit;
using GetNpcTemplateFlaw = Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate.Flaw;
using GetNpcTemplateWeapon = Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate.Weapon;
using GetNpcTemplateArmor = Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate.Armor;
using GetNpcTemplateSkill = Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate.Skill;
using GetNpcTemplateAttackType = Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate.AttackType;
using CreateNpcTemplate = Mithrill.MonsterBook.Application.Npc.Command.CreateNpcTemplate.CreateNpcTemplateCommand;
using UpdateNpcTemplate = Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate.NpcTemplate;
using Material = Mithrill.MonsterBook.Application.Common.Material;
using Race = Mithrill.MonsterBook.Application.Common.Race;
using SkillCategory = Mithrill.MonsterBook.Application.Common.SkillCategory;
using SummonType = Mithrill.MonsterBook.Application.Common.SummonType;
using Mithrill.MonsterBook.Domain.ValueObjects;


namespace Mithrill.MonsterBook.Application.Tests.Common.Mappings;

public class AutoMapperTests
{
    private readonly IMapper _mapper;
    private readonly Fixture _fixture;

    public AutoMapperTests()
    {
        var mapperConfiguration = new MapperConfiguration(configure => configure.AddMaps(typeof(MappingProfile).Assembly), new NullLoggerFactory());
        _mapper = new Mapper(mapperConfiguration);

        _fixture = new Fixture();
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _fixture.RepeatCount = 1;
    }

    [Fact]
    public void AssertConfiguration()
    {
        _mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }

    /*
     * UpdateNpcTemplate => Domain.NpcTemplate
     */

    [Fact]
    internal void ApplicationDomainGeneratedCreature_To_GeneratedNpc()
    {
        //Arrange
        var generatedCreature = _fixture.Create<Domain.GeneratedCreature>();

        //Act
        var mappedObject = _mapper.Map<GeneratedNpc>(generatedCreature);

        //Assert
        mappedObject.Should().BeEquivalentTo(new GeneratedNpc(
            generatedCreature.Name,
            generatedCreature.Strength,
            generatedCreature.Vitality,
            generatedCreature.Body,
            generatedCreature.Agility,
            generatedCreature.Dexterity,
            generatedCreature.Intelligence,
            generatedCreature.Willpower,
            generatedCreature.Emotion,
            generatedCreature.DamageReduction,
            generatedCreature.Karma,
            generatedCreature.Difficulty,
            [
                new GeneratedNpcWeapon(
                    generatedCreature.Weapons.First().Id,
                    generatedCreature.Weapons.First().Name,
                    generatedCreature.Weapons.First().Material,
                    generatedCreature.Weapons.First().BaseAttackModifier,
                    generatedCreature.Weapons.First().BaseDefenseModifier,
                    generatedCreature.Weapons.First().BaseInitiativeModifier,
                    generatedCreature.Weapons.First().AdditionalAttackModifier,
                    generatedCreature.Weapons.First().AdditionalDefenseModifier,
                    generatedCreature.Weapons.First().AdditionalInitiativeModifier,
                    [
                        new AttackType(
                            generatedCreature.Weapons.First().AttackTypes.First().DamageType,
                            generatedCreature.Weapons.First().AttackTypes.First().NumberOfDices,
                            generatedCreature.Weapons.First().AttackTypes.First().GuaranteedDamage)
                    ])
            ],
            [
                new GeneratedNpcArmor(
                    generatedCreature.Armors.First().Id,
                    generatedCreature.Armors.First().Name,
                    generatedCreature.Armors.First().Material,
                    generatedCreature.Armors.First().BaseArmorClass,
                    generatedCreature.Armors.First().BaseMovementInhibitoryFactor,
                    generatedCreature.Armors.First().AdditionalArmorClass,
                    generatedCreature.Armors.First().AdditionalMovementInhibitoryFactor)
            ],
            [
                new GeneratedNpcSkill(
                    generatedCreature.Skills.First().Id,
                    generatedCreature.Skills.First().Name,
                    generatedCreature.Skills.First().Level,
                    generatedCreature.Skills.First().NumberOfDices,
                    generatedCreature.Skills.First().GuaranteedSuccesses)
            ],
            [
                new GeneratedNpcMerit(
                    generatedCreature.Merits.First().Id,
                    generatedCreature.Merits.First().Name)
            ],
            [
                new GeneratedNpcFlaw(
                    generatedCreature.Flaws.First().Id,
                    generatedCreature.Flaws.First().Name)
            ],
            generatedCreature.HitPoint,
            generatedCreature.ManaPoint,
            generatedCreature.PowerPoint
        ));
    }

    [Fact]
    internal void ApplicationDomainGeneratedCreature_To_GeneratedSummon()
    {
        //Arrange
        var generatedCreature = _fixture.Create<Domain.GeneratedCreature>();

        //Act
        var mappedObject = _mapper.Map<GeneratedNpc>(generatedCreature);

        //Assert
        mappedObject.Should().BeEquivalentTo(new GeneratedSummon(
            generatedCreature.Name,
            generatedCreature.Strength,
            generatedCreature.Vitality,
            generatedCreature.Body,
            generatedCreature.Agility,
            generatedCreature.Dexterity,
            generatedCreature.Intelligence,
            generatedCreature.Willpower,
            generatedCreature.Emotion,
            generatedCreature.Karma,
            generatedCreature.DamageReduction,
            [
                new GeneratedSummonWeapon(
                    generatedCreature.Weapons.First().Id,
                    generatedCreature.Weapons.First().Name,
                    generatedCreature.Weapons.First().Material,
                    generatedCreature.Weapons.First().BaseAttackModifier,
                    generatedCreature.Weapons.First().BaseDefenseModifier,
                    generatedCreature.Weapons.First().BaseInitiativeModifier,
                    generatedCreature.Weapons.First().AdditionalAttackModifier,
                    generatedCreature.Weapons.First().AdditionalDefenseModifier,
                    generatedCreature.Weapons.First().AdditionalInitiativeModifier,
                    [new AttackType(
                        generatedCreature.Weapons.First().AttackTypes.First().DamageType,
                        generatedCreature.Weapons.First().AttackTypes.First().NumberOfDices,
                        generatedCreature.Weapons.First().AttackTypes.First().GuaranteedDamage)])
            ],
            [
                new GeneratedSummonSkill(
                    generatedCreature.Skills.First().Id,
                    generatedCreature.Skills.First().Name,
                    generatedCreature.Skills.First().Level,
                    generatedCreature.Skills.First().NumberOfDices,
                    generatedCreature.Skills.First().GuaranteedSuccesses)
            ],
            [
                new GeneratedSummonMerit(
                    generatedCreature.Merits.First().Id,
                    generatedCreature.Merits.First().Name)
            ],
            generatedCreature.HitPoint,
            generatedCreature.ManaPoint,
            generatedCreature.PowerPoint
        ));
    }

    [Fact]
    internal void DomainNpcTemplate_To_GetNpcTemplate()
    {
        //Arrange
        var npcTemplate = _fixture.Create<NpcTemplate>();

        //Act
        var mappedObject = _mapper.Map<GetNpcTemplate>(npcTemplate);

        //Assert
        mappedObject.Should().BeEquivalentTo(new GetNpcTemplate(
            npcTemplate.Id,
            npcTemplate.Name,
            npcTemplate.StrengthMax,
            npcTemplate.StrengthMin,
            npcTemplate.VitalityMax,
            npcTemplate.VitalityMin,
            npcTemplate.BodyMax,
            npcTemplate.BodyMin,
            npcTemplate.AgilityMax,
            npcTemplate.AgilityMin,
            npcTemplate.DexterityMax,
            npcTemplate.DexterityMin,
            npcTemplate.IntelligenceMax,
            npcTemplate.IntelligenceMin,
            npcTemplate.WillpowerMax,
            npcTemplate.WillpowerMin,
            npcTemplate.EmotionMax,
            npcTemplate.EmotionMin,
            npcTemplate.KarmaMax,
            npcTemplate.KarmaMin,
            (Difficulty)npcTemplate.Difficulty,
            (Race)npcTemplate.Race,
            npcTemplate.IsUndead,
            npcTemplate.IsSummon,
            (SummonType?)npcTemplate.SummonType,
            [
                new GetNpcTemplateMerit(
                    npcTemplate.CharacterMerits.First().MeritId,
                    npcTemplate.CharacterMerits.First().Merit.Name,
                    npcTemplate.CharacterMerits.First().IsOptional)
            ],
            [
                new GetNpcTemplateFlaw(
                    npcTemplate.CharacterFlaws.First().FlawId,
                    npcTemplate.CharacterFlaws.First().Flaw.Name,
                    npcTemplate.CharacterFlaws.First().IsOptional)
            ],
            [
                new GetNpcTemplateWeapon(
                    npcTemplate.CharacterWeapons.First().WeaponId,
                    npcTemplate.CharacterWeapons.First().Weapon.Name,
                    npcTemplate.CharacterWeapons.First().Weapon.BaseAttackModifier,
                    npcTemplate.CharacterWeapons.First().Weapon.BaseDefenseModifier,
                    npcTemplate.CharacterWeapons.First().Weapon.BaseInitiativeModifier,
                    npcTemplate.CharacterWeapons.First().AdditionalAttackModifier,
                    npcTemplate.CharacterWeapons.First().AdditionalDefenseModifier,
                    npcTemplate.CharacterWeapons.First().AdditionalInitiativeModifier,
                    (Material)npcTemplate.CharacterWeapons.First().Material,
                    npcTemplate.CharacterWeapons.First().IsOptional,
                    [
                        new GetNpcTemplateAttackType(
                            npcTemplate.CharacterWeapons.First().Weapon.BaseAttackType.Id,
                            (DamageType)npcTemplate.CharacterWeapons.First().Weapon.BaseAttackType.DamageType,
                            npcTemplate.CharacterWeapons.First().Weapon.BaseAttackType.NumberOfDices,
                            npcTemplate.CharacterWeapons.First().Weapon.BaseAttackType.GuaranteedDamage,
                            true),
                        new GetNpcTemplateAttackType(
                            npcTemplate.CharacterWeapons.First().AdditionalAttackTypes.First().AttackType.Id,
                            (DamageType)npcTemplate.CharacterWeapons.First().AdditionalAttackTypes.First().AttackType.DamageType,
                            npcTemplate.CharacterWeapons.First().AdditionalAttackTypes.First().AttackType.NumberOfDices,
                            npcTemplate.CharacterWeapons.First().AdditionalAttackTypes.First().AttackType.GuaranteedDamage,
                            false)
                    ])
            ],
            [
                new GetNpcTemplateSkill(
                    npcTemplate.CharacterSkills.First().SkillId,
                    npcTemplate.CharacterSkills.First().Skill.Name,
                    npcTemplate.CharacterSkills.First().SkillLevelMin,
                    npcTemplate.CharacterSkills.First().SkillLevelMax,
                    npcTemplate.CharacterSkills.First().GuaranteedSuccesses,
                    npcTemplate.CharacterSkills.First().IsOptional,
                    (Attribute)npcTemplate.CharacterSkills.First().Skill.Attribute1,
                    (Attribute)npcTemplate.CharacterSkills.First().Skill.Attribute2,
                    (SkillCategory)npcTemplate.CharacterSkills.First().Skill.Category)
            ],
            [
                new GetNpcTemplateArmor(
                    npcTemplate.CharacterArmors.First().ArmorId,
                    npcTemplate.CharacterArmors.First().Armor.Name,
                    npcTemplate.CharacterArmors.First().Armor.BaseArmorClass,
                    npcTemplate.CharacterArmors.First().Armor.BaseMovementInhibitoryFactor,
                    (Material)npcTemplate.CharacterArmors.First().Material,
                    npcTemplate.CharacterArmors.First().AdditionalArmorClass,
                    npcTemplate.CharacterArmors.First().AdditionalMovementInhibitoryFactor,
                    npcTemplate.CharacterArmors.First().IsOptional)
            ],
            new SkillCategories(
                (SkillCategory)npcTemplate.CharacterSkillCategories.Primary,
                (SkillCategory)npcTemplate.CharacterSkillCategories.FirstSecondary,
                (SkillCategory)npcTemplate.CharacterSkillCategories.SecondSecondary,
                (SkillCategory)npcTemplate.CharacterSkillCategories.Tertiary),
            null
        ));
    }

    [Fact]
    internal void CreateNpcTemplate_To_DomainNpcTemplate()
    {
        //Arrange
        var npcTemplate = _fixture.Create<CreateNpcTemplate>();

        //Act
        var mappedObject = _mapper.Map<NpcTemplate>(npcTemplate);

        //Assert
        mappedObject.Should().BeEquivalentTo(new NpcTemplate
        {
            Name = npcTemplate.Name,
            StrengthMax = npcTemplate.StrengthMax,
            StrengthMin = npcTemplate.StrengthMin,
            VitalityMax = npcTemplate.VitalityMax,
            VitalityMin = npcTemplate.VitalityMin,
            BodyMax = npcTemplate.BodyMax,
            BodyMin = npcTemplate.BodyMin,
            AgilityMax = npcTemplate.AgilityMax,
            AgilityMin = npcTemplate.AgilityMin,
            DexterityMax = npcTemplate.DexterityMax,
            DexterityMin = npcTemplate.DexterityMin,
            IntelligenceMax = npcTemplate.IntelligenceMax,
            IntelligenceMin = npcTemplate.IntelligenceMin,
            WillpowerMax = npcTemplate.WillpowerMax,
            WillpowerMin = npcTemplate.WillpowerMin,
            EmotionMax = npcTemplate.EmotionMax,
            EmotionMin = npcTemplate.EmotionMin,
            KarmaMax = npcTemplate.KarmaMax,
            KarmaMin = npcTemplate.KarmaMin,
            DamageReductionMax = npcTemplate.DamageReductionMax,
            DamageReductionMin = npcTemplate.DamageReductionMin,
            Race = (MonsterBook.Domain.ValueObjects.Race)npcTemplate.Race,
            Difficulty = (MonsterBook.Domain.ValueObjects.Difficulty)npcTemplate.Difficulty,
            CharacterSkillCategories = new CharacterSkillCategories
            {
                Primary = (MonsterBook.Domain.ValueObjects.SkillCategory)npcTemplate.SkillCategories.Primary,
                FirstSecondary = (MonsterBook.Domain.ValueObjects.SkillCategory)npcTemplate.SkillCategories.FirstSecondary,
                SecondSecondary = (MonsterBook.Domain.ValueObjects.SkillCategory)npcTemplate.SkillCategories.SecondSecondary,
                Tertiary = (MonsterBook.Domain.ValueObjects.SkillCategory)npcTemplate.SkillCategories.Tertiary
            },
            IsUndead = npcTemplate.IsUndead,
            IsSummon = npcTemplate.IsSummon,
            SummonType = (MonsterBook.Domain.ValueObjects.SummonType?)npcTemplate.SummonType,
            CharacterMerits = npcTemplate.Merits.Select(merit => new CharacterMerit
            {
                MeritId = merit.Id,
                IsOptional = merit.IsOptional,
            }).ToList(),
            CharacterFlaws = npcTemplate.Flaws.Select(flaw => new CharacterFlaw
            {
                FlawId = flaw.Id,
                IsOptional = flaw.IsOptional
            }).ToList(),
            CharacterSkills = npcTemplate.Skills.Select(skill => new CharacterSkill
            {
                SkillId = skill.Id,
                IsOptional = skill.IsOptional,
                GuaranteedSuccesses = skill.GuaranteedSuccesses,
                SkillLevelMax = skill.MaxLevel,
                SkillLevelMin = skill.MinLevel
            }).ToList(),
            CharacterArmors = npcTemplate.Armors.Select(armor => new CharacterArmor
            {
                ArmorId = armor.Id,
                AdditionalArmorClass = armor.AdditionalArmorClass,
                AdditionalMovementInhibitoryFactor = armor.AdditionalMovementInhibitoryFactor,
                Material = (MonsterBook.Domain.ValueObjects.Material)armor.Material,
                IsOptional = armor.IsOptional
            }).ToList(),
            CharacterWeapons = npcTemplate.Weapons.Select(weapon => new CharacterWeapon
            {
                WeaponId = weapon.Id,
                IsOptional = weapon.IsOptional,
                Material = (MonsterBook.Domain.ValueObjects.Material)weapon.Material,
                AdditionalAttackModifier = weapon.AdditionalAttackModifier,
                AdditionalDefenseModifier = weapon.AdditionalDefenseModifier,
                AdditionalInitiativeModifier = weapon.AdditionalInitiativeModifier,
                AdditionalAttackTypes = weapon.AdditionalAttackTypes.Select(attackType => new CharacterWeaponAttackType
                {
                    WeaponId = weapon.Id,
                    AttackType = new MonsterBook.Domain.Entities.AttackType
                    {
                        DamageType = (MonsterBook.Domain.ValueObjects.DamageType)attackType.DamageType,
                        GuaranteedDamage = attackType.GuaranteedDamage,
                        NumberOfDices = attackType.NumberOfDices
                    }
                }).ToList()
            }).ToList()
        });
    }

    [Fact]
    internal void UpdateNpcTemplate_To_DomainNpcTemplate()
    {
        //Arrange
        var npcTemplate = _fixture.Create<UpdateNpcTemplate>();

        //Act
        var mappedObject = _mapper.Map<NpcTemplate>(npcTemplate);

        //Assert
        mappedObject.Should().BeEquivalentTo(new NpcTemplate
        {
            Id = npcTemplate.Id,
            Name = npcTemplate.Name,
            StrengthMax = npcTemplate.StrengthMax,
            StrengthMin = npcTemplate.StrengthMin,
            VitalityMax = npcTemplate.VitalityMax,
            VitalityMin = npcTemplate.VitalityMin,
            BodyMax = npcTemplate.BodyMax,
            BodyMin = npcTemplate.BodyMin,
            AgilityMax = npcTemplate.AgilityMax,
            AgilityMin = npcTemplate.AgilityMin,
            DexterityMax = npcTemplate.DexterityMax,
            DexterityMin = npcTemplate.DexterityMin,
            IntelligenceMax = npcTemplate.IntelligenceMax,
            IntelligenceMin = npcTemplate.IntelligenceMin,
            WillpowerMax = npcTemplate.WillpowerMax,
            WillpowerMin = npcTemplate.WillpowerMin,
            EmotionMax = npcTemplate.EmotionMax,
            EmotionMin = npcTemplate.EmotionMin,
            KarmaMax = npcTemplate.KarmaMax,
            KarmaMin = npcTemplate.KarmaMin,
            DamageReductionMax = npcTemplate.DamageReductionMax,
            DamageReductionMin = npcTemplate.DamageReductionMin,
            Race = (MonsterBook.Domain.ValueObjects.Race)npcTemplate.Race,
            Difficulty = (MonsterBook.Domain.ValueObjects.Difficulty)npcTemplate.Difficulty,
            CharacterSkillCategories = new CharacterSkillCategories
            {
                Primary = (MonsterBook.Domain.ValueObjects.SkillCategory)npcTemplate.SkillCategories.Primary,
                FirstSecondary = (MonsterBook.Domain.ValueObjects.SkillCategory)npcTemplate.SkillCategories.FirstSecondary,
                SecondSecondary = (MonsterBook.Domain.ValueObjects.SkillCategory)npcTemplate.SkillCategories.SecondSecondary,
                Tertiary = (MonsterBook.Domain.ValueObjects.SkillCategory)npcTemplate.SkillCategories.Tertiary
            },
            IsUndead = npcTemplate.IsUndead,
            IsSummon = npcTemplate.IsSummon,
            SummonType = (MonsterBook.Domain.ValueObjects.SummonType?)npcTemplate.SummonType,
            CharacterMerits = npcTemplate.Merits.Select(merit => new CharacterMerit
            {
                MeritId = merit.Id,
                IsOptional = merit.IsOptional,
            }).ToList(),
            CharacterFlaws = npcTemplate.Flaws.Select(flaw => new CharacterFlaw
            {
                FlawId = flaw.Id,
                IsOptional = flaw.IsOptional
            }).ToList(),
            CharacterSkills = npcTemplate.Skills.Select(skill => new CharacterSkill
            {
                SkillId = skill.Id,
                IsOptional = skill.IsOptional,
                GuaranteedSuccesses = skill.GuaranteedSuccesses,
                SkillLevelMax = skill.MaxLevel,
                SkillLevelMin = skill.MinLevel
            }).ToList(),
            CharacterArmors = npcTemplate.Armors.Select(armor => new CharacterArmor
            {
                ArmorId = armor.Id,
                AdditionalArmorClass = armor.AdditionalArmorClass,
                AdditionalMovementInhibitoryFactor = armor.AdditionalMovementInhibitoryFactor,
                Material = (MonsterBook.Domain.ValueObjects.Material)armor.Material,
                IsOptional = armor.IsOptional
            }).ToList(),
            CharacterWeapons = npcTemplate.Weapons.Select(weapon => new CharacterWeapon
            {
                WeaponId = weapon.Id,
                IsOptional = weapon.IsOptional,
                Material = (MonsterBook.Domain.ValueObjects.Material)weapon.Material,
                AdditionalAttackModifier = weapon.AdditionalAttackModifier,
                AdditionalDefenseModifier = weapon.AdditionalDefenseModifier,
                AdditionalInitiativeModifier = weapon.AdditionalInitiativeModifier,
                AdditionalAttackTypes = null
            }).ToList()
        });
    }
}