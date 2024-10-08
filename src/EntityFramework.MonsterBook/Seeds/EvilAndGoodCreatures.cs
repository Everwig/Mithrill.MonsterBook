using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds
{
    public class EvilAndGoodCreatures
    {
        private static int _identity;

        public EvilAndGoodCreatures(int identitySeed)
        {
            _identity = identitySeed - 1;
        }

        public async Task<int> AddOrUpdateCreatures(DbContext dbContext)
        {
            await AddShadow(dbContext, GetIdentity());
            await AddBaloth(dbContext, GetIdentity());
            await AddCerberus(dbContext, GetIdentity());
            await AddSkeleton(dbContext, GetIdentity());
            await AddDemon(dbContext, GetIdentity());
            await AddDuahinMagicZombie(dbContext, GetIdentity());
            await AddThousandFangs(dbContext, GetIdentity());
            await AddGhoul(dbContext, GetIdentity());
            await AddDeathKnight(dbContext, GetIdentity());
            await AddLich(dbContext, GetIdentity());
            await AddPoisonSpirit(dbContext, GetIdentity());
            await AddMummy(dbContext, GetIdentity());
            await AddHellhound(dbContext, GetIdentity());
            await AddRimsai(dbContext, GetIdentity());
            await AddSuccubus(dbContext, GetIdentity());
            await AddIncubus(dbContext, GetIdentity());
            await AddHoppingChewer(dbContext, GetIdentity());
            await AddVampire(dbContext, GetIdentity());
            await AddZombie(dbContext, GetIdentity());
            await AddGhost(dbContext, GetIdentity());
            await AddAngel(dbContext, GetIdentity());
            await AddSeraph(dbContext, GetIdentity());
            await AddGuardian(dbContext, GetIdentity());

            return _identity;
        }

        private static async Task AddDuahinMagicZombie(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.Undead,
                    Name = "Duahin magic zombie",
                    NameHu = "Duahini mágikus zombi",
                    Id = identity,
                    StrengthMax = 3,
                    StrengthMin = 3,
                    BodyMax = 3,
                    BodyMin = 3,
                    AgilityMax = 2,
                    AgilityMin = 2,
                    DexterityMax = 2,
                    DexterityMin = 2,
                    IntelligenceMax = 2,
                    IntelligenceMin = 2,
                    WillpowerMax = 3,
                    WillpowerMin = 3,
                    DamageReductionMax = 1,
                    DamageReductionMin = 1,
                    Difficulty = Difficulty.Newbie
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 14,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 87
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 88
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 89
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 90
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 91
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 92
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    WeaponId = 23,
                    NpcTemplateId = identity
                }
            });
        }

        private static async Task AddGhost(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.Undead,
                    Name = "Ghost",
                    NameHu = "Szellem",
                    Id = identity,
                    AgilityMax = 6,
                    AgilityMin = 6,
                    IntelligenceMax = 4,
                    IntelligenceMin = 1,
                    WillpowerMax = 4,
                    WillpowerMin = 1,
                    EmotionMax = 4,
                    EmotionMin = 1
                }
            });
        }

        private static async Task AddSeraph(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.CreatureOfLight,
                    Name = "Seraph",
                    NameHu = "Szeráf",
                    Id = identity,
                    StrengthMax = 5,
                    StrengthMin = 3,
                    VitalityMax = 4,
                    VitalityMin = 4,
                    BodyMax = 5,
                    BodyMin = 3,
                    AgilityMax = 5,
                    AgilityMin = 3,
                    DexterityMax = 5,
                    DexterityMin = 3,
                    IntelligenceMax = 7,
                    IntelligenceMin = 5,
                    WillpowerMax = 7,
                    WillpowerMin = 5,
                    EmotionMax = 7,
                    EmotionMin = 3,
                    Difficulty = Difficulty.Expert,
                    DamageReductionMax = 2,
                    DamageReductionMin = 0
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    GuaranteedSuccesses = 1,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 12,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 2,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 70,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 18,
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 29,
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 24
                }
            });
        }

        private static async Task AddAngel(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.CreatureOfLight,
                    Name = "Angel",
                    NameHu = "Angyal",
                    Difficulty = Difficulty.Variable,
                    Id = identity
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 4
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 13
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 18
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 67
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 16
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 51
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 49
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 86
                }
            });
        }

        private static async Task AddZombie(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.Undead,
                    Name = "Zombie",
                    NameHu = "Zombi",
                    Id = identity,
                    StrengthMax = 4,
                    StrengthMin = 4,
                    BodyMax = 3,
                    BodyMin = 3,
                    AgilityMax = 3,
                    AgilityMin = 3,
                    DexterityMax = 3,
                    DexterityMin = 3,
                    Difficulty = Difficulty.Newbie
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMax = 2,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 2,
                    SkillLevelMax = 2,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 14,
                    SkillLevelMax = 2,
                    SkillLevelMin = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 87
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 88
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 89
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 90
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 91
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    WeaponId = 23,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 32,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 24,
                    NpcTemplateId = identity
                }
            });
        }

        private static async Task AddVampire(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.Undead,
                    Name = "Vampire",
                    NameHu = "Vámpír",
                    Id = identity,
                    StrengthMax = 6,
                    StrengthMin = 6,
                    BodyMax = 6,
                    BodyMin = 6,
                    AgilityMax = 6,
                    AgilityMin = 6,
                    DexterityMax = 6,
                    DexterityMin = 6,
                    IntelligenceMax = 6,
                    IntelligenceMin = 6,
                    WillpowerMax = 6,
                    WillpowerMin = 6,
                    EmotionMax = 4,
                    EmotionMin = 4,
                    KarmaMax = 5,
                    KarmaMin = 0,
                    Difficulty = Difficulty.Expert
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 3,
                    SkillLevelMax = 5,
                    SkillLevelMin = 5
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 14,
                    SkillLevelMax = 5,
                    SkillLevelMin = 5
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 68,
                    SkillLevelMax = 3,
                    SkillLevelMin = 0
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 60,
                    SkillLevelMax = 2,
                    SkillLevelMin = 0
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 62,
                    SkillLevelMax = 2,
                    SkillLevelMin = 0
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 63,
                    SkillLevelMax = 2,
                    SkillLevelMin = 0
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 64,
                    SkillLevelMax = 2,
                    SkillLevelMin = 0
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 87
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 88
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 89
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 90
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 91
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    WeaponId = 32,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 24,
                    NpcTemplateId = identity
                }
            });
        }

        private static async Task AddHoppingChewer(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.Mythical,
                    Name = "Hopping Chewer",
                    NameHu = "Ugráló húsrágó",
                    Id = identity,
                    StrengthMax = 1,
                    StrengthMin = 1,
                    BodyMax = 1,
                    BodyMin = 1,
                    VitalityMax = 3,
                    VitalityMin = 3,
                    AgilityMax = 6,
                    AgilityMin = 4,
                    DexterityMax = 6,
                    DexterityMin = 4,
                    IntelligenceMax = 2,
                    IntelligenceMin = 2,
                    WillpowerMax = 5,
                    WillpowerMin = 5,
                    Difficulty = Difficulty.Newbie,
                    DamageReductionMax = 1,
                    DamageReductionMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMax = 4,
                    SkillLevelMin = 1
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 15,
                    SkillLevelMax = 4,
                    SkillLevelMin = 1
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 21,
                    SkillLevelMax = 4,
                    SkillLevelMin = 1
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 22,
                    SkillLevelMax = 5,
                    SkillLevelMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    WeaponId = 40,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 43,
                    NpcTemplateId = identity
                }
            });
        }

        private static async Task AddIncubus(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.CreatureOfDarkness,
                    Name = "Incubus",
                    NameHu = "Incubus",
                    Id = identity,
                    StrengthMax = 4,
                    StrengthMin = 2,
                    BodyMax = 4,
                    BodyMin = 2,
                    VitalityMax = 4,
                    VitalityMin = 4,
                    AgilityMax = 6,
                    AgilityMin = 6,
                    DexterityMax = 6,
                    DexterityMin = 6,
                    IntelligenceMax = 8,
                    IntelligenceMin = 4,
                    WillpowerMax = 4,
                    WillpowerMin = 4,
                    EmotionMax = 8,
                    EmotionMin = 4,
                    Difficulty = Difficulty.Expert
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 12,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 70,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 69,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 71,
                    SkillLevelMax = 5,
                    SkillLevelMin = 1
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 24,
                    SkillLevelMax = 7,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 33,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 50,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 28,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 49,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    WeaponId = 29,
                    NpcTemplateId = identity
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    MeritId = 50,
                    NpcTemplateId = identity
                },
                new()
                {
                    MeritId = 16,
                    NpcTemplateId = identity
                }
            });
        }

        private static async Task AddSuccubus(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
{
                new NpcTemplate
                {
                    Race = Race.CreatureOfDarkness,
                    Name = "Succubus",
                    NameHu = "Succubus",
                    Id = identity,
                    StrengthMax = 4,
                    StrengthMin = 2,
                    BodyMax = 4,
                    BodyMin = 2,
                    VitalityMax = 4,
                    VitalityMin = 4,
                    AgilityMax = 6,
                    AgilityMin = 6,
                    DexterityMax = 6,
                    DexterityMin = 6,
                    IntelligenceMax = 8,
                    IntelligenceMin = 4,
                    WillpowerMax = 4,
                    WillpowerMin = 4,
                    EmotionMax = 8,
                    EmotionMin = 4,
                    Difficulty = Difficulty.Expert
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 12,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 70,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 69,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 71,
                    SkillLevelMax = 5,
                    SkillLevelMin = 1
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 24,
                    SkillLevelMax = 7,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 33,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 50,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 28,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 49,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    WeaponId = 29,
                    NpcTemplateId = identity
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    MeritId = 50,
                    NpcTemplateId = identity
                },
                new()
                {
                    MeritId = 16,
                    NpcTemplateId = identity
                }
            });
        }

        private static async Task AddRimsai(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.CreatureOfDarkness,
                    Name = "Rimsai",
                    NameHu = "Rimsai",
                    Id = identity,
                    StrengthMax = 6,
                    StrengthMin = 4,
                    VitalityMax = 4,
                    VitalityMin = 4,
                    BodyMax = 6,
                    BodyMin = 4,
                    AgilityMax = 6,
                    AgilityMin = 4,
                    DexterityMax = 6,
                    DexterityMin = 4,
                    IntelligenceMax = 6,
                    IntelligenceMin = 4,
                    WillpowerMax = 6,
                    WillpowerMin = 3,
                    EmotionMax = 6,
                    EmotionMin = 3,
                    Difficulty = Difficulty.Expert,
                    DamageReductionMax = 2,
                    DamageReductionMin = 0
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    GuaranteedSuccesses = 1,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 12,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 2,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 70,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 18,
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 29,
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 24
                }
            });
        }

        private static async Task AddGuardian(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.Mythical,
                    Name = "Guardian",
                    NameHu = "Őr",
                    Id = identity,
                    StrengthMax = 10,
                    StrengthMin = 10,
                    BodyMax = 10,
                    BodyMin = 10,
                    AgilityMax = 8,
                    AgilityMin = 8,
                    DexterityMax = 8,
                    DexterityMin = 8,
                    IntelligenceMax = 6,
                    IntelligenceMin = 6,
                    Difficulty = Difficulty.Experienced,
                    DamageReductionMax = 10,
                    DamageReductionMin = 10
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 3,
                    SkillLevelMax = 5,
                    SkillLevelMin = 5
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 12,
                    SkillLevelMax = 5,
                    SkillLevelMin = 5
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 70,
                    SkillLevelMax = 5,
                    SkillLevelMin = 5
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 2,
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 21,
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 24
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 25,
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 27,
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 32
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 34,
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 86
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 90
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 93
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 94
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 95
                }
            });
        }

        private static async Task AddHellhound(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.CreatureOfDarkness,
                    Name = "Hellhound",
                    NameHu = "Pokolfarkas",
                    Id = identity,
                    StrengthMax = 9,
                    StrengthMin = 6,
                    VitalityMax = 4,
                    VitalityMin = 2,
                    BodyMax = 6,
                    BodyMin = 6,
                    AgilityMax = 5,
                    AgilityMin = 3,
                    DexterityMax = 5,
                    DexterityMin = 3,
                    IntelligenceMax = 2,
                    IntelligenceMin = 1,
                    WillpowerMax = 6,
                    WillpowerMin = 3,
                    EmotionMax = 8,
                    EmotionMin = 4,
                    Difficulty = Difficulty.Veteran
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 15,
                    SkillLevelMax = 4,
                    SkillLevelMin = 1
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 21,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 32,
                    SkillLevelMax = 4,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 72,
                    SkillLevelMax = 4,
                    SkillLevelMin = 4
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 48,
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 43
                }
            });
        }

        private static async Task AddMummy(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.Undead,
                    Name = "Mummy",
                    NameHu = "Múmia",
                    Id = identity,
                    StrengthMax = 6,
                    StrengthMin = 6,
                    BodyMax = 6,
                    BodyMin = 6,
                    AgilityMax = 6,
                    AgilityMin = 6,
                    DexterityMax = 6,
                    DexterityMin = 6,
                    IntelligenceMax = 8,
                    IntelligenceMin = 8,
                    WillpowerMax = 8,
                    WillpowerMin = 8,
                    EmotionMax = 8,
                    EmotionMin = 8,
                    KarmaMax = 6,
                    KarmaMin = 0,
                    Difficulty = Difficulty.Expert
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 3,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 14,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 68,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 60,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 61,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 62,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 63,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 64,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 65,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 66,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 87
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 88
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 89
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 90
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 91
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    WeaponId = 32,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 24,
                    NpcTemplateId = identity
                }
            });
        }

        private static async Task AddPoisonSpirit(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
{
                new NpcTemplate
                {
                    Race = Race.Undead,
                    Name = "Poison spirit",
                    NameHu = "Méreg szellem",
                    Id = identity,
                    AgilityMax = 6,
                    AgilityMin = 6,
                    DexterityMax = 6,
                    DexterityMin = 6,
                    IntelligenceMax = 2,
                    IntelligenceMin = 2,
                    WillpowerMax = 5,
                    WillpowerMin = 5,
                    EmotionMax = 3,
                    EmotionMin = 3,
                    Difficulty = Difficulty.Newbie
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 46
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 86
                }
            });
        }

        private static async Task AddLich(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.Undead,
                    Name = "Lich",
                    NameHu = "Lich",
                    Id = identity,
                    StrengthMax = 6,
                    StrengthMin = 6,
                    BodyMax = 5,
                    BodyMin = 5,
                    AgilityMax = 5,
                    AgilityMin = 5,
                    DexterityMax = 5,
                    DexterityMin = 5,
                    IntelligenceMax = 9,
                    IntelligenceMin = 9,
                    WillpowerMax = 9,
                    WillpowerMin = 9,
                    EmotionMax = 9,
                    EmotionMin = 9,
                    KarmaMax = 9,
                    KarmaMin = 3,
                    Difficulty = Difficulty.Experienced
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 3,
                    SkillLevelMax = 4,
                    SkillLevelMin = 4
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 14,
                    SkillLevelMax = 4,
                    SkillLevelMin = 4
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 68,
                    SkillLevelMax = 7,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 60,
                    SkillLevelMax = 3,
                    SkillLevelMin = 0
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 61,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 62,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 63,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 64,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 65,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 66,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 87
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 88
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 89
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 90
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 91
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    WeaponId = 32,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 24,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 47,
                    NpcTemplateId = identity
                }
            });
        }

        private static async Task AddDeathKnight(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.Undead,
                    Name = "Death Knight",
                    NameHu = "Halálúr",
                    Id = identity,
                    StrengthMax = 8,
                    StrengthMin = 8,
                    BodyMax = 8,
                    BodyMin = 8,
                    AgilityMax = 6,
                    AgilityMin = 6,
                    DexterityMax = 6,
                    DexterityMin = 6,
                    IntelligenceMax = 6,
                    IntelligenceMin = 6,
                    WillpowerMax = 6,
                    WillpowerMin = 6,
                    EmotionMax = 6,
                    EmotionMin = 6,
                    Difficulty = Difficulty.Experienced
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 3,
                    SkillLevelMax = 5,
                    SkillLevelMin = 5
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 4,
                    SkillLevelMax = 5,
                    SkillLevelMin = 5
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 14,
                    SkillLevelMax = 5,
                    SkillLevelMin = 5
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 87
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 88
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 89
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 90
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 91
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    WeaponId = 32,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 33,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 24,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 25,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 26,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 21,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 22,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 47,
                    NpcTemplateId = identity
                }
            });
        }

        private static async Task AddGhoul(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.Undead,
                    Name = "Ghoul",
                    NameHu = "Ghoul",
                    Id = identity,
                    StrengthMax = 5,
                    StrengthMin = 5,
                    BodyMax = 4,
                    BodyMin = 4,
                    AgilityMax = 5,
                    AgilityMin = 5,
                    DexterityMax = 4,
                    DexterityMin = 4,
                    IntelligenceMax = 1,
                    IntelligenceMin = 1,
                    WillpowerMax = 4,
                    WillpowerMin = 4,
                    EmotionMax = 1,
                    EmotionMin = 1,
                    Difficulty = Difficulty.Expert
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 3,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 14,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 87
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 88
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 89
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 90
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 91
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    WeaponId = 32,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 24,
                    NpcTemplateId = identity
                }
            });
        }

        private static async Task AddThousandFangs(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.CreatureOfDarkness,
                    Name = "Thousand fangs",
                    NameHu = "Ezerfog",
                    Id = identity,
                    StrengthMax = 15,
                    StrengthMin = 10,
                    VitalityMax = 10,
                    VitalityMin = 6,
                    BodyMax = 15,
                    BodyMin = 15,
                    AgilityMax = 2,
                    AgilityMin = 2,
                    DexterityMax = 2,
                    DexterityMin = 2,
                    IntelligenceMax = 1,
                    IntelligenceMin = 1,
                    WillpowerMax = 10,
                    WillpowerMin = 10,
                    Difficulty = Difficulty.Demigodly,
                    DamageReductionMax = 6,
                    DamageReductionMin = 6
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 15,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 72,
                    SkillLevelMax = 4,
                    SkillLevelMin = 4
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 40,
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 43
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 26
                }
            });
        }

        private static async Task AddDemon(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
{
                new NpcTemplate
                {
                    Race = Race.CreatureOfDarkness,
                    Difficulty = Difficulty.Variable,
                    Name = "Demon",
                    NameHu = "Démon",
                    Id = identity
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 11
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 18
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 13
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 68
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 46
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 49
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 86
                }
            });
        }

        private static async Task AddSkeleton(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
{
                new NpcTemplate
                {
                    Race = Race.Undead,
                    Name = "Skeleton",
                    NameHu = "Csontváz",
                    Id = identity,
                    StrengthMax = 3,
                    StrengthMin = 3,
                    BodyMax = 2,
                    BodyMin = 2,
                    AgilityMax = 3,
                    AgilityMin = 3,
                    DexterityMax = 3,
                    DexterityMin = 3,
                    Difficulty = Difficulty.Newbie
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMax = 1,
                    SkillLevelMin = 1
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 2,
                    SkillLevelMax = 1,
                    SkillLevelMin = 1
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 14,
                    SkillLevelMax = 1,
                    SkillLevelMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 87
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 88
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 90
                },
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 91
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    WeaponId = 23,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 32,
                    NpcTemplateId = identity
                },
                new()
                {
                    WeaponId = 24,
                    NpcTemplateId = identity
                }
            });
        }

        private static async Task AddCerberus(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.CreatureOfDarkness,
                    Name = "Cerberus",
                    NameHu = "Cerberus",
                    Id = identity,
                    StrengthMax = 6,
                    StrengthMin = 6,
                    BodyMax = 6,
                    BodyMin = 6,
                    VitalityMax = 6,
                    VitalityMin = 6,
                    AgilityMax = 6,
                    AgilityMin = 6,
                    DexterityMax = 6,
                    DexterityMin = 6,
                    IntelligenceMax = 6,
                    IntelligenceMin = 6,
                    WillpowerMax = 6,
                    WillpowerMin = 6,
                    EmotionMax = 6,
                    EmotionMin = 6
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 15,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 12,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMax = 7,
                    SkillLevelMin = 5
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 43
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 41
                }
            });
        }

        private static async Task AddBaloth(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.CreatureOfDarkness,
                    Name = "Baloth",
                    NameHu = "Baloth",
                    Id = identity,
                    StrengthMax = 10,
                    StrengthMin = 8,
                    VitalityMax = 5,
                    VitalityMin = 3,
                    BodyMax = 10,
                    BodyMin = 10,
                    AgilityMax = 8,
                    AgilityMin = 6,
                    DexterityMax = 4,
                    DexterityMin = 2,
                    IntelligenceMax = 1,
                    IntelligenceMin = 1,
                    Difficulty = Difficulty.Veteran,
                    DamageReductionMax = 5,
                    DamageReductionMin = 5
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 15,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 21,
                    SkillLevelMax = 6,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterWeapon>
            {
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 40,
                },
                new()
                {
                    NpcTemplateId = identity,
                    WeaponId = 43
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 26
                }
            });
        }

        private static async Task AddShadow(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Race = Race.CreatureOfDarkness,
                    Name = "Shadow",
                    NameHu = "Árny",
                    Id = identity,
                    StrengthMax = 4,
                    StrengthMin = 2,
                    VitalityMax = 3,
                    VitalityMin = 2,
                    BodyMax = 5,
                    BodyMin = 2,
                    AgilityMax = 4,
                    AgilityMin = 3,
                    DexterityMax = 4,
                    DexterityMin = 3,
                    IntelligenceMax = 8,
                    IntelligenceMin = 3,
                    WillpowerMax = 8,
                    WillpowerMin = 2,
                    EmotionMax = 8,
                    EmotionMin = 2,
                    KarmaMax = 5,
                    KarmaMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterSkill>
            {
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 2,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 68,
                    SkillLevelMax = 4,
                    SkillLevelMin = 3
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 58,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 50,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 46,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 49,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 60,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 61,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 62,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 63,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 64,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                },
                new()
                {
                    NpcTemplateId = identity,
                    SkillId = 65,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CharacterMerit>
            {
                new()
                {
                    NpcTemplateId = identity,
                    MeritId = 86
                }
            });
        }

        private static int GetIdentity()
        {
            return _identity++;
        }
    }
}