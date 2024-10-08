using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplates;

public class Npc : IMapFrom<MonsterBook.Domain.NpcTemplate>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int StrengthMax { get; set; }
    public int StrengthMin { get; set; }
    public int VitalityMax { get; set; }
    public int VitalityMin { get; set; }
    public int BodyMax { get; set; }
    public int BodyMin { get; set; }
    public int AgilityMax { get; set; }
    public int AgilityMin { get; set; }
    public int DexterityMax { get; set; }
    public int DexterityMin { get; set; }
    public int IntelligenceMax { get; set; }
    public int IntelligenceMin { get; set; }
    public int WillpowerMax { get; set; }
    public int WillpowerMin { get; set; }
    public int EmotionMax { get; set; }
    public int EmotionMin { get; set; }
    public int KarmaMax { get; set; }
    public int KarmaMin { get; set; }
    public int HitPointMax { get; set; }
    public int HitPointMin { get; set; }
    public int ManaMax { get; set; }
    public int ManaMin { get; set; }
    public int PowerPointMax { get; set; }
    public int PowerPointMin { get; set; }
    public Difficulty Difficulty { get; set; }
    public Race Race { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.NpcTemplate, Npc>()
            .ForMember(npcTemplate => npcTemplate.ManaMin, opt => opt.Ignore())
            .ForMember(npcTemplate => npcTemplate.ManaMax, opt => opt.Ignore())
            .ForMember(npcTemplate => npcTemplate.HitPointMin, opt => opt.Ignore())
            .ForMember(npcTemplate => npcTemplate.HitPointMax, opt => opt.Ignore())
            .ForMember(npcTemplate => npcTemplate.PowerPointMin, opt => opt.Ignore())
            .ForMember(npcTemplate => npcTemplate.PowerPointMax, opt => opt.Ignore());
    }
}