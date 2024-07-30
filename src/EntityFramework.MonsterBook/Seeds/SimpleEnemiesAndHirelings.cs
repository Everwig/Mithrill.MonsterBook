﻿using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds
{
    internal class SimpleEnemiesAndHirelings
    {
        private int _identity;

        public SimpleEnemiesAndHirelings(int identitySeed)
        {
            _identity = identitySeed - 1;
        }

        public async Task<int> AddOrUpdateCharacters(DbContext context)
        {
            await AddImperialRegularSoldier(context, GetIdentity());
            await AddImperialVeteranSoldier(context, GetIdentity());
            await AddImperialBodyguard(context, GetIdentity());
            await AddNobleKnightOfTheEmpire(context, GetIdentity());
            
            await AddNoviceAssassin(context, GetIdentity());
            await AddAssassin(context, GetIdentity());
            await AddProfessionalAssassin(context, GetIdentity());
            
            await AddElvenWarrior(context, GetIdentity());
            await AddElvenBorderHunter(context, GetIdentity());
            await AddElvenArcher(context, GetIdentity());
            await AddElvenPriest(context, GetIdentity());
            
            await AddGoblinWarrior(context, GetIdentity());
            await AddGoblinArcher(context, GetIdentity());
            await AddGoblinShaman(context, GetIdentity());

            await AddGladiator(context, GetIdentity());

            await AddNoiviceArcher(context, GetIdentity());
            await AddArcher(context, GetIdentity());
            await AddProfessionalArcher(context, GetIdentity());

            await AddPaladin(context, GetIdentity());
            await AddDarkPaladin(context, GetIdentity());

            await AddBarbarianScout(context, GetIdentity());
            await AddBarbarianWarrior(context, GetIdentity());
            await AddBarbarianShaman(context, GetIdentity());
            await AddBarbarianChieftain(context, GetIdentity());

            await AddOrcScout(context, GetIdentity());
            await AddOrcWarrior(context, GetIdentity());
            await AddOrcShaman(context, GetIdentity());
            await AddOrcChieftain(context, GetIdentity());

            await AddPriestOfGood(context, GetIdentity());
            await AddPriestOfEvil(context, GetIdentity());

            await AddNoiviceThief(context, GetIdentity());
            await AddThief(context, GetIdentity());
            await AddProfessionalThief(context, GetIdentity());

            await AddDwarvenWarrior(context, GetIdentity());

            await AddWildMan(context, GetIdentity());

            await AddBouncer(context, GetIdentity());

            await AddNoiviceMercenary(context, GetIdentity());
            await AddMercenary(context, GetIdentity());
            await AddProfessionalMercenary(context, GetIdentity());

            return _identity;
        }
        private int GetIdentity()
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
                    NameHu = "Birodalmi reguláris",
                    Name = "Imperial soldier",
                    KarmaMin = 0,
                    KarmaMax = 0,
                    StrengthMin = 4,
                    StrengthMax = 6,
                    VitalityMin = 2,
                    VitalityMax = 2,
                    BodyMin = 3,
                    BodyMax = 4,
                    AgilityMin = 3,
                    AgilityMax = 4,
                    DexterityMin = 3,
                    DexterityMax = 4,
                    IntelligenceMin = 4,
                    IntelligenceMax = 4,
                    WillpowerMin = 3,
                    WillpowerMax = 3,
                    EmotionMin = 3,
                    EmotionMax = 3,
                    DamageReductionMin = 3,
                    DamageReductionMax = 3,
                    IsUndead = false,
                    Difficulty = Difficulty.Beginner
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
                    SkillId = 5,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
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
                    SkillId = 73,
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
                    SkillId = 7,
                    SkillLevelMin = 2,
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
                    SkillId = 6,
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
                    SkillId = 9,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 74,
                    SkillLevelMin = 1,
                    SkillLevelMax = 3
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
                    WeaponId = 2
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 58
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureArmor
                {
                    CreatureId = identity,
                    ArmorId = 3
                }
            });
        }

        public static async Task AddImperialVeteranSoldier(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Birodalmi veterán katona",
                    Name = "Imperial veteran soldier",
                    KarmaMin = 0,
                    KarmaMax = 0,
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
                    SkillId = 6,
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
                    SkillId = 18,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 73,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
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
                    SkillId = 74,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 10,
                    SkillLevelMin = 0,
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 7,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
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
                    SkillId = 16,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
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
                    WeaponId = 58
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureArmor
                {
                    CreatureId = identity,
                    ArmorId = 6
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
                    KarmaMin = 0,
                    KarmaMax = 0,
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
                    WeaponId = 59
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureArmor
                {
                    CreatureId = identity,
                    ArmorId = 7
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
                    KarmaMin = 0,
                    KarmaMax = 0,
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
                    WeaponId = 38
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 3
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 5
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 8
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 58
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureArmor
                {
                    CreatureId = identity,
                    ArmorId = 8
                },
                new CreatureArmor
                {
                    CreatureId = identity,
                    ArmorId = 13
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
                    KarmaMin = 0,
                    KarmaMax = 0,
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
                    KarmaMin = 0,
                    KarmaMax = 0,
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
        
        public static async Task AddProfessionalAssassin(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Profi bérgyilkos",
                    Name = "Professional Assassin",
                    KarmaMin = 0,
                    KarmaMax = 0,
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

        public static async Task AddElvenWarrior(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Id = identity,
                    NameHu = "Elda harcos",
                    Name = "Elven Warrior",
                    KarmaMin = 0,
                    KarmaMax = 0,
                    StrengthMin = 2,
                    StrengthMax = 6,
                    VitalityMin = 3,
                    VitalityMax = 3,
                    BodyMin = 2,
                    BodyMax = 4,
                    AgilityMin = 3,
                    AgilityMax = 3,
                    DexterityMin = 4,
                    DexterityMax = 6,
                    IntelligenceMin = 4,
                    IntelligenceMax = 4,
                    WillpowerMin = 2,
                    WillpowerMax = 4,
                    EmotionMin = 4,
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
                    SkillId = 2,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 4,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 15,
                    SkillLevelMin = 2,
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 6,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 18,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 13,
                    SkillLevelMin = 1,
                    SkillLevelMax = 2
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 73,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 34,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 40,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 8,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 7,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CreatureSkill
                {
                    CreatureId = identity,
                    SkillId = 31,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 25
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 20
                },
                new CreatureWeapon
                {
                    CreatureId = identity,
                    WeaponId = 29
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CreatureArmor
                {
                    CreatureId = identity,
                    ArmorId = 14
                },
                new CreatureArmor
                {
                    CreatureId = identity,
                    ArmorId = 15
                },
                new CreatureArmor
                {
                    CreatureId = identity,
                    ArmorId = 17
                },
                new CreatureArmor
                {
                    CreatureId = identity,
                    ArmorId = 18
                }
            });
        }
    }
}