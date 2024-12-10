using AutoMapper;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate;

public sealed record AttackType(
    int Id,
    DamageType DamageType,
    int NumberOfDices,
    int GuaranteedDamage,
    bool IsBaseAttackType
) : IMapFrom<MonsterBook.Domain.Entities.AttackType>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.Entities.AttackType, AttackType>()
            .ForCtorParam(ctorParamName: nameof(Id), opt => opt.MapFrom(attackType => attackType.Id))
            .ForCtorParam(ctorParamName: nameof(DamageType), opt => opt.MapFrom(attackType => attackType.DamageType))
            .ForCtorParam(ctorParamName: nameof(NumberOfDices), opt => opt.MapFrom(attackType => attackType.NumberOfDices))
            .ForCtorParam(ctorParamName: nameof(GuaranteedDamage), opt => opt.MapFrom(attackType => attackType.GuaranteedDamage))
            .ForCtorParam(ctorParamName: nameof(IsBaseAttackType), opt => opt.MapFrom(attackType => false));
    }
}