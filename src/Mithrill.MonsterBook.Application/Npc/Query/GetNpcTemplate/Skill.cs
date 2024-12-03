using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate;

public sealed record Skill(
     int Id,
     string Name,
     int MinLevel,
     int MaxLevel,
     int GuaranteedSuccesses,
     bool IsOptional,
     Attribute Attribute1,
     Attribute Attribute2,
     SkillCategory Category
) : IMapFrom<MonsterBook.Domain.CharacterSkill>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.CharacterSkill, Skill>()
            .ForCtorParam(ctorParamName: nameof(Id), option => option.MapFrom(creatureSkill => creatureSkill.Skill.Id))
            .ForCtorParam(ctorParamName: nameof(Name), option => option.MapFrom(creatureSkill => creatureSkill.Skill.Name))
            .ForCtorParam(ctorParamName: nameof(MinLevel), option => option.MapFrom(creatureSkill => creatureSkill.SkillLevelMin))
            .ForCtorParam(ctorParamName: nameof(MaxLevel), option => option.MapFrom(creatureSkill => creatureSkill.SkillLevelMax))
            .ForCtorParam(ctorParamName: nameof(GuaranteedSuccesses), option => option.MapFrom(creatureSkill => creatureSkill.GuaranteedSuccesses))
            .ForCtorParam(ctorParamName: nameof(IsOptional), option => option.MapFrom(creatureSkill => creatureSkill.IsOptional))
            .ForCtorParam(ctorParamName: nameof(Attribute1), option => option.MapFrom(creatureSkill => creatureSkill.Skill.Attribute1))
            .ForCtorParam(ctorParamName: nameof(Attribute2), option => option.MapFrom(creatureSkill => creatureSkill.Skill.Attribute2))
            .ForCtorParam(ctorParamName: nameof(Category), option => option.MapFrom(creatureSkill => creatureSkill.Skill.Category));
    }
}