using System;
using System.Collections.Generic;
using FluentValidation;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Common.Validation;

public static class BaseStatValidatorExtensions
{
    public const int MinAttributeValue = 1;
    public const int MaxAttributeValue = 100;
    public const int Zero = 0;
    public const int MaxKarmaValue = 12;
    public const int MaxStringLength = 64;
    public const string DefaultRuleSetName = "default";

    public static IRuleBuilderOptions<T, int> AttributeValidation<T>(this IRuleBuilderInitial<T, int> rule)
        where T : ISummonTemplate, IUndeadTemplate =>
        rule.InclusiveBetween(MinAttributeValue, MaxAttributeValue)
            .When(template => !template.IsSummon && !template.IsUndead, ApplyConditionTo.CurrentValidator)
            .WithErrorCode("NonZeroableAttributeValidator")
            .InclusiveBetween(Zero, MaxAttributeValue)
            .When(template => template.IsSummon || template.IsUndead, ApplyConditionTo.CurrentValidator)
            .WithErrorCode("ZeroableAttributeValidator");

    public static IRuleBuilderOptions<T, TK> EnumValidation<T, TK>(this IRuleBuilderInitial<T, TK> rule)
        where TK : Enum =>
        rule.IsInEnum();

    public static IRuleBuilderOptions<T, string> NameValidation<T>(this IRuleBuilderInitial<T, string> rule) =>
        rule.NotEmpty()
            .MaximumLength(MaxStringLength);

    public static IRuleBuilderOptions<T, int> ZeroableValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(Zero, MaxKarmaValue)
            .WithErrorCode("ZeroableAttributeValidator");

    public static IRuleBuilderOptions<T, int?> NpcTemplateIdValidation<T>(
        this IRuleBuilderInitial<T, int?> rule,
        ITemplateValidatorService templateValidatorService) =>
        rule.Cascade(CascadeMode.Stop)
            .NotNull()
            .MustAsync(async (id, cancellationToken) => id.HasValue &&
                                                        await templateValidatorService.IsValidTemplateId(id.Value,
                                                            cancellationToken))
            .WithErrorCode("IdValidator")
            .WithMessage((_, id) => $"Template with '{id}' does not exist.");

    public static IRuleBuilderOptions<T, int> NpcTemplateIdValidation<T>(
        this IRuleBuilderInitial<T, int> rule,
        ITemplateValidatorService templateValidatorService) =>
        rule.MustAsync(templateValidatorService.IsValidTemplateId)
            .WithErrorCode("IdValidator")
            .WithMessage((_, id) => $"Template with '{id}' does not exist.");

    public static IRuleBuilderOptions<IEnumerable<T>, T> MeritValidation<T>(
        this IRuleBuilderInitialCollection<IEnumerable<T>, T> rule,
        ITemplateValidatorService templateValidatorService)
        where T : AggregateRoot<int> =>
        rule.MustAsync((merit, cancellationToken) =>
                templateValidatorService.IsValidMeritId(merit.Id, cancellationToken))
            .WithErrorCode("MeritValidator")
            .WithMessage((_, merit) => $"Merit with id '{merit.Id}' doesn't exist.");

    public static IRuleBuilderOptions<IEnumerable<T>, T> FlawValidation<T>(
        this IRuleBuilderInitialCollection<IEnumerable<T>, T> rule,
        ITemplateValidatorService templateValidatorService)
        where T : AggregateRoot<int> =>
        rule.MustAsync((merit, cancellationToken) =>
                templateValidatorService.IsValidMeritId(merit.Id, cancellationToken))
            .WithErrorCode("FlawValidator")
            .WithMessage((_, flaw) => $"Flaw with id '{flaw.Id}' doesn't exist.");

    public static IRuleBuilderOptions<T, bool> IsSummonValidation<T>(this IRuleBuilderInitial<T, bool> rule)
        where T : ISummonTemplate, IUndeadTemplate =>
        rule.Equal(false)
            .When(template => !template.SummonType.HasValue, ApplyConditionTo.CurrentValidator)
            .WithErrorCode("SummonValidator")
            .WithMessage(_ => "'Is summon' must be false if 'Summon Type' is empty.")
            .Equal(false)
            .When(template => template.IsUndead, ApplyConditionTo.CurrentValidator)
            .WithErrorCode("SummonValidator")
            .WithMessage(_ => "'Is summon' must be false if 'Is undead true'.")
            .Equal(true)
            .When(template => template.SummonType.HasValue, ApplyConditionTo.CurrentValidator)
            .WithErrorCode("SummonValidator")
            .WithMessage(_ => "'Is summon' must be true if 'Summon Type' has value.");

    public static IRuleBuilderOptions<T, SummonType?> SummonTypeValidation<T>(this IRuleBuilderInitial<T, SummonType?> rule)
        where T : ISummonTemplate, IUndeadTemplate =>
        rule.Empty()
            .When(template => !template.IsSummon, ApplyConditionTo.CurrentValidator)
            .WithErrorCode("SummonValidator")
            .WithMessage(_ => "'Summon Type' must be empty if 'Is summon' is false.")
            .Empty()
            .When(template => template.IsUndead, ApplyConditionTo.CurrentValidator)
            .WithErrorCode("SummonValidator")
            .WithMessage(_ => "'Summon Type' must be empty if 'Is undead' is true.")
            .NotEmpty()
            .When(template => template.IsSummon, ApplyConditionTo.CurrentValidator)
            .WithErrorCode("SummonValidator")
            .WithMessage(_ => "'Summon Type' must not be empty if 'Is summon' is true.");

    public static IRuleBuilderOptions<T, bool> IsUndeadValidation<T>(this IRuleBuilderInitial<T, bool> rule)
        where T : ISummonTemplate, IUndeadTemplate =>
        rule.Equal(false)
            .When(template => template.IsSummon, ApplyConditionTo.CurrentValidator)
            .WithErrorCode("UndeadValidator")
            .WithMessage(_ => "'Is undead' must be false if 'Is summon' is true.")
            .Equal(false)
            .When(template => template.SummonType.HasValue, ApplyConditionTo.CurrentValidator)
            .WithErrorCode("UndeadValidator")
            .WithMessage(_ => "'Is undead' must be false if 'Summon Type' is not empty.");
}