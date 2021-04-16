using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds
{
    public static class Creatures
    {
        private static int _identity;

        public static Task AddOrUpdateCreatures(DbContext dbContext)
        {
            return Task.WhenAll(
                AddWolf(dbContext, GetIdentity()),
                AddHyena(dbContext, GetIdentity()),
                AddVenomousSnake(dbContext, GetIdentity()),
                AddNonVenomousSnake(dbContext, GetIdentity()),
                AddCrocodile(dbContext, GetIdentity()),
                AddDog(dbContext, GetIdentity()),
                AddHeavyHorse(dbContext, GetIdentity()),
                AddLightHorse(dbContext, GetIdentity()),
                AddCat(dbContext, GetIdentity()),
                AddBear(dbContext, GetIdentity()));
        }

        public static async Task AddWolf(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Name = "Wolf",
                    NameHu = "Farkas",
                    Karma = 0,
                    Difficulty = Difficulty.Novice,
                    DamageReductionMax = 0,
                    DamageReductionMin = 0,
                    IsUndead = false,
                    AgilityMax = 4,
                    AgilityMin = 3,
                    BodyMax = 3,
                    BodyMin = 3,
                    DexterityMax = 6,
                    DexterityMin = 5,
                    EmotionMax = 1,
                    EmotionMin = 1,
                    Id = identity,
                    IntelligenceMax = 1,
                    IntelligenceMin = 1,
                    StrengthMax = 3,
                    StrengthMin = 2,
                    VitalityMax = 5,
                    VitalityMin = 5,
                    WillpowerMax = 2,
                    WillpowerMin = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 21,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 32,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 34,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 40,
                    SkillLevelMax = 1,
                    SkillLevelMin = 1,
                    GuaranteedSuccesses = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 19,
                    SkillLevelMax = 2,
                    SkillLevelMin = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 1,
                    SkillLevelMax = 4,
                    SkillLevelMin = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 12,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 40
                }
            });
        }

        public static async Task AddHyena(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Hiéna",
                    Name = "Hyena",
                    Karma = 0,
                    AgilityMax = 5,
                    AgilityMin = 4,
                    BodyMax = 3,
                    BodyMin = 2,
                    DamageReductionMax = 0,
                    DamageReductionMin = 0,
                    DexterityMax = 6,
                    DexterityMin = 5,
                    Difficulty = Difficulty.Novice,
                    EmotionMax = 1,
                    EmotionMin = 1,
                    IntelligenceMax = 1,
                    IntelligenceMin = 1,
                    IsUndead = false,
                    StrengthMax = 3,
                    StrengthMin = 3,
                    VitalityMax = 5,
                    VitalityMin = 5,
                    WillpowerMax = 1,
                    WillpowerMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 21,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 32,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 34,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 1,
                    SkillLevelMax = 4,
                    SkillLevelMin = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 12,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 40
                }
            });
        }

        public static async Task AddVenomousSnake(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Mérges kígyó",
                    Name = "Venomous snake",
                    Karma = 0,
                    AgilityMax = 5,
                    AgilityMin = 3,
                    BodyMax = 2,
                    BodyMin = 1,
                    DamageReductionMax = 0,
                    DamageReductionMin = 0,
                    DexterityMax = 5,
                    DexterityMin = 3,
                    Difficulty = Difficulty.Novice,
                    EmotionMax = 0,
                    EmotionMin = 0,
                    IntelligenceMax = 0,
                    IntelligenceMin = 0,
                    IsUndead = false,
                    StrengthMax = 1,
                    StrengthMin = 2,
                    VitalityMax = 3,
                    VitalityMin = 3,
                    WillpowerMax = 2,
                    WillpowerMin = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 19,
                    SkillLevelMax = 2,
                    SkillLevelMin = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 34,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 36,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2,
                    GuaranteedSuccesses = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 1,
                    SkillLevelMax = 4,
                    SkillLevelMin = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 12,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 40
                }
            });
        }

        public static async Task AddNonVenomousSnake(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Nem mérges kígyó",
                    Name = "Non-venomous snake",
                    Karma = 0,
                    AgilityMax = 3,
                    AgilityMin = 2,
                    BodyMax = 5,
                    BodyMin = 3,
                    DamageReductionMax = 0,
                    DamageReductionMin = 0,
                    DexterityMax = 5,
                    DexterityMin = 3,
                    Difficulty = Difficulty.Novice,
                    EmotionMax = 0,
                    EmotionMin = 0,
                    IntelligenceMax = 0,
                    IntelligenceMin = 0,
                    IsUndead = false,
                    StrengthMax = 7,
                    StrengthMin = 3,
                    VitalityMax = 3,
                    VitalityMin = 3,
                    WillpowerMax = 2,
                    WillpowerMin = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 19,
                    SkillLevelMax = 2,
                    SkillLevelMin = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 34,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 36,
                    SkillLevelMax = 3,
                    SkillLevelMin = 2,
                    GuaranteedSuccesses = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 1,
                    SkillLevelMax = 4,
                    SkillLevelMin = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 12,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 5,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 40
                }
            });
        }

        public static async Task AddCrocodile(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Krokodil",
                    Name = "Crocodile",
                    Karma = 0,
                    AgilityMax = 4,
                    AgilityMin = 3,
                    BodyMax = 8,
                    BodyMin = 4,
                    DamageReductionMax = 4,
                    DamageReductionMin = 2,
                    DexterityMax = 3,
                    DexterityMin = 2,
                    Difficulty = Difficulty.Talented,
                    EmotionMax = 0,
                    EmotionMin = 0,
                    IntelligenceMax = 0,
                    IntelligenceMin = 0,
                    IsUndead = false,
                    StrengthMax = 7,
                    StrengthMin = 3,
                    VitalityMax = 7,
                    VitalityMin = 7,
                    WillpowerMax = 3,
                    WillpowerMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 19,
                    SkillLevelMax = 5, 
                    SkillLevelMin = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 34,
                    SkillLevelMax = 5,
                    SkillLevelMin = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 36,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 4,
                    SkillLevelMax = 4,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 41
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureMerit
                {
                    CreatureId = identity,
                    MeritId = 26
                }
            });
        }

        public static async Task AddDog(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Kutya",
                    Name = "Dog",
                    Karma = 0,
                    AgilityMax = 4,
                    AgilityMin = 3,
                    BodyMax = 3,
                    BodyMin = 2,
                    DamageReductionMax = 0,
                    DamageReductionMin = 0,
                    DexterityMax = 5,
                    DexterityMin = 4,
                    Difficulty = Difficulty.Novice,
                    EmotionMax = 2,
                    EmotionMin = 1,
                    IntelligenceMax = 2,
                    IntelligenceMin = 1,
                    IsUndead = false,
                    StrengthMax = 3,
                    StrengthMin = 2,
                    VitalityMax = 4,
                    VitalityMin = 4,
                    WillpowerMax = 2,
                    WillpowerMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 19,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 21,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 32,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 34,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 40,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 4,
                    SkillLevelMax = 4,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 40
                }
            });
        }
        
        public static async Task AddHeavyHorse(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Igás- és nehéz csataló",
                    Name = "Cart hourse and destrier",
                    Karma = 0,
                    AgilityMax = 4,
                    AgilityMin = 3,
                    BodyMax = 6,
                    BodyMin = 5,
                    DamageReductionMax = 0,
                    DamageReductionMin = 0,
                    DexterityMax = 5,
                    DexterityMin = 4,
                    Difficulty = Difficulty.Beginner,
                    EmotionMax = 2,
                    EmotionMin = 1,
                    IntelligenceMax = 2,
                    IntelligenceMin = 1,
                    IsUndead = false,
                    StrengthMax = 8,
                    StrengthMin = 7,
                    VitalityMax = 4,
                    VitalityMin = 4,
                    WillpowerMax = 2,
                    WillpowerMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 19,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 21,
                    SkillLevelMax = 3,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 22,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 3,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 1,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 43
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 44
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureMerit
                {
                    CreatureId = identity,
                    MeritId = 26
                }
            });
        }

        public static async Task AddLightHorse(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Utazó ló és könnyű csataló",
                    Name = "Steed",
                    Karma = 0,
                    AgilityMax = 6,
                    AgilityMin = 5,
                    BodyMax = 6,
                    BodyMin = 5,
                    DamageReductionMax = 0,
                    DamageReductionMin = 0,
                    DexterityMax = 5,
                    DexterityMin = 4,
                    Difficulty = Difficulty.Beginner,
                    EmotionMax = 2,
                    EmotionMin = 1,
                    IntelligenceMax = 2,
                    IntelligenceMin = 1,
                    IsUndead = false,
                    StrengthMax = 6,
                    StrengthMin = 5,
                    VitalityMax = 4,
                    VitalityMin = 4,
                    WillpowerMax = 2,
                    WillpowerMin = 1
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 19,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 21,
                    SkillLevelMax = 3,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 22,
                    SkillLevelMax = 2,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 3,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 1,
                    SkillLevelMax = 3,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 43
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 44
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureMerit
                {
                    CreatureId = identity,
                    MeritId = 26
                }
            });
        }

        public static async Task AddCat(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Macska",
                    Name = "Cat",
                    Karma = 0,
                    AgilityMax = 6,
                    AgilityMin = 6,
                    BodyMax = 1,
                    BodyMin = 1,
                    DamageReductionMax = 0,
                    DamageReductionMin = 0,
                    DexterityMax = 7,
                    DexterityMin = 6,
                    Difficulty = Difficulty.Novice,
                    EmotionMax = 1,
                    EmotionMin = 1,
                    IntelligenceMax = 1,
                    IntelligenceMin = 1,
                    IsUndead = false,
                    StrengthMax = 1,
                    StrengthMin = 1,
                    VitalityMax = 3,
                    VitalityMin = 3,
                    WillpowerMax = 3,
                    WillpowerMin = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 21,
                    SkillLevelMax = 1,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 32,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 34,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 40,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 1,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 40
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 43
                }
            });
        }

        public static async Task AddBear(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Medve",
                    Name = "Bear",
                    Karma = 0,
                    AgilityMax = 5,
                    AgilityMin = 4,
                    BodyMax = 8,
                    BodyMin = 5,
                    DamageReductionMax = 2,
                    DamageReductionMin = 2,
                    DexterityMax = 4,
                    DexterityMin = 3,
                    Difficulty = Difficulty.Talented,
                    EmotionMax = 1,
                    EmotionMin = 1,
                    IntelligenceMax = 1,
                    IntelligenceMin = 1,
                    IsUndead = false,
                    StrengthMax = 7,
                    StrengthMin = 5,
                    VitalityMax = 5,
                    VitalityMin = 5,
                    WillpowerMax = 3,
                    WillpowerMin = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 19,
                    SkillLevelMax = 2,
                    SkillLevelMin = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 20,
                    SkillLevelMax = 2,
                    SkillLevelMin = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 21,
                    SkillLevelMax = 1,
                    SkillLevelMin = 1
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 32,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 34,
                    SkillLevelMax = 4,
                    SkillLevelMin = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 3,
                    SkillLevelMax = 4,
                    SkillLevelMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 41
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 43
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureMerit
                {
                    CreatureId = identity,
                    MeritId = 26
                }
            });
        }

        private static int GetIdentity()
        {
             return _identity++;
        }
         
        public static async Task AddImperialRegularSoldier(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Birodalmi reguláris katona",
                    Name = "Imperial regular soldier",
                    Karma = 0,
                    AgilityMax = 4,
                    AgilityMin = 3,
                    BodyMax = 4,
                    BodyMin = 3,
                    DamageReductionMax = 2,
                    DamageReductionMin = 2,
                    DexterityMax = 4,
                    DexterityMin = 3,
                    Difficulty = Difficulty.Beginner,
                    EmotionMax = 3,
                    EmotionMin = 3,
                    IntelligenceMax = 4,
                    IntelligenceMin = 4,
                    IsUndead = false,
                    StrengthMax = 6,
                    StrengthMin = 4,
                    VitalityMax = 2,
                    VitalityMin = 2,
                    WillpowerMax = 3,
                    WillpowerMin = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 3,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 13,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 7,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 5,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 18,
                    SkillLevelMin = 1, 
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 6,
                    SkillLevelMin = 1, 
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 8,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 70,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 9,
                    SkillLevelMin = 1, 
                    SkillLevelMax = 1
                }
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 14,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                }, 
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 24
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 2
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 47
                }
            });        
        }
        
        public static async Task AddImperialRegularSoldier(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Birodalmi veterán katona",
                    Name = "Imperial veteran soldier",
                    Karma = 0,
                    StrengthMin = 5,
                    StrengthMax = 7,
                    VitalityMin = 2,
                    VitalityMax = 3,
                    BodyMin = 5,
                    BodyMax = 6,
                    AgilityMin = 4,
                    AgilityMax = 6,
                    DexterityMin = 4,
                    DexterityMax = 6,
                    IntelligenceMin = 4,
                    IntelligenceMax = 5,
                    WillpowerMin = 4,
                    WillpowerMax = 4,
                    EmotionMin = 3,
                    EmotionMax = 3,
                    DamageReductionMin = 4,
                    DamageReductionMax = 4,
                    IsUndead = false,
                    Difficulty = Difficulty.Skilled
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 3,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 13,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 7,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 5,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 14,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 3
                }, 
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 18,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 6,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 8,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 70,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 16,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 30,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 56,
                    SkillLevelMin = 1, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 10,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 9,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                }                
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 24
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 3
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 8
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 47
                }
            });        
        }

        public static async Task AddImperialBodyguard(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Birodalmi testőr gárdista",
                    Name = "Imperial bodyguard",
                    Karma = 0,
                    StrengthMin = 6,
                    StrengthMax = 8,
                    VitalityMin = 3,
                    VitalityMax = 4,
                    BodyMin = 5,
                    BodyMax = 6,
                    AgilityMin = 4,
                    AgilityMax = 6,
                    DexterityMin = 4,
                    DexterityMax = 6,
                    IntelligenceMin = 4,
                    IntelligenceMax = 5,
                    WillpowerMin = 4,
                    WillpowerMax = 5,
                    EmotionMin = 3,
                    EmotionMax = 3,
                    DamageReductionMin = 5,
                    DamageReductionMax = 5,
                    IsUndead = false,
                    Difficulty = Difficulty.Skilled
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 3,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 13,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 7,
                    SkillLevelMin = 5, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 6,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 14,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 5
                }, 
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 18,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },                
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 8,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 70,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 16,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 30,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 56,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 10,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 9,
                    SkillLevelMin = 5, 
                    SkillLevelMax = 5
                },   
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 23,
                    SkillLevelMin = 1, 
                    SkillLevelMax = 3
                }, 
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 20,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                }, 
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 21,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                }, 
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 22,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                } 
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 24
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 3
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 8
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 48
                }
            });
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureMerit
                {
                    CreatureId = identity,
                    MeritId = 84
                }
            });
         
        }   
        public static async Task AddNobleKnightOfTheEmpire(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Birodalom nemes lovagja",
                    Name = "Noble Knight of the Empire",
                    Karma = 0,
                    StrengthMin = 6,
                    StrengthMax = 8,
                    VitalityMin = 2,
                    VitalityMax = 3,
                    BodyMin = 4,
                    BodyMax = 5,
                    AgilityMin = 3,
                    AgilityMax = 4,
                    DexterityMin = 4,
                    DexterityMax = 6,
                    IntelligenceMin = 4,
                    IntelligenceMax = 6,
                    WillpowerMin = 4,
                    WillpowerMax = 6,
                    EmotionMin = 4,
                    EmotionMax = 6,
                    DamageReductionMin = 6,
                    DamageReductionMax = 6,
                    IsUndead = false,
                    Difficulty = Difficulty.Skilled
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 3,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 13,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 7,
                    SkillLevelMin = 5, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 6,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 4,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 6
                }, 
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 18,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 30,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 8,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 70,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 24,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 33,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 56,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 10,
                    SkillLevelMin = 1, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 9,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 3
                },   
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 23,
                    SkillLevelMin = 1, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 20,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 21,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                }, 
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 22,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 53,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 3
                }, 
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 34,
                    SkillLevelMin = 1, 
                    SkillLevelMax = 4
                } 
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 26
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 24
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 3
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 8
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 47
                }
            });
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureMerit
                {
                    CreatureId = identity,
                    MeritId = 84
                },
                new CreatureMerit
                {
                    CreatureId = identity,
                    MeritId = 36
                },
                new CreatureMerit
                {
                    CreatureId = identity,
                    MeritId = 54
                }
            });
         
        } 
        public static async Task AddNoviceAssassin(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Kezdő bérgyilkos",
                    Name = "Novice Assassin",
                    Karma = 0,
                    StrengthMin = 2,
                    StrengthMax = 4,
                    VitalityMin = 2,
                    VitalityMax = 4,
                    BodyMin = 2,
                    BodyMax = 4,
                    AgilityMin = 3,
                    AgilityMax = 5,
                    DexterityMin = 4,
                    DexterityMax = 5,
                    IntelligenceMin = 3,
                    IntelligenceMax = 4,
                    WillpowerMin = 3,
                    WillpowerMax = 4,
                    EmotionMin = 2,
                    EmotionMax = 3,
                    DamageReductionMin = 0,
                    DamageReductionMax = 0,
                    IsUndead = false,
                    Difficulty = Difficulty.Newbie
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 1,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 2,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 6,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 12,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 35,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                }, 
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 41,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 40,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 36,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 39,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 37,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 8,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 9,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 32,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                }
            });                              
        } 
        public static async Task AddAssassin(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Bérgyilkos",
                    Name = "Assassin",
                    Karma = 0,
                    StrengthMin = 3,
                    StrengthMax = 5,
                    VitalityMin = 2,
                    VitalityMax = 4,
                    BodyMin = 3,
                    BodyMax = 4,
                    AgilityMin = 4,
                    AgilityMax = 6,
                    DexterityMin = 5,
                    DexterityMax = 6,
                    IntelligenceMin = 4,
                    IntelligenceMax = 5,
                    WillpowerMin = 3,
                    WillpowerMax = 4,
                    EmotionMin = 2,
                    EmotionMax = 3,
                    DamageReductionMin = 0,
                    DamageReductionMax = 0,
                    IsUndead = false,
                    Difficulty = Difficulty.Skilled
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 1,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 2,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 6,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 12,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 35,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 3
                }, 
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 41,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 40,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 36,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 39,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 37,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 8,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 9,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 32,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 17,
                    SkillLevelMin = 2, 
                    SkillLevelMax = 2
                }
            });                              
        } 
        public static async Task AddAdvancedAssassin(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Profi bérgyilkos",
                    Name = "Advanced Assassin",
                    Karma = 0,
                    StrengthMin = 4,
                    StrengthMax = 5,
                    VitalityMin = 2,
                    VitalityMax = 4,
                    BodyMin = 4,
                    BodyMax = 5,
                    AgilityMin = 5,
                    AgilityMax = 7,
                    DexterityMin = 6,
                    DexterityMax = 7,
                    IntelligenceMin = 5,
                    IntelligenceMax = 6,
                    WillpowerMin = 4,
                    WillpowerMax = 5,
                    EmotionMin = 3,
                    EmotionMax = 4,
                    DamageReductionMin = 0,
                    DamageReductionMax = 0,
                    IsUndead = false,
                    Difficulty = Difficulty.Expert
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 1,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 2,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 6,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 12,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 35,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                }, 
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 41,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 40,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 36,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 39,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 37,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 8,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 9,
                    SkillLevelMin = 4, 
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 32,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 17,
                    SkillLevelMin = 3, 
                    SkillLevelMax = 3
                }
            });                              
        } 
    }
}