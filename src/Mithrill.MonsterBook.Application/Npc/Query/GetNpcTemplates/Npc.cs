using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Domain.Entities;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplates;

public sealed record Npc(
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
    bool IsUndead) : IMapFrom<NpcTemplate> 
{
    public int HitPointMax { get; internal set; }
    public int HitPointMin { get; internal set; }
    public int ManaPointMax { get; internal set; }
    public int ManaPointMin { get; internal set; }
    public int PowerPointMax { get; internal set; }
    public int PowerPointMin { get; internal set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<NpcTemplate, Npc>()
            .ForMember(npcTemplate => npcTemplate.ManaPointMin, opt => opt.Ignore())
            .ForMember(npcTemplate => npcTemplate.ManaPointMax, opt => opt.Ignore())
            .ForMember(npcTemplate => npcTemplate.HitPointMin, opt => opt.Ignore())
            .ForMember(npcTemplate => npcTemplate.HitPointMax, opt => opt.Ignore())
            .ForMember(npcTemplate => npcTemplate.PowerPointMin, opt => opt.Ignore())
            .ForMember(npcTemplate => npcTemplate.PowerPointMax, opt => opt.Ignore());
    }
}