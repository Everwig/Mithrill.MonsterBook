    using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds
{
    internal class SimpleEnemiesAndHirelings
    {
        private static int _identity;

        public SimpleEnemiesAndHirelings(int identitySeed)
        {
            _identity = identitySeed - 1;
        }

        public async Task<int> AddOrUpdateCharacters(DbContext dbContext)
        {
            await AddImperialRegularSoldier(dbContext, GetIdentity());
            await AddImperialVeteranSoldier(dbContext, GetIdentity());
            await AddImperialBodyguard(dbContext, GetIdentity());
            await AddNobleKnightOfTheEmpire(dbContext, GetIdentity());
            
            await AddNoviceAssassin(dbContext, GetIdentity());
            await AddAssassin(dbContext, GetIdentity());
            await AddProfessionalAssassin(dbContext, GetIdentity());
            
            await AddElvenWarrior(dbContext, GetIdentity());
            await AddElvenBorderHunter(dbContext, GetIdentity());
            await AddElvenMasterArcher(dbContext, GetIdentity());
            await AddElvenPriest(dbContext, GetIdentity());
            
            await AddGoblinWarrior(dbContext, GetIdentity());
            await AddGoblinArcher(dbContext, GetIdentity());
            await AddGoblinShaman(dbContext, GetIdentity());

            await AddGladiator(dbContext, GetIdentity());

            await AddNoviceArcher(dbContext, GetIdentity());
            await AddArcher(dbContext, GetIdentity());
            await AddProfessionalArcher(dbContext, GetIdentity());

            await AddPaladin(dbContext, GetIdentity());
            /*await AddDarkPaladin(context, GetIdentity());

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

            await AddNoviceThief(context, GetIdentity());
            await AddThief(context, GetIdentity());
            await AddProfessionalThief(context, GetIdentity());

            await AddDwarvenWarrior(context, GetIdentity());

            await AddWildMan(context, GetIdentity());

            await AddBouncer(context, GetIdentity());

            await AddNoviceMercenary(context, GetIdentity());
            await AddMercenary(context, GetIdentity());
            await AddProfessionalMercenary(context, GetIdentity());*/

            return _identity;
        }

        private static int GetIdentity()
        {
            return _identity++;
        }
        
        public static async Task AddImperialRegularSoldier(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
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
                    Difficulty = Difficulty.Newbie,
                    Race = Race.CivilizedHuman
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 3,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 13,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 5,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 18,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 73,
                    SkillLevelMin = 1,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 7,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 14,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 16,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 9,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 74,
                    SkillLevelMin = 1,
                    SkillLevelMax = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 24
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 2
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 58
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 3,
                    Material = Material.Iron
                }
            });
        }

        public static async Task AddImperialVeteranSoldier(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
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
                    Difficulty = Difficulty.Expert,
                    Race = Race.CivilizedHuman
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 3,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 13,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 5,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 18,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 73,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 30,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 56,
                    SkillLevelMin = 1,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 74,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 10,
                    SkillLevelMin = 0,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 7,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 14,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 16,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 9,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 24
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 3
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 8
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 58
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 6,
                    Material = Material.Iron
                }
            });
        }

        public static async Task AddImperialBodyguard(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
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
                    Difficulty = Difficulty.Expert,
                    Race = Race.CivilizedHuman
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 3,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 13,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 7,
                    SkillLevelMin = 5,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 14,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 18,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 70,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 16,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 30,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 56,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 10,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 9,
                    SkillLevelMin = 5,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 23,
                    SkillLevelMin = 1,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 20,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 21,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 22,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 24
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 3
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 8
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 59
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 7,
                    Material = Material.Iron
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterMerit
                {
                    NpcTemplateId = identity,
                    MeritId = 84
                }
            });
        }
        
        public static async Task AddNobleKnightOfTheEmpire(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
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
                    Difficulty = Difficulty.Expert,
                    Race = Race.CivilizedHuman
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 3,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 13,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 7,
                    SkillLevelMin = 5,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 4,
                    SkillLevelMin = 4,
                    SkillLevelMax = 6
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 18,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 30,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 70,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 24,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 33,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 56,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 10,
                    SkillLevelMin = 1,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 9,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 23,
                    SkillLevelMin = 1,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 20,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 21,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 22,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 53,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 34,
                    SkillLevelMin = 1,
                    SkillLevelMax = 4
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 26
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 24
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 38
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 3
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 5
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 8
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 58
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 8,
                    Material = Material.Iron
                },
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 13,
                    Material = Material.Iron
                }
            });
            
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterMerit
                {
                    NpcTemplateId = identity,
                    MeritId = 84
                },
                new CharacterMerit
                {
                    NpcTemplateId = identity,
                    MeritId = 36
                },
                new CharacterMerit
                {
                    NpcTemplateId = identity,
                    MeritId = 54
                }
            });
        }
        
        public static async Task AddNoviceAssassin(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
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
                    Difficulty = Difficulty.Newbie,
                    Race = Race.CivilizedHuman
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 2,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 12,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 35,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 41,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 40,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 36,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 39,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 37,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 9,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
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
                new NpcTemplate
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
                    Difficulty = Difficulty.Expert,
                    Race = Race.CivilizedHuman
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 2,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 12,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 35,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 41,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 40,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 36,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 39,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 37,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 9,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 32,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
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
                new NpcTemplate
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
                    Difficulty = Difficulty.Expert,
                    Race = Race.CivilizedHuman
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 2,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 12,
                    SkillLevelMin = 4,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 35,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 41,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 40,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 36,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 39,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 37,
                    SkillLevelMin = 4,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 4,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 9,
                    SkillLevelMin = 4,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 32,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
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
                new NpcTemplate
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
                    DamageReductionMin = 3,
                    DamageReductionMax = 5,
                    Difficulty = Difficulty.Expert,
                    Race = Race.Elf
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 2,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 4,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 15,
                    SkillLevelMin = 2,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 18,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 13,
                    SkillLevelMin = 1,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 73,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 34,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 40,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 7,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 31,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 25
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 20
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 29
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 4,
                    Material = Material.Steel
                },
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 14,
                    Material = Material.Steel
                },
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 15,
                    Material = Material.Steel
                },
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 16,
                    Material = Material.Steel
                },
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 17,
                    Material = Material.Steel
                }
            });
        }

        public static async Task AddElvenBorderHunter(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Id = identity,
                    NameHu = "Elda határvadász",
                    Name = "Elven border hunter",
                    KarmaMin = 0,
                    KarmaMax = 0,
                    StrengthMin = 2,
                    StrengthMax = 3,
                    VitalityMin = 3,
                    VitalityMax = 3,
                    BodyMin = 2,
                    BodyMax = 3,
                    AgilityMin = 3,
                    AgilityMax = 4,
                    DexterityMin = 4,
                    DexterityMax = 6,
                    IntelligenceMin = 4,
                    IntelligenceMax = 6,
                    WillpowerMin = 3,
                    WillpowerMax = 6,
                    EmotionMin = 4,
                    EmotionMax = 4,
                    DamageReductionMin = 0,
                    DamageReductionMax = 0,
                    Difficulty = Difficulty.Newbie,
                    Race = Race.Elf
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 34,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 40,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5,
                    GuaranteedSuccesses = 1
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 16,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 32,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 27,
                    SkillLevelMin = 1,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 7,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 37,
                    SkillLevelMin = 1,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 31,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 23
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 20
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 29
                }
            });
        }
        
        public static async Task AddElvenMasterArcher(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Id = identity,
                    NameHu = "Elda mesteríjász",
                    Name = "Elven master archer",
                    KarmaMin = 0,
                    KarmaMax = 0,
                    StrengthMin = 4,
                    StrengthMax = 5,
                    VitalityMin = 3,
                    VitalityMax = 3,
                    BodyMin = 3,
                    BodyMax = 4,
                    AgilityMin = 3,
                    AgilityMax = 4,
                    DexterityMin = 6,
                    DexterityMax = 8,
                    IntelligenceMin = 4,
                    IntelligenceMax = 6,
                    WillpowerMin = 4,
                    WillpowerMax = 8,
                    EmotionMin = 4,
                    EmotionMax = 4,
                    DamageReductionMin = 7,
                    DamageReductionMax = 7,
                    Difficulty = Difficulty.Expert,
                    Race = Race.Elf
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 6,
                    SkillLevelMax = 9
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 34,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 40,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 16,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 32,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 7,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 31,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 23,
                    SkillLevelMin = 4,
                    SkillLevelMax = 7
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 30,
                    SkillLevelMin = 1,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 24,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 33,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 73,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 23
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 20
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 7,
                    Material = Material.Steel
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterMerit
                {
                    NpcTemplateId = identity,
                    MeritId = 54
                },
                new CharacterMerit
                {
                    NpcTemplateId = identity,
                    MeritId = 66
                }
            });
        }

        public static async Task AddElvenPriest(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Id = identity,
                    NameHu = "Elda pap",
                    Name = "Elven priest",
                    KarmaMin = 3,
                    KarmaMax = 8,
                    StrengthMin = 2,
                    StrengthMax = 3,
                    VitalityMin = 3,
                    VitalityMax = 3,
                    BodyMin = 2,
                    BodyMax = 4,
                    AgilityMin = 3,
                    AgilityMax = 4,
                    DexterityMin = 3,
                    DexterityMax = 4,
                    IntelligenceMin = 4,
                    IntelligenceMax = 6,
                    WillpowerMin = 3,
                    WillpowerMax = 6,
                    EmotionMin = 4,
                    EmotionMax = 6,
                    DamageReductionMin = 0,
                    DamageReductionMax = 0,
                    Difficulty = Difficulty.Expert,
                    Race = Race.Elf
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMin = 4,
                    SkillLevelMax = 7
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 67,
                    SkillLevelMin = 2,
                    SkillLevelMax = 9
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 65,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 58,
                    SkillLevelMin = 1,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 50,
                    SkillLevelMin = 1,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 51,
                    SkillLevelMin = 1,
                    SkillLevelMax = 9
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 49,
                    SkillLevelMin = 1,
                    SkillLevelMax = 7
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 52,
                    SkillLevelMin = 3,
                    SkillLevelMax = 7
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 53,
                    SkillLevelMin = 3,
                    SkillLevelMax = 7
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 48,
                    SkillLevelMin = 3,
                    SkillLevelMax = 7
                }
            });
        }

        public static async Task AddGoblinWarrior(DbContext dbContext, int identity)
        {

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Id = identity,
                    NameHu = "Goblin harcos",
                    Name = "Goblin warrior",
                    KarmaMin = 0,
                    KarmaMax = 0,
                    StrengthMin = 2,
                    StrengthMax = 3,
                    VitalityMin = 6,
                    VitalityMax = 6,
                    BodyMin = 4,
                    BodyMax = 4,
                    AgilityMin = 4,
                    AgilityMax = 4,
                    DexterityMin = 4,
                    DexterityMax = 5,
                    IntelligenceMin = 2,
                    IntelligenceMax = 2,
                    WillpowerMin = 2,
                    WillpowerMax = 2,
                    EmotionMin = 2,
                    EmotionMax = 2,
                    DamageReductionMin = 0,
                    DamageReductionMax = 0,
                    Difficulty = Difficulty.Newbie,
                    Race = Race.Goblin
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 15,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 1,
                    SkillLevelMax = 1
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 19,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 20,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 21,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 22,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 32,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 34,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 26,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 30,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                }
            });
        }

        public static async Task AddGoblinArcher(DbContext dbContext, int identity)
        {

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Id = identity,
                    NameHu = "Goblin íjász",
                    Name = "Goblin archer",
                    KarmaMin = 0,
                    KarmaMax = 0,
                    StrengthMin = 2,
                    StrengthMax = 3,
                    VitalityMin = 6,
                    VitalityMax = 6,
                    BodyMin = 3,
                    BodyMax = 3,
                    AgilityMin = 4,
                    AgilityMax = 4,
                    DexterityMin = 5,
                    DexterityMax = 6,
                    IntelligenceMin = 2,
                    IntelligenceMax = 2,
                    WillpowerMin = 3,
                    WillpowerMax = 4,
                    EmotionMin = 2,
                    EmotionMax = 2,
                    DamageReductionMin = 0,
                    DamageReductionMax = 0,
                    Difficulty = Difficulty.Newbie,
                    Race = Race.Goblin
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMin = 1,
                    SkillLevelMax = 1
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 15,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 19,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 20,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 21,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 22,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 32,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 34,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 26,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 30,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                }
            });
        }

        public static async Task AddGoblinShaman(DbContext dbContext, int identity)
        {

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Id = identity,
                    NameHu = "Goblin shámán",
                    Name = "Goblin shaman",
                    KarmaMin = 0,
                    KarmaMax = 4,
                    StrengthMin = 2,
                    StrengthMax = 2,
                    VitalityMin = 6,
                    VitalityMax = 6,
                    BodyMin = 2,
                    BodyMax = 2,
                    AgilityMin = 4,
                    AgilityMax = 4,
                    DexterityMin = 4,
                    DexterityMax = 4,
                    IntelligenceMin = 5,
                    IntelligenceMax = 5,
                    WillpowerMin = 5,
                    WillpowerMax = 5,
                    EmotionMin = 5,
                    EmotionMax = 5,
                    DamageReductionMin = 0,
                    DamageReductionMax = 0,
                    Difficulty = Difficulty.Expert,
                    Race = Race.Goblin
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMin = 1,
                    SkillLevelMax = 1
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 64,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 65,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 60,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 61,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 68,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 46,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 19,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 20,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 21,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 22,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 26,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 30,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                }
            });
        }
        
        public static async Task AddGladiator(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Id = identity,
                    NameHu = "Gladiátor",
                    Name = "Gladiator",
                    KarmaMin = 0,
                    KarmaMax = 0,
                    StrengthMin = 5,
                    StrengthMax = 8,
                    VitalityMin = 4,
                    VitalityMax = 4,
                    BodyMin = 5,
                    BodyMax = 8,
                    AgilityMin = 3,
                    AgilityMax = 6,
                    DexterityMin = 4,
                    DexterityMax = 6,
                    IntelligenceMin = 2,
                    IntelligenceMax = 3,
                    WillpowerMin = 3,
                    WillpowerMax = 3,
                    EmotionMin = 1,
                    EmotionMax = 2,
                    DamageReductionMin = 3,
                    DamageReductionMax = 7,
                    Difficulty = Difficulty.Expert,
                    Race = Race.CivilizedHuman
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 3,
                    SkillLevelMin = 4,
                    SkillLevelMax = 6
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 13,
                    SkillLevelMin = 3,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 5,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 18,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 73,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterMerit
                {
                    NpcTemplateId = identity,
                    MeritId = 58
                },
                new CharacterMerit
                {
                    NpcTemplateId = identity,
                    MeritId = 70
                },
                new CharacterMerit
                {
                    NpcTemplateId = identity,
                    MeritId = 55
                },
                new CharacterMerit
                {
                    NpcTemplateId = identity,
                    MeritId = 26
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterFlaw
                {
                    NpcTemplateId = identity,
                    FlawId = 29
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 25,
                    Material = Material.Iron
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 6,
                    Material = Material.Iron
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 60,
                    Material = Material.Iron
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 7,
                    Material = Material.Steel
                },
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 18,
                    Material = Material.Leather
                },
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 17,
                    Material = Material.Iron
                },
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 14,
                    Material = Material.Iron
                },
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 15,
                    Material = Material.Iron
                }
            });
        }

        public static async Task AddNoviceArcher(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Id = identity,
                    NameHu = "Kezdő íjász",
                    Name = "Novice archer",
                    KarmaMin = 0,
                    KarmaMax = 0,
                    StrengthMin = 3,
                    StrengthMax = 5,
                    VitalityMin = 2,
                    VitalityMax = 4,
                    BodyMin = 3,
                    BodyMax = 4,
                    AgilityMin = 3,
                    AgilityMax = 5,
                    DexterityMin = 5,
                    DexterityMax = 5,
                    IntelligenceMin = 4,
                    IntelligenceMax = 4,
                    WillpowerMin = 4,
                    WillpowerMax = 4,
                    EmotionMin = 2,
                    EmotionMax = 3,
                    DamageReductionMin = 0,
                    DamageReductionMax = 0,
                    Difficulty = Difficulty.Newbie,
                    Race = Race.CivilizedHuman
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMin = 1,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 15,
                    SkillLevelMin = 1,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 12,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 18,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 73,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 30,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 16,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                }
            });
        }

        public static async Task AddArcher(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Id = identity,
                    NameHu = "Veteran íjász",
                    Name = "Archer",
                    KarmaMin = 0,
                    KarmaMax = 0,
                    StrengthMin = 3,
                    StrengthMax = 5,
                    VitalityMin = 2,
                    VitalityMax = 4,
                    BodyMin = 4,
                    BodyMax = 5,
                    AgilityMin = 4,
                    AgilityMax = 6,
                    DexterityMin = 5,
                    DexterityMax = 6,
                    IntelligenceMin = 5,
                    IntelligenceMax = 6,
                    WillpowerMin = 5,
                    WillpowerMax = 6,
                    EmotionMin = 2,
                    EmotionMax = 3,
                    DamageReductionMin = 0,
                    DamageReductionMax = 0,
                    Difficulty = Difficulty.Expert,
                    Race = Race.CivilizedHuman
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 15,
                    SkillLevelMin = 1,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 12,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 18,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 73,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 30,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 16,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 19,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 20,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 21,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 22,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                }
            });
        }

        public static async Task AddProfessionalArcher(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Id = identity,
                    NameHu = "Elit íjász",
                    Name = "Professional archer",
                    KarmaMin = 0,
                    KarmaMax = 0,
                    StrengthMin = 3,
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
                    IntelligenceMax = 7,
                    WillpowerMin = 5,
                    WillpowerMax = 7,
                    EmotionMin = 2,
                    EmotionMax = 3,
                    DamageReductionMin = 0,
                    DamageReductionMax = 0,
                    Difficulty = Difficulty.Expert,
                    Race = Race.CivilizedHuman
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 1,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 15,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 4,
                    SkillLevelMax = 5
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 12,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 18,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 73,
                    SkillLevelMin = 4,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 4,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 30,
                    SkillLevelMin = 4,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 16,
                    SkillLevelMin = 4,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 19,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 20,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 21,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 22,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 10,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 74,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                }
            });
        }
        
        public static async Task AddPaladin(DbContext dbContext, int identity)
        {
            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new NpcTemplate
                {
                    Id = identity,
                    NameHu = "Jóság lovagja",
                    Name = "Paladin of Light",
                    KarmaMin = 0,
                    KarmaMax = 0,
                    StrengthMin = 5,
                    StrengthMax = 8,
                    VitalityMin = 3,
                    VitalityMax = 3,
                    BodyMin = 4,
                    BodyMax = 6,
                    AgilityMin = 3,
                    AgilityMax = 4,
                    DexterityMin = 4,
                    DexterityMax = 6,
                    IntelligenceMin = 4,
                    IntelligenceMax = 6,
                    WillpowerMin = 3,
                    WillpowerMax = 3,
                    EmotionMin = 4,
                    EmotionMax = 6,
                    DamageReductionMin = 4,
                    DamageReductionMax = 4,
                    Difficulty = Difficulty.Newbie,
                    Race = Race.CivilizedHuman
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 3,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 13,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 5,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 18,
                    SkillLevelMin = 3,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 73,
                    SkillLevelMin = 1,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 8,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 7,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 14,
                    SkillLevelMin = 3,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 6,
                    SkillLevelMin = 2,
                    SkillLevelMax = 4
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 16,
                    SkillLevelMin = 2,
                    SkillLevelMax = 3
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 9,
                    SkillLevelMin = 2,
                    SkillLevelMax = 2
                },
                new CharacterSkill
                {
                    NpcTemplateId = identity,
                    SkillId = 74,
                    SkillLevelMin = 1,
                    SkillLevelMax = 3
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 24
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 2
                },
                new CharacterWeapon
                {
                    NpcTemplateId = identity,
                    WeaponId = 58
                }
            });

            await dbContext.BulkInsertOrUpdateAsync(new[]
            {
                new CharacterArmor
                {
                    NpcTemplateId = identity,
                    ArmorId = 3,
                    Material = Material.Iron
                }
            });
        }
    }
}