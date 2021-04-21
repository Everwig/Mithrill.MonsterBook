using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds
{
    public class EvilAndGoodCreatures
    {
        private int _identity;

        public EvilAndGoodCreatures(int identitySeed)
        {
            _identity = identitySeed - 1;
        }

        public async Task<int> AddOrUpdateCreatures(DbContext context)
        {
            await AddShadow(context, GetIdentity());
            await AddBaloth(context, GetIdentity());
            await AddCerberus(context, GetIdentity());
            await AddSkeleton(context, GetIdentity());
            await AddDemon(context, GetIdentity());
            await AddDuahinMagicZombie(context, GetIdentity());
            await AddThousandFangs(context, GetIdentity());
            await AddGhoul(context, GetIdentity());
            await AddDeathKnight(context, GetIdentity());
            await AddLich(context, GetIdentity());
            await AddPoisonSpirit(context, GetIdentity());
            await AddMummy(context, GetIdentity());
            await AddHellhound(context, GetIdentity());
            await AddRimsai(context, GetIdentity());
            await AddSuccubus(context, GetIdentity());
            await AddIncubus(context, GetIdentity());
            await AddHoppingChewer(context, GetIdentity());
            await AddVampire(context, GetIdentity());
            await AddZombie(context, GetIdentity());
            await AddGhost(context, GetIdentity());
            await AddAngel(context, GetIdentity());
            await AddSeraph(context, GetIdentity());

            return _identity;
        }

        private async Task AddDuahinMagicZombie(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    IsUndead = true,
                    Difficulty = Difficulty.Novice,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 14,
                            SkillLevelMax = 3,
                            SkillLevelMin = 3
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 87
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 88
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 89
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 90
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 91
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 92
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            WeaponId = 23,
                            CreatureId = identity
                        }
                    }
                }
            });
        }

        private async Task AddGhost(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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

        private async Task AddSeraph(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    IsUndead = false,
                    Difficulty = Difficulty.Skilled,
                    DamageReductionMax = 2,
                    DamageReductionMin = 0,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 6,
                            GuaranteedSuccesses = 1,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 12,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 1,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 2,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 70,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 18,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 29,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 24
                        }
                    }
                }
            });
        }

        private async Task AddAngel(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
                    Name = "Angel",
                    NameHu = "Angyal",
                    Id = identity,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 4
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 13
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 18
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 67
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 16
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 51
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 49
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 86
                        }
                    }
                }
            });
        }

        private async Task AddZombie(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    IsUndead = true,
                    Difficulty = Difficulty.Novice,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 1,
                            SkillLevelMax = 2,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 2,
                            SkillLevelMax = 2,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 14,
                            SkillLevelMax = 2,
                            SkillLevelMin = 2
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 87
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 88
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 89
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 90
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 91
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            WeaponId = 23,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 32,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 24,
                            CreatureId = identity
                        }
                    }
                }
            });
        }

        private async Task AddVampire(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    IsUndead = true,
                    KarmaMax = 5,
                    KarmaMin = 0,
                    Difficulty = Difficulty.Skillful,
                    CreatureSkills = new List<CreatureSkill>
                    {
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
                            SkillId = 14,
                            SkillLevelMax = 5,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 68,
                            SkillLevelMax = 3,
                            SkillLevelMin = 0
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 60,
                            SkillLevelMax = 2,
                            SkillLevelMin = 0
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 62,
                            SkillLevelMax = 2,
                            SkillLevelMin = 0
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 63,
                            SkillLevelMax = 2,
                            SkillLevelMin = 0
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 64,
                            SkillLevelMax = 2,
                            SkillLevelMin = 0
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 87
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 88
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 89
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 90
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 91
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            WeaponId = 32,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 24,
                            CreatureId = identity
                        }
                    }
                }
            });
        }

        private async Task AddHoppingChewer(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    Difficulty = Difficulty.Novice,
                    DamageReductionMax = 1,
                    DamageReductionMin = 1,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 1,
                            SkillLevelMax = 4,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 15,
                            SkillLevelMax = 4,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 6,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 21,
                            SkillLevelMax = 4,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 22,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            WeaponId = 40,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 43,
                            CreatureId = identity
                        }
                    }
                }
            });
        }

        private async Task AddIncubus(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    Difficulty = Difficulty.Intermediate,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 1,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 12,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 70,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 69,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 71,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 24,
                            SkillLevelMax = 7,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 33,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 50,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 28,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 49,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            WeaponId = 29,
                            CreatureId = identity
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            MeritId = 50,
                            CreatureId = identity
                        },
                        new CreatureMerit
                        {
                            MeritId = 16,
                            CreatureId = identity
                        }
                    }
                }
            });
        }

        private async Task AddSuccubus(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
{
                new Creature
                {
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
                    Difficulty = Difficulty.Intermediate,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 1,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 12,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 70,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 69,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 71,
                            SkillLevelMax = 5,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 24,
                            SkillLevelMax = 7,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 33,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 50,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 28,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 49,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            WeaponId = 29,
                            CreatureId = identity
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            MeritId = 50,
                            CreatureId = identity
                        },
                        new CreatureMerit
                        {
                            MeritId = 16,
                            CreatureId = identity
                        }
                    }
                }
            });
        }

        private async Task AddRimsai(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    IsUndead = false,
                    Difficulty = Difficulty.Skilled,
                    DamageReductionMax = 2,
                    DamageReductionMin = 0,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 6,
                            GuaranteedSuccesses = 1,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 12,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 1,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 2,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 70,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 18,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 29,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 24
                        }
                    }
                }
            });
        }

        private async Task AddHellhound(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    Difficulty = Difficulty.Seasoned,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 15,
                            SkillLevelMax = 4,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 21,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 32,
                            SkillLevelMax = 4,
                            SkillLevelMin = 3
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
                            SkillId = 72,
                            SkillLevelMax = 4,
                            SkillLevelMin = 4
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 48,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 43
                        }
                    }
                }
            });
        }

        private async Task AddMummy(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    IsUndead = true,
                    KarmaMax = 6,
                    KarmaMin = 0,
                    Difficulty = Difficulty.Skillful,
                    CreatureSkills = new List<CreatureSkill>
                    {
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
                            SkillId = 14,
                            SkillLevelMax = 3,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 68,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 60,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 61,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 62,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 63,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 64,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 65,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 66,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 87
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 88
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 89
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 90
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 91
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            WeaponId = 32,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 24,
                            CreatureId = identity
                        }
                    }
                }
            });
        }

        private async Task AddPoisonSpirit(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
{
                new Creature
                {
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
                    IsUndead = true,
                    Difficulty = Difficulty.Novice,
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 46
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 86
                        }
                    }
                }
            });
        }

        private async Task AddLich(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    IsUndead = true,
                    KarmaMax = 9,
                    KarmaMin = 3,
                    Difficulty = Difficulty.Experienced,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 3,
                            SkillLevelMax = 4,
                            SkillLevelMin = 4
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 14,
                            SkillLevelMax = 4,
                            SkillLevelMin = 4
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 68,
                            SkillLevelMax = 7,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 60,
                            SkillLevelMax = 3,
                            SkillLevelMin = 0
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 61,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 62,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 63,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 64,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 65,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 66,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 87
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 88
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 89
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 90
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 91
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            WeaponId = 32,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 24,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 47,
                            CreatureId = identity
                        }
                    }
                }
            });
        }

        private async Task AddDeathKnight(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    IsUndead = true,
                    Difficulty = Difficulty.Experienced,
                    CreatureSkills = new List<CreatureSkill>
                    {
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
                            SkillId = 4,
                            SkillLevelMax = 5,
                            SkillLevelMin = 5
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 14,
                            SkillLevelMax = 5,
                            SkillLevelMin = 5
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 87
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 88
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 89
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 90
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 91
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            WeaponId = 32,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 33,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 24,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 25,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 26,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 21,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 22,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 47,
                            CreatureId = identity
                        }
                    }
                }
            });
        }

        private async Task AddGhoul(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    IsUndead = true,
                    Difficulty = Difficulty.Talented,
                    CreatureSkills = new List<CreatureSkill>
                    {
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
                            SkillId = 14,
                            SkillLevelMax = 3,
                            SkillLevelMin = 3
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 87
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 88
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 89
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 90
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 91
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            WeaponId = 32,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 24,
                            CreatureId = identity
                        }
                    }
                }
            });
        }

        private async Task AddThousandFangs(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    Difficulty = Difficulty.Senior,
                    DamageReductionMax = 6,
                    DamageReductionMin = 6,
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
                            SkillId = 72,
                            SkillLevelMax = 4,
                            SkillLevelMin = 4
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 8,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 40,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 43
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 26
                        }
                    }
                }
            });
        }

        private async Task AddDemon(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
{
                new Creature
                {
                    Name = "Demon",
                    NameHu = "Démon",
                    Id = identity,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 11
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 18
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 13
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 68
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 46
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 49
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 86
                        }
                    }
                }
            });
        }

        private async Task AddSkeleton(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
{
                new Creature
                {
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
                    IsUndead = true,
                    Difficulty = Difficulty.Newbie,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 1,
                            SkillLevelMax = 1,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 2,
                            SkillLevelMax = 1,
                            SkillLevelMin = 1
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 14,
                            SkillLevelMax = 1,
                            SkillLevelMin = 1
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 87
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 88
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 90
                        },
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 91
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            WeaponId = 23,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 32,
                            CreatureId = identity
                        },
                        new CreatureWeapon
                        {
                            WeaponId = 24,
                            CreatureId = identity
                        }
                    }
                }
            });
        }

        private async Task AddCerberus(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    EmotionMin = 6,
                    IsUndead = true,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 15,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 12,
                            SkillLevelMax = 5,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 8,
                            SkillLevelMax = 7,
                            SkillLevelMin = 5
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 43
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 41
                        }
                    }
                }
            });
        }

        private async Task AddBaloth(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    Difficulty = Difficulty.Advanced,
                    DamageReductionMax = 5,
                    DamageReductionMin = 5,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 15,
                            SkillLevelMax = 5,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 21,
                            SkillLevelMax = 6,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 8,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        }
                    },
                    CreatureWeapons = new List<CreatureWeapon>
                    {
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 40,
                        },
                        new CreatureWeapon
                        {
                            CreatureId = identity,
                            WeaponId = 43
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 26
                        }
                    }
                }
            });
        }

        private async Task AddShadow(DbContext context, int identity)
        {
            await context.BulkInsertOrUpdateAsync(new[]
            {
                new Creature
                {
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
                    KarmaMin = 3,
                    CreatureSkills = new List<CreatureSkill>
                    {
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 2,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 68,
                            SkillLevelMax = 4,
                            SkillLevelMin = 3
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 58,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 50,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 46,
                            SkillLevelMax = 4,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 49,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 60,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 61,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 62,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 63,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 64,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        },
                        new CreatureSkill
                        {
                            CreatureId = identity,
                            SkillId = 65,
                            SkillLevelMax = 3,
                            SkillLevelMin = 2
                        }
                    },
                    CreatureMerits = new List<CreatureMerit>
                    {
                        new CreatureMerit
                        {
                            CreatureId = identity,
                            MeritId = 86
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