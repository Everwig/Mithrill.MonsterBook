using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Common;

public record AttackType(DamageType DamageType, int NumberOfDices, int GuaranteedDamage) :
    IAttackType,
    IMapTo<MonsterBook.Domain.AttackType>,
    IMapFrom<MonsterBook.Domain.AttackType>
{
    void IMapTo<MonsterBook.Domain.AttackType>.Mapping(Profile profile)
    {
        profile.CreateMap<AttackType, MonsterBook.Domain.AttackType>()
            .ForMember(attackType => attackType.Id, opt => opt.Ignore())
            .ForMember(attackType => attackType.Weapons, opt => opt.Ignore())
            .ForMember(attackType => attackType.CharacterWeaponAttackTypes, opt => opt.Ignore());
    }

    void IMapFrom<MonsterBook.Domain.AttackType>.Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.AttackType, AttackType>()
            .ForCtorParam(ctorParamName: nameof(DamageType), opt => opt.MapFrom(attackType => attackType.DamageType))
            .ForCtorParam(ctorParamName: nameof(NumberOfDices), opt => opt.MapFrom(attackType => attackType.NumberOfDices))
            .ForCtorParam(ctorParamName: nameof(GuaranteedDamage), opt => opt.MapFrom(attackType => attackType.GuaranteedDamage));
    }

    public virtual bool Equals(AttackType? other) => other is not null && other.DamageType == DamageType;

    public override int GetHashCode() => DamageType.GetHashCode();
}