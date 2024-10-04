using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds
{
    public class MythicCreatures
    {
        private int _identity;

        public MythicCreatures(int identitySeed)
        {
            _identity = identitySeed - 1;
        }

        public async Task AddOrUpdateCreatures(DbContext context)
        {
            await AddChimeraAsync(context, GetIdentity());
            await AddDiagonaAsync(context, GetIdentity());
            await AddUnicornAsync(context, GetIdentity());
            await AddGiganticSnailAsync(context, GetIdentity());
            await AddGnollAsync(context, GetIdentity());
            await AddGriffAsync(context, GetIdentity());
            await AddHydraAsync(context, GetIdentity());
            await AddLamassuAsync(context, GetIdentity());
            await AddSirenAsync(context, GetIdentity());
        }

        private async Task AddChimeraAsync(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Mythical,
                    Name = "Chimera",
                    NameHu = "Chiméra",
                    Id = identity,
                    StrengthMax = 8,
                    StrengthMin = 6,
                    VitalityMax = 6,
                    VitalityMin = 4,
                    BodyMax = 14,
                    BodyMin = 8,
                    AgilityMax = 6,
                    AgilityMin = 6,
                    DexterityMax = 10,
                    DexterityMin = 6,
                    IntelligenceMax = 4,
                    IntelligenceMin = 3,
                    WillpowerMax = 9,
                    WillpowerMin = 3,
                    EmotionMax = 5,
                    EmotionMin = 3,
                    Difficulty = Difficulty.Proficient,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 15,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 6,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 70,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 8,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 34,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
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
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 51
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 54
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 55
                        }
                    },
                    CreatureFlaws = new List<CreatureFlaw>
                    {
                        new CreatureFlaw
                        {
                            CreatureId = identity,
                            FlawId = 69
                        }
                    }
                }
            });
        }

        private async Task AddDiagonaAsync(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Mythical,
                    Name = "Diagona",
                    NameHu = "Diagona",
                    Id = identity,
                    StrengthMax = 5,
                    StrengthMin = 3,
                    VitalityMax = 8,
                    VitalityMin = 4,
                    BodyMax = 6,
                    BodyMin = 2,
                    AgilityMax = 6,
                    AgilityMin = 3,
                    DexterityMax = 5,
                    DexterityMin = 3,
                    IntelligenceMax = 1,
                    IntelligenceMin = 1,
                    WillpowerMax = 2,
                    WillpowerMin = 1,
                    EmotionMax = 1,
                    EmotionMin = 1,
                    Difficulty = Difficulty.Beginner,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 14,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 34,
                            SkillLevelMax = 3,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 5,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 8,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 36,
                            SkillLevelMax = 3,
                            SkillLevelMin = 1,
                            GuaranteedSuccesses = 1
                        }
                    }
                }
            });
        }

        private async Task AddUnicornAsync(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Mythical,
                    Name = "Unicorn",
                    NameHu = "Egyszarvú",
                    Id = identity,
                    StrengthMax = 8,
                    StrengthMin = 6,
                    VitalityMax = 6,
                    VitalityMin = 4,
                    BodyMax = 8,
                    BodyMin = 6,
                    AgilityMax = 6,
                    AgilityMin = 6,
                    DexterityMax = 10,
                    DexterityMin = 6,
                    IntelligenceMax = 4,
                    IntelligenceMin = 3,
                    WillpowerMax = 9,
                    WillpowerMin = 6,
                    EmotionMax = 5,
                    EmotionMin = 3,
                    Difficulty = Difficulty.Seasoned,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 21,
                            SkillLevelMax = 6,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 8,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 49,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 3,
                            SkillLevelMax = 6,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 4,
                            SkillLevelMax = 6,
                            SkillLevelMin = 3
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 75
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 24
                        }
                    },
                    CreatureFlaws = new List<CreatureFlaw>
                    {
                        new CreatureFlaw
                        {
                            CreatureId = identity,
                            FlawId = 31
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 44,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 56
                        }
                    }
                }
            });
        }

        private async Task AddGiganticSnailAsync(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Mythical,
                    Name = "Gigantic snail",
                    NameHu = "Gigantikus éticsiga",
                    Id = identity,
                    StrengthMax = 20,
                    StrengthMin = 20,
                    VitalityMax = 10,
                    VitalityMin = 10,
                    BodyMax = 100,
                    BodyMin = 25,
                    AgilityMax = 1,
                    AgilityMin = 1,
                    DexterityMax = 1,
                    DexterityMin = 1,
                    IntelligenceMax = 4,
                    IntelligenceMin = 3,
                    WillpowerMax = 1,
                    WillpowerMin = 1,
                    EmotionMax = 1,
                    EmotionMin = 1,
                    DamageReductionMin = 1,
                    DamageReductionMax = 6,
                    Difficulty = Difficulty.Seasoned,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 4,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 97
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 98
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 42,
                        }
                    }
                }
            });
        }

        private async Task AddGnollAsync(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Mythical,
                    Name = "Gnoll",
                    NameHu = "Gnoll",
                    Id = identity,
                    StrengthMax = 6,
                    StrengthMin = 4,
                    VitalityMax = 5,
                    VitalityMin = 5,
                    BodyMax = 5,
                    BodyMin = 5,
                    AgilityMax = 4,
                    AgilityMin = 4,
                    DexterityMax = 4,
                    DexterityMin = 3,
                    IntelligenceMax = 3,
                    IntelligenceMin = 1,
                    WillpowerMax = 3,
                    WillpowerMin = 2,
                    EmotionMax = 2,
                    EmotionMin = 1,
                    Difficulty = Difficulty.Beginner,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 1,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 3,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 14,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 13,
                            SkillLevelMax = 2,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 21,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 8,
                            SkillLevelMax = 6,
                            SkillLevelMin = 3,
                            GuaranteedSuccesses = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 40,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 32,
                            SkillLevelMax = 6,
                            SkillLevelMin = 3,
                            GuaranteedSuccesses = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 34,
                            SkillLevelMax = 3,
                            SkillLevelMin = 1
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 40
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 2,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 21,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 24
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 25,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 27,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 32
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 34,
                        }
                    }
                }
            });
        }

        private async Task AddGriffAsync(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Mythical,
                    Name = "Griff",
                    NameHu = "Griff",
                    Id = identity,
                    StrengthMax = 11,
                    StrengthMin = 6,
                    VitalityMax = 5,
                    VitalityMin = 3,
                    BodyMax = 11,
                    BodyMin = 6,
                    AgilityMax = 7,
                    AgilityMin = 5,
                    DexterityMax = 6,
                    DexterityMin = 3,
                    IntelligenceMax = 2,
                    IntelligenceMin = 1,
                    WillpowerMax = 2,
                    WillpowerMin = 1,
                    EmotionMax = 4,
                    EmotionMin = 2,
                    Difficulty = Difficulty.Skillful,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 3,
                            SkillLevelMax = 7,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 70,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 8,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 40,
                            SkillLevelMax = 4,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 34,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 5,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 26
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 44,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 41,
                        }
                    }
                }
            });
        }

        private async Task AddHydraAsync(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Mythical,
                    Name = "Hydra",
                    NameHu = "Hydra",
                    Id = identity,
                    StrengthMax = 8,
                    StrengthMin = 8,
                    VitalityMax = 10,
                    VitalityMin = 10,
                    BodyMax = 10,
                    BodyMin = 10,
                    AgilityMax = 5,
                    AgilityMin = 5,
                    DexterityMax = 8,
                    DexterityMin = 8,
                    IntelligenceMax = 6,
                    IntelligenceMin = 6,
                    WillpowerMax = 6,
                    WillpowerMin = 6,
                    EmotionMax = 6,
                    EmotionMin = 6,
                    Difficulty = Difficulty.Skillful,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 4,
                            SkillLevelMax = 5,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 6,
                            SkillLevelMax = 5,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 8,
                            SkillLevelMax = 5,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 49,
                            SkillLevelMax = 5,
                            SkillLevelMin = 5
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 50
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 21
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 41,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 49,
                        }
                    }
                }
            });
        }

        private async Task AddLamassuAsync(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Mythical,
                    Name = "Lamassu",
                    NameHu = "Lamassu",
                    Id = identity,
                    StrengthMax = 4,
                    StrengthMin = 4,
                    VitalityMax = 2,
                    VitalityMin = 2,
                    BodyMax = 6,
                    BodyMin = 6,
                    AgilityMax = 3,
                    AgilityMin = 3,
                    DexterityMax = 2,
                    DexterityMin = 2,
                    IntelligenceMax = 9,
                    IntelligenceMin = 9,
                    WillpowerMax = 9,
                    WillpowerMin = 9,
                    EmotionMax = 7,
                    EmotionMin = 7,
                    Difficulty = Difficulty.Skillful,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 70,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 3,
                            SkillLevelMax = 5,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 45,
                            SkillLevelMax = 9,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 48,
                            SkillLevelMax = 11,
                            SkillLevelMin = 9
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 49,
                            SkillLevelMax = 11,
                            SkillLevelMin = 9
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 50,
                            SkillLevelMax = 11,
                            SkillLevelMin = 7
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 52,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 53,
                            SkillLevelMax = 11,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 54,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 55,
                            SkillLevelMax = 11,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 57,
                            SkillLevelMax = 11,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 58,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 59,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 60,
                            SkillLevelMax = 13,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 61,
                            SkillLevelMax = 9,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 62,
                            SkillLevelMax = 13,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 63,
                            SkillLevelMax = 13,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 64,
                            SkillLevelMax = 13,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 65,
                            SkillLevelMax = 13,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 66,
                            SkillLevelMax = 13,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 56,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 50
                        }
                    },
                    CreatureFlaws = new List<CreatureFlaw>
                    {
                        new CreatureFlaw
                        {
                            CreatureId = identity,
                            FlawId = 31
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 43,
                        }
                    }
                }
            });
        }

        private async Task AddSirenAsync(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Race = Race.Mythical,
                    Name = "Siren",
                    NameHu = "Szirén",
                    Id = identity,
                    StrengthMax = 3,
                    StrengthMin = 3,
                    VitalityMax = 3,
                    VitalityMin = 3,
                    BodyMax = 3,
                    BodyMin = 3,
                    AgilityMax = 5,
                    AgilityMin = 4,
                    DexterityMax = 5,
                    DexterityMin = 4,
                    IntelligenceMax = 6,
                    IntelligenceMin = 4,
                    WillpowerMax = 4,
                    WillpowerMin = 3,
                    EmotionMax = 7,
                    EmotionMin = 6,
                    Difficulty = Difficulty.Beginner,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 1,
                            SkillLevelMax = 4,
                            SkillLevelMin = 4
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 24,
                            SkillLevelMax = 5,
                            SkillLevelMin = 5,
                            GuaranteedSuccesses = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 19,
                            SkillLevelMax = 5,
                            SkillLevelMin = 5,
                            GuaranteedSuccesses = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 61,
                            SkillLevelMax = 4,
                            SkillLevelMin = 4
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 49,
                            SkillLevelMax = 4,
                            SkillLevelMin = 3
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 16
                        }
                    },
                    CreatureFlaws = new List<CreatureFlaw>
                    {
                        new CreatureFlaw
                        {
                            CreatureId = identity,
                            FlawId = 31
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 40,
                        }
                    }
                }
            });
        }

        private int GetIdentity()
        {
            return _identity++;
        }
    }
}