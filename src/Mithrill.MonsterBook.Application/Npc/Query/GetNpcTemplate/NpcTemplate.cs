using System;
using System.Collections.Generic;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate;

public sealed record NpcTemplate(
    int Id,
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
    int KarmaMax,
    int KarmaMin,
    Difficulty Difficulty,
    Race Race,
    bool IsUndead,
    HashSet<Merit> Merits,
    HashSet<Flaw> Flaws,
    HashSet<Weapon> Weapons,
    HashSet<Skill> Skills,
    HashSet<Armor> Armors,
    SkillCategories? SkillCategories,
    ArcanumRanks? ArcanumRanks
) : IMapFrom<MonsterBook.Domain.NpcTemplate>
{
    public int HitPointMax { get; internal set; }
    public int HitPointMin { get; internal set; }
    public int ManaPointMax { get; internal set; }
    public int ManaPointMin { get; internal set; }
    public int PowerPointMax { get; internal set; }
    public int PowerPointMin { get; internal set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.NpcTemplate, NpcTemplate>()
            .ForMember(npc => npc.ManaPointMin, opt => opt.Ignore())
            .ForMember(npc => npc.ManaPointMax, opt => opt.Ignore())
            .ForMember(npc => npc.HitPointMin, opt => opt.Ignore())
            .ForMember(npc => npc.HitPointMax, opt => opt.Ignore())
            .ForMember(npc => npc.PowerPointMin, opt => opt.Ignore())
            .ForMember(npc => npc.PowerPointMax, opt => opt.Ignore())
            .ForCtorParam(ctorParamName: nameof(Id), option => option.MapFrom(creature => creature.Id))
            .ForCtorParam(ctorParamName: nameof(Name), option => option.MapFrom(creature => creature.Name))
            .ForCtorParam(ctorParamName: nameof(StrengthMax), option => option.MapFrom(creature => creature.StrengthMax))
            .ForCtorParam(ctorParamName: nameof(StrengthMin), option => option.MapFrom(creature => creature.StrengthMin))
            .ForCtorParam(ctorParamName: nameof(VitalityMax), option => option.MapFrom(creature => creature.VitalityMax))
            .ForCtorParam(ctorParamName: nameof(VitalityMin), option => option.MapFrom(creature => creature.VitalityMin))
            .ForCtorParam(ctorParamName: nameof(BodyMax), option => option.MapFrom(creature => creature.BodyMax))
            .ForCtorParam(ctorParamName: nameof(BodyMin), option => option.MapFrom(creature => creature.BodyMin))
            .ForCtorParam(ctorParamName: nameof(AgilityMax), option => option.MapFrom(creature => creature.AgilityMax))
            .ForCtorParam(ctorParamName: nameof(AgilityMin), option => option.MapFrom(creature => creature.AgilityMin))
            .ForCtorParam(ctorParamName: nameof(DexterityMax), option => option.MapFrom(creature => creature.DexterityMax))
            .ForCtorParam(ctorParamName: nameof(DexterityMin), option => option.MapFrom(creature => creature.DexterityMin))
            .ForCtorParam(ctorParamName: nameof(IntelligenceMax), option => option.MapFrom(creature => creature.IntelligenceMax))
            .ForCtorParam(ctorParamName: nameof(IntelligenceMin), option => option.MapFrom(creature => creature.IntelligenceMin))
            .ForCtorParam(ctorParamName: nameof(WillpowerMax), option => option.MapFrom(creature => creature.WillpowerMax))
            .ForCtorParam(ctorParamName: nameof(WillpowerMin), option => option.MapFrom(creature => creature.WillpowerMin))
            .ForCtorParam(ctorParamName: nameof(EmotionMax), option => option.MapFrom(creature => creature.EmotionMax))
            .ForCtorParam(ctorParamName: nameof(EmotionMin), option => option.MapFrom(creature => creature.EmotionMin))
            .ForCtorParam(ctorParamName: nameof(KarmaMax), option => option.MapFrom(creature => creature.KarmaMax))
            .ForCtorParam(ctorParamName: nameof(KarmaMin), option => option.MapFrom(creature => creature.KarmaMin))
            .ForCtorParam(ctorParamName: nameof(Difficulty), option => option.MapFrom(creature => creature.Difficulty))
            .ForCtorParam(ctorParamName: nameof(Race), option => option.MapFrom(creature => creature.Race))
            .ForCtorParam(ctorParamName: nameof(IsUndead), option => option.MapFrom(creature => creature.IsUndead))
            .ForCtorParam(ctorParamName: nameof(Merits), opt => opt.MapFrom(creature => creature.CharacterMerits))
            .ForCtorParam(ctorParamName: nameof(Flaws), opt => opt.MapFrom(creature => creature.CharacterFlaws))
            .ForCtorParam(ctorParamName: nameof(Weapons), opt => opt.MapFrom(creature => creature.CharacterWeapons))
            .ForCtorParam(ctorParamName: nameof(Skills), opt => opt.MapFrom(creature => creature.CharacterSkills))
            .ForCtorParam(ctorParamName: nameof(Armors), opt => opt.MapFrom(creature => creature.CharacterArmors))
            .ForCtorParam(ctorParamName: nameof(SkillCategories), opt => opt.MapFrom(creature => creature.CharacterSkillCategories))
            .ForCtorParam(ctorParamName: nameof(ArcanumRanks), opt => opt.MapFrom(creature => (ArcanumRanks?)null));
    }
}