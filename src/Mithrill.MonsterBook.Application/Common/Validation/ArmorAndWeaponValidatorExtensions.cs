using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Common.Validation;

public static class ArmorAndWeaponValidatorExtensions
{
    public const int MinArmorClassValue = 0;
    public const int MaxArmorClassValue = 5;
    public const int MovementInhibitoryFactorMinValue = -5;
    public const int MovementInhibitoryFactorMaxValue = 5;
    public const int MinNumberOfDices = 1;
    public const int MaxNumberOfDices = 8;
    public const int MinGuaranteedDamage = 0;
    public const int MaxGuaranteedDamage = 2;
    private static readonly IReadOnlyCollection<DamageType> ElementalDamageTypes =
    [
        DamageType.Fire,
        DamageType.Lightning,
        DamageType.Ice,
        DamageType.Light,
        DamageType.Dark,
        DamageType.Acid,
        DamageType.Poison
    ];

    public static IRuleBuilderOptions<T, int> AdditionalArmorClassValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(MinArmorClassValue, MaxArmorClassValue)
            .WithErrorCode("ArmorClassValidator");

    public static IRuleBuilderOptions<T, int> AdditionalMovementInhibitoryFactorValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(MovementInhibitoryFactorMinValue, MovementInhibitoryFactorMaxValue)
            .WithErrorCode("MovementInhibitoryFactorValidator");

    public static IRuleBuilderOptions<T, int> IsValidArmorId<T>(
        this IRuleBuilderInitial<T, int> rule,
        ITemplateValidatorService templateValidatorService) =>
        rule.MustAsync(templateValidatorService.IsValidArmorId)
            .WithErrorCode("ArmorValidator")
            .WithMessage((_, id) => $"Armor with id '{id}' doesn't exist.");

    public static IRuleBuilderOptions<T, int> IsValidWeaponId<T>(
        this IRuleBuilderInitial<T, int> rule,
        ITemplateValidatorService templateValidatorService) =>
        rule.MustAsync(templateValidatorService.IsValidWeaponId)
            .WithErrorCode("WeaponValidator")
            .WithMessage((_, id) => $"Weapon with id '{id}' doesn't exist.");

    public static IRuleBuilderOptions<T, int> AdditionalModifierValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(MinArmorClassValue, MaxArmorClassValue)
            .WithErrorCode("WeaponModifierValidator");

    public static IRuleBuilderOptions<AttackType, int> NumberOfDicesValidation(this IRuleBuilderInitial<AttackType, int> rule) =>
        rule.InclusiveBetween(MinNumberOfDices, MaxNumberOfDices)
            .WithErrorCode("AttackTypeDamageValidator");

    public static IRuleBuilderOptions<AttackType, int> GuaranteedDamageValidation(
        this IRuleBuilderInitial<AttackType, int> rule) =>
        rule.InclusiveBetween(MinGuaranteedDamage, MaxGuaranteedDamage)
            .WithErrorCode("AttackTypeGuaranteedDamageValidator")
            .Equal(MinGuaranteedDamage)
            .When(attackType => ElementalDamageTypes.Contains(attackType.DamageType), ApplyConditionTo.CurrentValidator)
            .WithErrorCode("AttackTypeGuaranteedDamageValidator")
            .WithMessage("Guaranteed Damage must be 0 if Damage Type is elemental type.");
}