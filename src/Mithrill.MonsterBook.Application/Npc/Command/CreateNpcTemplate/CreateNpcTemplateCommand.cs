using System.Collections.Generic;
using AutoMapper;
using MediatR;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Difficulty = Mithrill.MonsterBook.Application.Common.Difficulty;
using Race = Mithrill.MonsterBook.Application.Common.Race;

namespace Mithrill.MonsterBook.Application.Npc.Command.CreateNpcTemplate;

public sealed record CreateNpcTemplateCommand(
    string Name,
    string NameHu,
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
    List<Armor> Armors,
    List<Weapon> Weapons) :
    IRequest<int>,
    IRanks,
    IMapTo<MonsterBook.Domain.NpcTemplate>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateNpcTemplateCommand, MonsterBook.Domain.NpcTemplate>()
            .ForMember(template => template.Id, opt => opt.Ignore())
            .ForMember(template => template.CharacterMerits, opt => opt.MapFrom(template => template.Merits))
            .ForMember(template => template.CharacterFlaws, opt => opt.MapFrom(template => template.Flaws))
            .ForMember(template => template.CharacterSkills, opt => opt.MapFrom(template => template.Skills))
            .ForMember(template => template.CharacterArmors, opt => opt.MapFrom(template => template.Armors))
            .ForMember(template => template.CharacterWeapons, opt => opt.MapFrom(template => template.Weapons))
            .ForMember(template => template.CharacterSkillCategories, opt => opt.MapFrom(template => template.SkillCategories));
    }
}