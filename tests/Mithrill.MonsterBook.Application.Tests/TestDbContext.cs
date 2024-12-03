using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Domain;
using Attribute = Mithrill.MonsterBook.Domain.Attribute;
using Difficulty = Mithrill.MonsterBook.Domain.Difficulty;
using SkillCategory = Mithrill.MonsterBook.Domain.SkillCategory;

namespace Mithrill.MonsterBook.Application.Tests
{
    public class TestDbContext : DbContext, IMonsterBookDbContext
    {
        public TestDbContext(DbContextOptions options) : base(options) { }

        public DbSet<NpcTemplate> NpcTemplates { get; set; }
        public DbSet<Merit> Merits { get; set; }
        public DbSet<Flaw> Flaws { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<MonsterBook.Domain.AttackType> AttackTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.DependencyInjection).Assembly);
        }
    }

    public class Seeds
    {
        public NpcTemplate NpcTemplate = new()
        {
            Name = "Creature",
            NameHu = "CreatureHu",
            CharacterFlaws = new List<CharacterFlaw>
            {
                new()
                {
                    NpcTemplateId = 1,
                    FlawId = 1,
                    Flaw = new Flaw
                    {
                        Id = 1,
                        Name = "FlawName",
                        NameHu = "FlawNameHu"
                    }
                }
            },
            CharacterMerits = new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = 1,
                    MeritId = 1,
                    Merit = new Merit
                    {
                        Id = 1,
                        Name = "MeritName",
                        NameHu = AttributeTraits.HitPointIncreaseTrait
                    }
                },
                new()
                {
                    NpcTemplateId = 1,
                    MeritId = 2,
                    Merit = new Merit
                    {
                        Id = 2,
                        Name = "MeritName",
                        NameHu = AttributeTraits.ManaPointIncreaseTrait
                    }
                }
            },
            CharacterSkillCategories = new CharacterSkillCategories
            {
                NpcTemplateId = 1,
                Id = 1,
                Primary = SkillCategory.Secular,
                FirstSecondary = SkillCategory.Combat,
                SecondSecondary = SkillCategory.Scholar,
                Tertiary = SkillCategory.Underworld
            },
            CharacterSkills = new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = 1,
                    SkillId = 1,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2,
                    GuaranteedSuccesses = 2,
                    Skill = new Skill
                    {
                        Id = 1,
                        Name = "SkillName",
                        NameHu = "SkillNameHu",
                        Attribute1 = Attribute.Dexterity,
                        Attribute2 = Attribute.Strength,
                        Category = SkillCategory.Combat
                    }
                }
            },
            CharacterWeapons = new List<CharacterWeapon>
            {
                new()
                {
                    NpcTemplateId = 1,
                    WeaponId = 1,
                    Weapon = new Weapon
                    {
                        Id = 1,
                        Name = "WeaponName",
                        NameHu = "WeaponNameHu"
                    }
                }
            },
            Difficulty = Difficulty.Newbie,
            AgilityMax = 8,
            AgilityMin = 4,
            BodyMax = 8,
            BodyMin = 4,
            DamageReductionMax = 8,
            DamageReductionMin = 4,
            DexterityMax = 8,
            DexterityMin = 4,
            EmotionMax = 8,
            EmotionMin = 4,
            IntelligenceMax = 8,
            IntelligenceMin = 4,
            StrengthMax = 8,
            StrengthMin = 4,
            VitalityMax = 8,
            VitalityMin = 4,
            WillpowerMax = 8,
            WillpowerMin = 4,
            Id = 1
        };

        public NpcTemplate UndeadNpcTemplate = new()
        {
            Name = "Creature",
            NameHu = "CreatureHu",
            IsUndead = true,
            KarmaMax = -3,
            KarmaMin = -3,
            CharacterFlaws = new List<CharacterFlaw>
            {
                new()
                {
                    NpcTemplateId = 1,
                    FlawId = 1,
                    Flaw = new Flaw
                    {
                        Id = 1,
                        Name = "FlawName",
                        NameHu = "FlawNameHu"
                    }
                }
            },
            CharacterMerits = new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = 1,
                    MeritId = 1,
                    Merit = new Merit
                    {
                        Id = 1,
                        Name = "MeritName",
                        NameHu = "MeritNameHu"
                    }
                }
            },
            CharacterSkillCategories = new CharacterSkillCategories
            {
                NpcTemplateId = 1,
                Id = 1,
                Primary = SkillCategory.Secular,
                FirstSecondary = SkillCategory.Combat,
                SecondSecondary = SkillCategory.Scholar,
                Tertiary = SkillCategory.Underworld
            },
            CharacterSkills = new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = 1,
                    SkillId = 1,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2,
                    GuaranteedSuccesses = 2,
                    Skill = new Skill
                    {
                        Id = 1,
                        Name = "SkillName",
                        NameHu = "SkillNameHu",
                        Attribute1 = Attribute.Dexterity,
                        Attribute2 = Attribute.Strength,
                        Category = SkillCategory.Combat
                    }
                }
            },
            CharacterWeapons = new List<CharacterWeapon>
            {
                new()
                {
                    NpcTemplateId = 1,
                    WeaponId = 1,
                    Weapon = new Weapon
                    {
                        Id = 1,
                        Name = "WeaponName",
                        NameHu = "WeaponNameHu"
                    }
                }
            },
            Difficulty = Difficulty.Newbie,
            AgilityMax = 8,
            AgilityMin = 4,
            BodyMax = 8,
            BodyMin = 4,
            DamageReductionMax = 8,
            DamageReductionMin = 4,
            DexterityMax = 8,
            DexterityMin = 4,
            EmotionMax = 8,
            EmotionMin = 4,
            IntelligenceMax = 8,
            IntelligenceMin = 4,
            StrengthMax = 8,
            StrengthMin = 4,
            VitalityMax = 8,
            VitalityMin = 4,
            WillpowerMax = 8,
            WillpowerMin = 4,
            Id = 1
        };
    }
}