using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain;

namespace EntityFramework.MonsterBook.Seeds;

public class Elementals
{
    private static int _identity;

    public Elementals(int identitySeed)
    {
        _identity = identitySeed - 1;
    }

    public async Task<int> AddOrUpdateCreatures(DbContext dbContext)
    {
        await AddFireElemental(dbContext, _identity);
        await AddWaterElemental(dbContext, _identity);
        await AddIceElemental(dbContext, _identity);
        await AddAirElemental(dbContext, _identity);
        await AddStormElemental(dbContext, _identity);
        await AddEarthElemental(dbContext, _identity);
        await AddRockElemental(dbContext, _identity);
        await AddSandElemental(dbContext, _identity);

        return _identity;
    }

    private static async Task AddFireElemental(DbContext dbContext, int identity)
    {
        await dbContext.BulkInsertOrUpdateAsync(new[]
        {
            new NpcTemplate
            {
                Race = Race.Elemental,
                IsUndead = false,
                Name = "Fire elemental",
                NameHu = "Tűz elementál",
                Id = identity,
                AgilityMax = 15,
                AgilityMin = 3,
                BodyMax = 13,
                BodyMin = 1,
                DexterityMax = 15,
                DexterityMin = 3,
                Difficulty = Difficulty.Variable,
                IntelligenceMax = 13,
                IntelligenceMin = 1,
                EmotionMax = 13,
                EmotionMin = 1,
                WillpowerMax = 13,
                WillpowerMin = 1,
                CharacterSkills = new List<CharacterSkill>
                {
                    new()
                    {
                        SkillLevelMin = 1,
                        SkillLevelMax = 13,
                        SkillId = 1
                    }
                },
                CharacterWeapons = new List<CharacterWeapon>
                {
                    new()
                    {
                        Material = Material.Bone,
                        WeaponId = 43
                    },
                    new()
                    {
                        Material = Material.None,
                        WeaponId = 61
                    }
                }
            }
        });
    }

    private static async Task AddWaterElemental(DbContext dbContext, int identity)
    {
        await dbContext.BulkInsertOrUpdateAsync(new[]
        {
            new NpcTemplate
            {
                Race = Race.Elemental,
                IsUndead = false,
                Name = "Water elemental",
                NameHu = "Víz elementál",
                Id = identity,
                AgilityMax = 14,
                AgilityMin = 2,
                BodyMax = 15,
                BodyMin = 3,
                DexterityMax = 14,
                DexterityMin = 2,
                Difficulty = Difficulty.Variable,
                IntelligenceMax = 13,
                IntelligenceMin = 1,
                EmotionMax = 13,
                EmotionMin = 1,
                WillpowerMax = 13,
                WillpowerMin = 1,
                CharacterSkills = new List<CharacterSkill>
                {
                    new()
                    {
                        SkillLevelMin = 1,
                        SkillLevelMax = 13,
                        SkillId = 2
                    }
                },
                CharacterWeapons = new List<CharacterWeapon>
                {
                    new()
                    {
                        Material = Material.Bone,
                        WeaponId = 43
                    },
                    new()
                    {
                        Material = Material.None,
                        WeaponId = 61,
                        IsOptional = true
                    }
                }
            }
        });
    }

    private static async Task AddIceElemental(DbContext dbContext, int identity)
    {
        await dbContext.BulkInsertOrUpdateAsync(new[]
        {
            new NpcTemplate
            {
                Race = Race.Elemental,
                IsUndead = false,
                Name = "Ice elemental",
                NameHu = "Jég elementál",
                Id = identity,
                AgilityMax = 13,
                AgilityMin = 1,
                BodyMax = 20,
                BodyMin = 2,
                DexterityMax = 13,
                DexterityMin = 1,
                StrengthMax = 13,
                StrengthMin = 1,
                Difficulty = Difficulty.Variable,
                IntelligenceMax = 13,
                IntelligenceMin = 1,
                EmotionMax = 13,
                EmotionMin = 1,
                WillpowerMax = 13,
                WillpowerMin = 1,
                DamageReductionMax = 7,
                CharacterSkills = new List<CharacterSkill>
                {
                    new()
                    {
                        SkillLevelMin = 1,
                        SkillLevelMax = 13,
                        SkillId = 2
                    }
                },
                CharacterWeapons = new List<CharacterWeapon>
                {
                    new()
                    {
                        Material = Material.Bone,
                        WeaponId = 43
                    },
                    new()
                    {
                        Material = Material.None,
                        WeaponId = 50,
                        IsOptional = true
                    }
                }
            }
        });
    }

    private static async Task AddAirElemental(DbContext dbContext, int identity)
    {
        await dbContext.BulkInsertOrUpdateAsync(new[]
        {
            new NpcTemplate
            {
                Race = Race.Elemental,
                IsUndead = false,
                Name = "Air elemental",
                NameHu = "Lég elementál",
                Id = identity,
                AgilityMax = 26,
                AgilityMin = 2,
                BodyMax = 7,
                BodyMin = 1,
                DexterityMax = 26,
                DexterityMin = 2,
                Difficulty = Difficulty.Variable,
                IntelligenceMax = 13,
                IntelligenceMin = 1,
                EmotionMax = 13,
                EmotionMin = 1,
                WillpowerMax = 13,
                WillpowerMin = 1,
                CharacterSkills = new List<CharacterSkill>
                {
                    new()
                    {
                        SkillLevelMin = 1,
                        SkillLevelMax = 13,
                        SkillId = 15
                    }
                },
                CharacterWeapons = new List<CharacterWeapon>
                {
                    new()
                    {
                        Material = Material.Bone,
                        WeaponId = 43
                    },
                    new()
                    {
                        Material = Material.None,
                        WeaponId = 62,
                        IsOptional = true
                    }
                }
            }
        });
    }

    private static async Task AddStormElemental(DbContext dbContext, int identity)
    {
        await dbContext.BulkInsertOrUpdateAsync(new[]
        {
            new NpcTemplate
            {
                Race = Race.Elemental,
                IsUndead = false,
                Name = "Storm elemental",
                NameHu = "Villám elementál",
                Id = identity,
                AgilityMax = 26,
                AgilityMin = 2,
                BodyMax = 7,
                BodyMin = 1,
                DexterityMax = 26,
                DexterityMin = 2,
                Difficulty = Difficulty.Variable,
                IntelligenceMax = 13,
                IntelligenceMin = 1,
                EmotionMax = 13,
                EmotionMin = 1,
                WillpowerMax = 13,
                WillpowerMin = 1,
                CharacterSkills = new List<CharacterSkill>
                {
                    new()
                    {
                        SkillLevelMin = 1,
                        SkillLevelMax = 13,
                        SkillId = 15
                    }
                },
                CharacterWeapons = new List<CharacterWeapon>
                {
                    new()
                    {
                        Material = Material.Bone,
                        WeaponId = 43
                    },
                    new()
                    {
                        Material = Material.None,
                        WeaponId = 55,
                        IsOptional = true
                    }
                }
            }
        });
    }
    
    private static async Task AddEarthElemental(DbContext dbContext, int identity)
    {
        await dbContext.BulkInsertOrUpdateAsync(new[]
        {
            new NpcTemplate
            {
                Race = Race.Elemental,
                IsUndead = false,
                Name = "Earth elemental",
                NameHu = "Föld elementál",
                Id = identity,
                AgilityMax = 13,
                AgilityMin = 1,
                BodyMax = 26,
                BodyMin = 2,
                DexterityMax = 13,
                DexterityMin = 1,
                StrengthMax = 15,
                StrengthMin = 3,
                Difficulty = Difficulty.Variable,
                IntelligenceMax = 13,
                IntelligenceMin = 1,
                EmotionMax = 13,
                EmotionMin = 1,
                WillpowerMax = 13,
                WillpowerMin = 1,
                CharacterSkills = new List<CharacterSkill>
                {
                    new()
                    {
                        SkillLevelMin = 1,
                        SkillLevelMax = 13,
                        SkillId = 4
                    }
                },
                CharacterWeapons = new List<CharacterWeapon>
                {
                    new()
                    {
                        Material = Material.Bone,
                        WeaponId = 43
                    }
                }
            }
        });
    }

    private static async Task AddRockElemental(DbContext dbContext, int identity)
    {
        await dbContext.BulkInsertOrUpdateAsync(new[]
        {
            new NpcTemplate
            {
                Race = Race.Elemental,
                IsUndead = false,
                Name = "Rock elemental",
                NameHu = "Szikla elementál",
                Id = identity,
                AgilityMax = 7,
                AgilityMin = 1,
                BodyMax = 39,
                BodyMin = 3,
                DexterityMax = 7,
                DexterityMin = 1,
                StrengthMax = 26,
                StrengthMin = 2,
                Difficulty = Difficulty.Variable,
                IntelligenceMax = 13,
                IntelligenceMin = 1,
                EmotionMax = 13,
                EmotionMin = 1,
                WillpowerMax = 13,
                WillpowerMin = 1,
                DamageReductionMax = 13,
                CharacterSkills = new List<CharacterSkill>
                {
                    new()
                    {
                        SkillLevelMin = 1,
                        SkillLevelMax = 13,
                        SkillId = 4
                    }
                },
                CharacterWeapons = new List<CharacterWeapon>
                {
                    new()
                    {
                        Material = Material.Bone,
                        WeaponId = 43
                    }
                }
            }
        });
    }

    private static async Task AddSandElemental(DbContext dbContext, int identity)
    {
        await dbContext.BulkInsertOrUpdateAsync(new[]
        {
            new NpcTemplate
            {
                Race = Race.Elemental,
                IsUndead = false,
                Name = "Sand elemental",
                NameHu = "Homok elementál",
                Id = identity,
                AgilityMax = 13,
                AgilityMin = 1,
                BodyMax = 13,
                BodyMin = 1,
                DexterityMax = 13,
                DexterityMin = 1,
                StrengthMax = 14,
                StrengthMin = 2,
                Difficulty = Difficulty.Variable,
                IntelligenceMax = 13,
                IntelligenceMin = 1,
                EmotionMax = 13,
                EmotionMin = 1,
                WillpowerMax = 13,
                WillpowerMin = 1,
                CharacterSkills = new List<CharacterSkill>
                {
                    new()
                    {
                        SkillLevelMin = 1,
                        SkillLevelMax = 13,
                        SkillId = 2
                    }
                },
                CharacterWeapons = new List<CharacterWeapon>
                {
                    new()
                    {
                        Material = Material.Bone,
                        WeaponId = 43
                    },
                    new()
                    {
                        Material = Material.None,
                        WeaponId = 63,
                        IsOptional = true
                    }
                }
            }
        });
    }
}