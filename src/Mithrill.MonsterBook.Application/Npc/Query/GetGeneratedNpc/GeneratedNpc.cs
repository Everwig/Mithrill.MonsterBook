using System.Collections.Generic;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;
using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;

public sealed record GeneratedNpc(
    string Name,
    int Strength,
    int Vitality,
    int Body,
    int Agility,
    int Dexterity,
    int Intelligence,
    int Willpower,
    int Emotion,
    int DamageReduction,
    int Karma,
    Difficulty Difficulty,
    List<Weapon> Weapons,
    List<Armor> Armors,
    HashSet<Skill> Skills,
    HashSet<Merit> Merits,
    HashSet<Flaw> Flaws,
    int HitPoint,
    int ManaPoint,
    int PowerPoint
) : IMapFrom<GeneratedCreature>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<GeneratedCreature, GeneratedNpc>()
            .ForCtorParam(ctorParamName: nameof(Name), opt => opt.MapFrom(creature => creature.Name))
            .ForCtorParam(ctorParamName: nameof(Strength), opt => opt.MapFrom(creature => creature.Strength))
            .ForCtorParam(ctorParamName: nameof(Vitality), opt => opt.MapFrom(creature => creature.Vitality))
            .ForCtorParam(ctorParamName: nameof(Body), opt => opt.MapFrom(creature => creature.Body))
            .ForCtorParam(ctorParamName: nameof(Agility), opt => opt.MapFrom(creature => creature.Agility))
            .ForCtorParam(ctorParamName: nameof(Dexterity), opt => opt.MapFrom(creature => creature.Dexterity))
            .ForCtorParam(ctorParamName: nameof(Intelligence), opt => opt.MapFrom(creature => creature.Intelligence))
            .ForCtorParam(ctorParamName: nameof(Willpower), opt => opt.MapFrom(creature => creature.Willpower))
            .ForCtorParam(ctorParamName: nameof(Emotion), opt => opt.MapFrom(creature => creature.Emotion))
            .ForCtorParam(ctorParamName: nameof(DamageReduction), opt => opt.MapFrom(creature => creature.DamageReduction))
            .ForCtorParam(ctorParamName: nameof(Karma), opt => opt.MapFrom(creature => creature.Karma))
            .ForCtorParam(ctorParamName: nameof(Difficulty), opt => opt.MapFrom(creature => creature.Difficulty))
            .ForCtorParam(ctorParamName: nameof(Weapons), opt => opt.MapFrom(creature => creature.Weapons))
            .ForCtorParam(ctorParamName: nameof(Armors), opt => opt.MapFrom(creature => creature.Armors))
            .ForCtorParam(ctorParamName: nameof(Skills), opt => opt.MapFrom(creature => creature.Skills))
            .ForCtorParam(ctorParamName: nameof(Merits), opt => opt.MapFrom(creature => creature.Merits))
            .ForCtorParam(ctorParamName: nameof(Flaws), opt => opt.MapFrom(creature => creature.Flaws))
            .ForCtorParam(ctorParamName: nameof(PowerPoint), opt => opt.MapFrom(creature => creature.PowerPoint))
            .ForCtorParam(ctorParamName: nameof(ManaPoint), opt => opt.MapFrom(creature => creature.ManaPoint))
            .ForCtorParam(ctorParamName: nameof(HitPoint), opt => opt.MapFrom(creature => creature.HitPoint));
    }
};