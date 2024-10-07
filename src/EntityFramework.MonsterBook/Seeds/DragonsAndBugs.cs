using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds
{
    public class DragonsAndBugs
    {
        private static int _identity;

        public DragonsAndBugs(int identitySeed)
        {
            _identity = identitySeed - 1;

        }

        public async Task<int> AddOrUpdateCreatures(DbContext dbContext)
        {
            await AddBoneDragonAsync(dbContext, GetIdentity());
            await AddBlueDragonAsync(dbContext, GetIdentity());
            await AddRedDragonAsync(dbContext, GetIdentity());
            await AddGreenDragonAsync(dbContext, GetIdentity());
            await AddWorkerBugAsync(dbContext, GetIdentity());
            await AddScoutBugAsync(dbContext, GetIdentity());
            await AddSoldierBugAsync(dbContext, GetIdentity());
            await AddCarverBugAsync(dbContext, GetIdentity());
            await AddQueenBugAsync(dbContext, GetIdentity());

            return _identity;
        }

        private static async Task AddQueenBugAsync(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Bug,
                    Name = "Queen bug",
                    NameHu = "Királynő",
                    Id = identity,
                    StrengthMax = 6,
                    StrengthMin = 4,
                    VitalityMax = 8,
                    VitalityMin = 6,
                    BodyMax = 30,
                    BodyMin = 15,
                    AgilityMax = 10,
                    AgilityMin = 6,
                    DexterityMax = 6,
                    DexterityMin = 4,
                    DamageReductionMax = 8,
                    DamageReductionMin = 3,
                    IntelligenceMax = 8,
                    IntelligenceMin = 8,
                    WillpowerMax = 14,
                    WillpowerMin = 14,
                    Difficulty = Difficulty.Demigodly
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureSkill>
            {
                new()
                {
                    CreatureId = identity,
                    SkillId = 15,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 6,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 8,
                    SkillLevelMax = 7,
                    SkillLevelMin = 3
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 70,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 10,
                    SkillLevelMax = 5,
                    SkillLevelMin = 1
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 72,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureWeapon>
            {
                new()
                {
                    CreatureId = identity,
                    WeaponId = 40
                },
                new()
                {
                    CreatureId = identity,
                    WeaponId = 43
                },
                new()
                {
                    CreatureId = identity,
                    WeaponId = 52
                },
                new()
                {
                    CreatureId = identity,
                    WeaponId = 53
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureMerit>
            {
                new()
                {
                    CreatureId = identity,
                    MeritId = 75
                }
            });
        }

        private static async Task AddCarverBugAsync(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Bug,
                    Name = "Carver bug",
                    NameHu = "Vájó",
                    Id = identity,
                    StrengthMax = 12,
                    StrengthMin = 8,
                    VitalityMax = 4,
                    VitalityMin = 3,
                    BodyMax = 30,
                    BodyMin = 20,
                    AgilityMax = 2,
                    AgilityMin = 1,
                    DexterityMax = 1,
                    DexterityMin = 1,
                    DamageReductionMax = 6,
                    DamageReductionMin = 1,
                    IntelligenceMax = 2,
                    IntelligenceMin = 2,
                    Difficulty = Difficulty.Veteran
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureSkill>
            {
                new()
                {
                    CreatureId = identity,
                    SkillId = 15,
                    SkillLevelMax = 4,
                    SkillLevelMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureWeapon>
            {
                new()
                {
                    CreatureId = identity,
                    WeaponId = 40
                },
                new()
                {
                    CreatureId = identity,
                    WeaponId = 43
                }
            });
        }

        private static async Task AddSoldierBugAsync(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Bug,
                    Name = "Soldier bug",
                    NameHu = "Katona",
                    Id = identity,
                    StrengthMax = 12,
                    StrengthMin = 6,
                    VitalityMax = 6,
                    VitalityMin = 3,
                    BodyMax = 14,
                    BodyMin = 8,
                    AgilityMax = 6,
                    AgilityMin = 4,
                    DexterityMax = 6,
                    DexterityMin = 4,
                    DamageReductionMax = 14,
                    DamageReductionMin = 4,
                    IntelligenceMax = 2,
                    IntelligenceMin = 2,
                    Difficulty = Difficulty.Demigodly
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureSkill>
            {
                new()
                {
                    CreatureId = identity,
                    SkillId = 15,
                    SkillLevelMax = 7,
                    SkillLevelMin = 2
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 70,
                    SkillLevelMax = 4,
                    SkillLevelMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureWeapon>
            {
                new()
                {
                    CreatureId = identity,
                    WeaponId = 40
                },
                new()
                {
                    CreatureId = identity,
                    WeaponId = 43
                },
                new()
                {
                    CreatureId = identity,
                    WeaponId = 52
                },
                new()
                {
                    CreatureId = identity,
                    WeaponId = 53
                }
            });
        }

        private static async Task AddScoutBugAsync(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Bug,
                    Name = "Scout bug",
                    NameHu = "Felderítő",
                    Id = identity,
                    StrengthMax = 4,
                    StrengthMin = 2,
                    VitalityMax = 6,
                    VitalityMin = 3,
                    BodyMax = 6,
                    BodyMin = 3,
                    AgilityMax = 10,
                    AgilityMin = 5,
                    DexterityMax = 6,
                    DexterityMin = 4,
                    IntelligenceMax = 4,
                    IntelligenceMin = 4,
                    DamageReductionMax = 6,
                    DamageReductionMin = 1,
                    Difficulty = Difficulty.Experienced
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureSkill>
            {
                new()
                {
                    CreatureId = identity,
                    SkillId = 14,
                    SkillLevelMax = 4,
                    SkillLevelMin = 1
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 8,
                    SkillLevelMax = 7,
                    SkillLevelMin = 3,
                    GuaranteedSuccesses = 2
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 32,
                    SkillLevelMax = 5,
                    SkillLevelMin = 1,
                    GuaranteedSuccesses = 2
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 70,
                    SkillLevelMax = 4,
                    SkillLevelMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureWeapon>
            {
                new()
                {
                    CreatureId = identity,
                    WeaponId = 40
                },
                new()
                {
                    CreatureId = identity,
                    WeaponId = 43
                }
            });
        }

        private static async Task AddWorkerBugAsync(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Bug,
                    Name = "Worker bug",
                    NameHu = "Dolgozó",
                    Id = identity,
                    StrengthMax = 10,
                    StrengthMin = 5,
                    VitalityMax = 6,
                    VitalityMin = 1,
                    BodyMax = 8,
                    BodyMin = 4,
                    AgilityMax = 3,
                    AgilityMin = 1,
                    DexterityMax = 2,
                    DexterityMin = 1,
                    DamageReductionMax = 6,
                    DamageReductionMin = 1,
                    IntelligenceMax = 1,
                    IntelligenceMin = 1,
                    Difficulty = Difficulty.Experienced
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureSkill>
            {
                new()
                {
                    CreatureId = identity,
                    SkillId = 15,
                    SkillLevelMax = 3,
                    SkillLevelMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureWeapon>
            {
                new()
                {
                    CreatureId = identity,
                    WeaponId = 40
                },
                new()
                {
                    CreatureId = identity,
                    WeaponId = 43
                }
            });
        }

        private static async Task AddGreenDragonAsync(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Dragon,
                    Name = "Green dragon",
                    NameHu = "Zöld sárkány",
                    Id = identity,
                    StrengthMax = 14,
                    StrengthMin = 6,
                    VitalityMax = 10,
                    VitalityMin = 6,
                    BodyMax = 20,
                    BodyMin = 8,
                    AgilityMax = 6,
                    AgilityMin = 3,
                    DexterityMax = 6,
                    DexterityMin = 3,
                    IntelligenceMax = 8,
                    IntelligenceMin = 4,
                    WillpowerMax = 8,
                    WillpowerMin = 4,
                    EmotionMax = 8,
                    EmotionMin = 4,
                    DamageReductionMax = 8,
                    DamageReductionMin = 4,
                    Difficulty = Difficulty.Godly
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureSkill>
            {
                new()
                {
                    CreatureId = identity,
                    SkillId = 15,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 70,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 49,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureWeapon>
            {
                new()
                {
                    WeaponId = 43,
                    CreatureId = identity
                },
                new()
                {
                    WeaponId = 40,
                    CreatureId = identity
                },
                new()
                {
                    WeaponId = 50,
                    CreatureId = identity
                }
            });
        }

        private static async Task AddRedDragonAsync(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Dragon,
                    Name = "Red dragon",
                    NameHu = "Vörös sárkány",
                    Id = identity,
                    StrengthMax = 30,
                    StrengthMin = 8,
                    VitalityMax = 10,
                    VitalityMin = 6,
                    BodyMax = 40,
                    BodyMin = 8,
                    AgilityMax = 6,
                    AgilityMin = 3,
                    DexterityMax = 6,
                    DexterityMin = 3,
                    IntelligenceMax = 8,
                    IntelligenceMin = 4,
                    WillpowerMax = 8,
                    WillpowerMin = 4,
                    EmotionMax = 6,
                    EmotionMin = 2,
                    DamageReductionMax = 14,
                    DamageReductionMin = 8,
                    Difficulty = Difficulty.Godly
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureSkill>
            {
                new()
                {
                    CreatureId = identity,
                    SkillId = 15,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 70,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 49,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 64,
                    SkillLevelMax = 9,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureWeapon>
            {
                new()
                {
                    WeaponId = 43,
                    CreatureId = identity
                },
                new()
                {
                    WeaponId = 40,
                    CreatureId = identity
                },
                new()
                {
                    WeaponId = 51,
                    CreatureId = identity
                }
            });
        }

        private static async Task AddBlueDragonAsync(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Dragon,
                    Name = "Blue dragon",
                    NameHu = "Kék sárkány",
                    Id = identity,
                    StrengthMax = 24,
                    StrengthMin = 6,
                    VitalityMax = 10,
                    VitalityMin = 6,
                    BodyMax = 30,
                    BodyMin = 8,
                    AgilityMax = 6,
                    AgilityMin = 4,
                    DexterityMax = 6,
                    DexterityMin = 4,
                    IntelligenceMax = 8,
                    IntelligenceMin = 4,
                    WillpowerMax = 6,
                    WillpowerMin = 4,
                    EmotionMax = 8,
                    EmotionMin = 2,
                    DamageReductionMax = 12,
                    DamageReductionMin = 6,
                    Difficulty = Difficulty.Godly
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureSkill>
            {
                new()
                {
                    CreatureId = identity,
                    SkillId = 15,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 70,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 49,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 65,
                    SkillLevelMax = 9,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureFlaw>
            {
                new()
                {
                    CreatureId = identity,
                    FlawId = 42
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureWeapon>
            {
                new()
                {
                    WeaponId = 43,
                    CreatureId = identity
                },
                new()
                {
                    WeaponId = 40,
                    CreatureId = identity
                },
                new()
                {
                    WeaponId = 50,
                    CreatureId = identity
                }
            });
        }

        private static async Task AddBoneDragonAsync(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Dragon,
                    Name = "Bone dragon",
                    NameHu = "Csontsárkány",
                    Id = identity,
                    StrengthMax = 32,
                    StrengthMin = 16,
                    BodyMax = 20,
                    BodyMin = 8,
                    AgilityMax = 3,
                    AgilityMin = 3,
                    DexterityMax = 3,
                    DexterityMin = 3,
                    IntelligenceMax = 8,
                    IntelligenceMin = 4,
                    WillpowerMax = 8,
                    WillpowerMin = 4,
                    EmotionMax = 8,
                    EmotionMin = 4,
                    KarmaMax = 7,
                    KarmaMin = 4,
                    DamageReductionMax = 10,
                    DamageReductionMin = 10,
                    Difficulty = Difficulty.Godly
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureSkill>
            {
                new()
                {
                    CreatureId = identity,
                    SkillId = 15,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 70,
                    SkillLevelMax = 5,
                    SkillLevelMin = 2
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 49,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new()
                {
                    CreatureId = identity,
                    SkillId = 68,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureMerit>
            {
                new()
                {
                    CreatureId = identity,
                    MeritId = 87
                },
                new()
                {
                    CreatureId = identity,
                    MeritId = 88
                },
                new()
                {
                    CreatureId = identity,
                    MeritId = 89
                },
                new()
                {
                    CreatureId = identity,
                    MeritId = 90
                },
                new()
                {
                    CreatureId = identity,
                    MeritId = 91
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new List<CreatureWeapon>
            {
                new()
                {
                    WeaponId = 43,
                    CreatureId = identity
                },
                new()
                {
                    WeaponId = 40,
                    CreatureId = identity
                },
                new()
                {
                    WeaponId = 49,
                    CreatureId = identity
                }
            });
        }

        private static int GetIdentity()
        {
            return _identity++;
        }
    }
}