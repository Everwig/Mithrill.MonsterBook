using System.Collections.Generic;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedSummon;

public sealed record GeneratedSummon(
    string Name,
    int Strength,
    int Vitality,
    int Body,
    int Agility,
    int Dexterity,
    int Intelligence,
    int Willpower,
    int Emotion,
    int Karma,
    int DamageReduction,
    List<Weapon> Weapons,
    HashSet<Skill> Skills,
    HashSet<Merit> Merits,
    int HitPoint,
    int ManaPoint,
    int PowerPoint) :
    IMapFrom<GeneratedCreature>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<GeneratedCreature, GeneratedSummon>()
            .ForCtorParam(nameof(Name), opt => opt.MapFrom(generatedCreature => generatedCreature.Name))
            .ForCtorParam(nameof(Strength), opt => opt.MapFrom(generatedCreature => generatedCreature.Strength))
            .ForCtorParam(nameof(Vitality), opt => opt.MapFrom(generatedCreature => generatedCreature.Vitality))
            .ForCtorParam(nameof(Body), opt => opt.MapFrom(generatedCreature => generatedCreature.Body))
            .ForCtorParam(nameof(Agility), opt => opt.MapFrom(generatedCreature => generatedCreature.Agility))
            .ForCtorParam(nameof(Dexterity), opt => opt.MapFrom(generatedCreature => generatedCreature.Dexterity))
            .ForCtorParam(nameof(Intelligence), opt => opt.MapFrom(generatedCreature => generatedCreature.Intelligence))
            .ForCtorParam(nameof(Willpower), opt => opt.MapFrom(generatedCreature => generatedCreature.Willpower))
            .ForCtorParam(nameof(Emotion), opt => opt.MapFrom(generatedCreature => generatedCreature.Emotion))
            .ForCtorParam(nameof(Karma), opt => opt.MapFrom(generatedCreature => generatedCreature.Karma))
            .ForCtorParam(nameof(DamageReduction), opt => opt.MapFrom(generatedCreature => generatedCreature.DamageReduction))
            .ForCtorParam(nameof(Weapons), opt => opt.MapFrom(generatedCreature => generatedCreature.Weapons))
            .ForCtorParam(nameof(Skills), opt => opt.MapFrom(generatedCreature => generatedCreature.Skills))
            .ForCtorParam(nameof(Merits), opt => opt.MapFrom(generatedCreature => generatedCreature.Merits))
            .ForCtorParam(nameof(ManaPoint), opt => opt.MapFrom(generatedCreature => generatedCreature.ManaPoint))
            .ForCtorParam(nameof(HitPoint), opt => opt.MapFrom(generatedCreature => generatedCreature.HitPoint))
            .ForCtorParam(nameof(PowerPoint), opt => opt.MapFrom(generatedCreature => generatedCreature.PowerPoint));
    }
}