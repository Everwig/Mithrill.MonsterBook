﻿using System.Collections.Generic;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures;

public class Creature : IMapFrom<MonsterBook.Domain.Creature>
{
    public Creature()
    {
        Skills = new List<Skill>();
        Merits = new List<Merit>();
        Flaws = new List<Flaw>();
        Armors = new List<Armor>();
        Weapons = new List<Weapon>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
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
    public IEnumerable<Skill> Skills { get; set; }
    public IEnumerable<Merit> Merits { get; set; }
    public IEnumerable<Flaw> Flaws { get; set; }
    public IEnumerable<Armor> Armors { get; set; }
    public IEnumerable<Weapon> Weapons { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.Creature, Creature>()
            .ForMember(creature => creature.ManaMin, opt => opt.Ignore())
            .ForMember(creature => creature.ManaMax, opt => opt.Ignore())
            .ForMember(creature => creature.HitPointMin, opt => opt.Ignore())
            .ForMember(creature => creature.HitPointMax, opt => opt.Ignore())
            .ForMember(creature => creature.PowerPointMin, opt => opt.Ignore())
            .ForMember(creature => creature.PowerPointMax, opt => opt.Ignore())
            .ForMember(creature => creature.Skills, opt => opt.MapFrom(creature => creature.CreatureSkills))
            .ForMember(creature => creature.Merits, opt => opt.MapFrom(creature => creature.CreatureMerits))
            .ForMember(creature => creature.Flaws, opt => opt.MapFrom(creature => creature.CreatureFlaws))
            .ForMember(creature => creature.Armors, opt => opt.MapFrom(creature => creature.CreatureArmors))
            .ForMember(creature => creature.Weapons, opt => opt.MapFrom(creature => creature.CreatureWeapons));
    }
}