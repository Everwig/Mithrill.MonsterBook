using System.Collections.Generic;
using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

public sealed record NpcTemplate(
    int? Id,
    string Name,
    int StrengthMax,
    int StrengthMin,
    int VitalityMax,
    int VitalityMin,
    int BodyMax,
    int BodyMin,
    int AgilityMax,
    int AgilityMin,
    int DexterityMax,
    int DexterityMin,
    int IntelligenceMax,
    int IntelligenceMin,
    int WillpowerMax,
    int WillpowerMin,
    int EmotionMax,
    int EmotionMin,
    int DamageReductionMax,
    int DamageReductionMin,
    int KarmaMax,
    int KarmaMin,
    bool IsUndead,
    Race Race,
    Difficulty Difficulty,
    SkillCategories? SkillCategories,
    ArcanumRanks? ArcanumRanks,
    HashSet<Merit> Merits,
    HashSet<Flaw> Flaws,
    HashSet<Skill> Skills,
    IEnumerable<Armor> Armors,
    IEnumerable<Weapon> Weapons) : IRanks;