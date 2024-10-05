using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Domain;
using CreatureSkillCategories = Mithrill.MonsterBook.Domain.CreatureSkillCategories;
using Difficulty = Mithrill.MonsterBook.Domain.Difficulty;
using Race = Mithrill.MonsterBook.Domain.Race;
using SkillCategories = Mithrill.MonsterBook.Domain.SkillCategories;

namespace Mithrill.MonsterBook.Application.Tests
{
    public class TestDbContext : DbContext, IMonsterBookDbContext
    {
        public TestDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Creature> Creatures { get; set; }
        public DbSet<Merit> Merits { get; set; }
        public DbSet<Flaw> Flaws { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.DependencyInjection).Assembly);
        }
    }

    public class Seeds
    {
        public Creature Creature = new()
        {
            Name = "Creature",
            NameHu = "CreatureHu",
            CreatureFlaws = new List<CreatureFlaw>
            {
                new()
                {
                    CreatureId = 1,
                    FlawId = 1,
                    Flaw = new Flaw
                    {
                        Id = 1,
                        Name = "FlawName",
                        NameHu = "FlawNameHu"
                    }
                }
            },
            CreatureMerits = new List<CreatureMerit>
            {
                new()
                {
                    CreatureId = 1,
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
                    CreatureId = 1,
                    MeritId = 2,
                    Merit = new Merit
                    {
                        Id = 2,
                        Name = "MeritName",
                        NameHu = AttributeTraits.ManaPointIncreaseTrait
                    }
                }
            },
            CreatureSkillCategories = new CreatureSkillCategories
            {
                CreatureId = 1,
                Id = 1,
                Primary = SkillCategories.Secular,
                FirstSecondary = SkillCategories.Combat,
                SecondSecondary = SkillCategories.Scholar,
                Tertiary = SkillCategories.Underworld
            },
            CreatureSkills = new List<CreatureSkill>
            {
                new()
                {
                    CreatureId = 1,
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
                        Category = SkillCategories.Combat
                    }
                }
            },
            CreatureWeapons = new List<CreatureWeapon>
            {
                new()
                {
                    CreatureId = 1,
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

        public Creature UndeadCreature = new()
        {
            Name = "Creature",
            NameHu = "CreatureHu",
            Race = Race.Undead,
            KarmaMax = -3,
            KarmaMin = -3,
            CreatureFlaws = new List<CreatureFlaw>
            {
                new()
                {
                    CreatureId = 1,
                    FlawId = 1,
                    Flaw = new Flaw
                    {
                        Id = 1,
                        Name = "FlawName",
                        NameHu = "FlawNameHu"
                    }
                }
            },
            CreatureMerits = new List<CreatureMerit>
            {
                new()
                {
                    CreatureId = 1,
                    MeritId = 1,
                    Merit = new Merit
                    {
                        Id = 1,
                        Name = "MeritName",
                        NameHu = "MeritNameHu"
                    }
                }
            },
            CreatureSkillCategories = new CreatureSkillCategories
            {
                CreatureId = 1,
                Id = 1,
                Primary = SkillCategories.Secular,
                FirstSecondary = SkillCategories.Combat,
                SecondSecondary = SkillCategories.Scholar,
                Tertiary = SkillCategories.Underworld
            },
            CreatureSkills = new List<CreatureSkill>
            {
                new()
                {
                    CreatureId = 1,
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
                        Category = SkillCategories.Combat
                    }
                }
            },
            CreatureWeapons = new List<CreatureWeapon>
            {
                new()
                {
                    CreatureId = 1,
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