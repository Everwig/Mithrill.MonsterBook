using System;
using System.Collections.Generic;
using FluentValidation;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Common.Validation;

public static class BaseStatValidatorExtensions
{
    public const int MinAttributeValue = 1;
    public const int MaxAttributeValue = 100;
    public const int MinKarmaValue = 0;
    public const int MaxKarmaValue = 12;
    public const int MaxStringLength = 64;
    public const string DefaultRuleSetName = "default";

    public static IRuleBuilderOptions<T, int> AttributeValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(MinAttributeValue, MaxAttributeValue)
            .WithErrorCode("NonZeroableAttributeValidator");

    public static IRuleBuilderOptions<T, TK> EnumValidation<T, TK>(this IRuleBuilderInitial<T, TK> rule)
        where TK : Enum =>
        rule.IsInEnum();

    public static IRuleBuilderOptions<T, string> NameValidation<T>(this IRuleBuilderInitial<T, string> rule) =>
        rule.NotEmpty()
            .MaximumLength(MaxStringLength);

    public static IRuleBuilderOptions<T, int> ZeroableValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(MinKarmaValue, MaxKarmaValue)
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
            .WithMessage((_, id) => $"Template with '{id}' does not exist");

    public static IRuleBuilderOptions<T, int> NpcTemplateIdValidation<T>(
        this IRuleBuilderInitial<T, int> rule,
        ITemplateValidatorService templateValidatorService) =>
        rule.MustAsync(templateValidatorService.IsValidTemplateId)
            .WithErrorCode("IdValidator")
            .WithMessage((_, id) => $"Template with '{id}' does not exist");

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
}