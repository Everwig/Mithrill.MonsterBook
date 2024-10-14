﻿using System.Collections.Generic;
using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate
{
    public class NpcTemplate : IMapFrom<MonsterBook.Domain.NpcTemplate>
    {
        public NpcTemplate()
        {
            Flaws = new List<Flaw>();
            Merits = new List<Merit>();
            Weapons = new List<Weapon>();
            Skills = new List<Skill>();
            Armors = new List<Armor>();
        }

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
        public int ManaPointMax { get; set; }
        public int ManaPointMin { get; set; }
        public int PowerPointMax { get; set; }
        public int PowerPointMin { get; set; }
        public Difficulty Difficulty { get; set; }
        public Race Race { get; set; }
        public bool IsUndead { get; set; }
        public IEnumerable<Merit> Merits { get; set; }
        public IEnumerable<Flaw> Flaws { get; set; }
        public IEnumerable<Weapon> Weapons { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Armor> Armors { get; set; }
        public SkillCategories? SkillCategories { get; set; }
        public ArcanumRanks? ArcanumRanks { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MonsterBook.Domain.NpcTemplate, NpcTemplate>()
                .ForMember(npc => npc.ManaPointMin, opt => opt.Ignore())
                .ForMember(npc => npc.ManaPointMax, opt => opt.Ignore())
                .ForMember(npc => npc.HitPointMin, opt => opt.Ignore())
                .ForMember(npc => npc.HitPointMax, opt => opt.Ignore())
                .ForMember(npc => npc.PowerPointMin, opt => opt.Ignore())
                .ForMember(npc => npc.PowerPointMax, opt => opt.Ignore())
                .ForMember(npc => npc.Merits, opt => opt.MapFrom(creature => creature.CharacterMerits))
                .ForMember(npc => npc.Flaws, opt => opt.MapFrom(creature => creature.CharacterFlaws))
                .ForMember(npc => npc.Weapons, opt => opt.MapFrom(creature => creature.CharacterWeapons))
                .ForMember(npc => npc.Skills, opt => opt.MapFrom(creature => creature.CharacterSkills))
                .ForMember(npc => npc.Armors, opt => opt.MapFrom(creature => creature.CharacterArmors))
                .ForMember(npc => npc.SkillCategories, opt => opt.MapFrom(creature => creature.CharacterSkillCategories))
                .ForMember(npc => npc.ArcanumRanks, opt => opt.Ignore());
        }
    }
}