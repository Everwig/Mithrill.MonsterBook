using AutoMapper;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Common;

public sealed record AttackType(DamageType DamageType, int NumberOfDices, int GuaranteedDamage) :
    IMapTo<MonsterBook.Domain.Entities.AttackType>,
    IMapFrom<MonsterBook.Domain.Entities.AttackType>
{
    void IMapTo<MonsterBook.Domain.Entities.AttackType>.Mapping(Profile profile)
    {
        profile.CreateMap<AttackType, MonsterBook.Domain.Entities.AttackType>()
            .ForMember(attackType => attackType.Id, opt => opt.Ignore())
            .ForMember(attackType => attackType.Weapons, opt => opt.Ignore())
            .ForMember(attackType => attackType.CharacterWeaponAttackTypes, opt => opt.Ignore());
    }

    void IMapFrom<MonsterBook.Domain.Entities.AttackType>.Mapping(Profile profile)
    {
        profile.CreateMap<MonsterBook.Domain.Entities.AttackType, AttackType>()
            .ForCtorParam(ctorParamName: nameof(DamageType), opt => opt.MapFrom(attackType => attackType.DamageType))
            .ForCtorParam(ctorParamName: nameof(NumberOfDices), opt => opt.MapFrom(attackType => attackType.NumberOfDices))
            .ForCtorParam(ctorParamName: nameof(GuaranteedDamage), opt => opt.MapFrom(attackType => attackType.GuaranteedDamage));
    }

    public bool Equals(AttackType? other) => other is not null && other.DamageType == DamageType;

    public override int GetHashCode() => DamageType.GetHashCode();
}