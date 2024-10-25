using FluentValidation;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Common.Validation;

public static class ArmorAndWeaponValidatorExtensions
{
    public const int MinAdditionalValue = 0;
    public const int MaxAdditionalValue = 5;
    public const int MgtMinValue = -5;
    public const int MgtMaxValue = 5;
    public const int MinNumberOfDices = 1;
    public const int MaxNumberOfDices = 8;
    public const int MinGuaranteedDamage = 0;
    public const int MaxGuaranteedDamage = 2;

    public static IRuleBuilderOptions<T, int> AdditionalValueValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(MinAdditionalValue, MaxAdditionalValue);

    public static IRuleBuilderOptions<T, int> AdditionalMgtValueValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(MgtMinValue, MgtMaxValue);

    public static IRuleBuilderOptions<T, int> IsValidArmorId<T>(
        this IRuleBuilderInitial<T, int> rule,
        ITemplateValidatorService templateValidatorService) =>
        rule.MustAsync(templateValidatorService.IsValidArmorId);

    public static IRuleBuilderOptions<T, int> IsValidWeaponId<T>(
        this IRuleBuilderInitial<T, int> rule,
        ITemplateValidatorService templateValidatorService) =>
        rule.MustAsync(templateValidatorService.IsValidWeaponId);

    public static IRuleBuilderOptions<T, int> NumberOfDicesValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(MinNumberOfDices, MaxNumberOfDices);

    public static IRuleBuilderOptions<T, int> GuaranteedDamageValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(MinGuaranteedDamage, MaxGuaranteedDamage);
}