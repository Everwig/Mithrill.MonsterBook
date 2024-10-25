using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

namespace Mithrill.MonsterBook.Application.Common.Validation
{
    public static class BaseStatValidatorExtensions
    {
        public const int MinAttributeValue = 1;
        public const int MaxAttributeValue = 100;
        public const int MinKarmaValue = 0;
        public const int MaxKarmaValue = 12;
        public const int MaxStringLength = 64;

        public static IRuleBuilderOptions<T, int> AttributeValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
            rule.InclusiveBetween(MinAttributeValue, MaxAttributeValue);

        public static IRuleBuilderOptions<T, TK> EnumValidation<T, TK>(this IRuleBuilderInitial<T, TK> rule)
            where TK : Enum =>
            rule.IsInEnum();

        public static IRuleBuilderOptions<T, string> NameValidation<T>(this IRuleBuilderInitial<T, string> rule) =>
            rule.NotEmpty()
                .MaximumLength(MaxStringLength);

        public static IRuleBuilderOptions<T, int> ZeroableValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
            rule.InclusiveBetween(MinKarmaValue, MaxKarmaValue);

        public static IRuleBuilderOptions<T, int?> NpcTemplateIdValidation<T>(
            this IRuleBuilderInitial<T, int?> rule,
            ITemplateValidatorService templateValidatorService) =>
            rule.NotNull()
                .MustAsync(async (id, cancellationToken) => id.HasValue &&
                                                            await templateValidatorService.IsValidTemplateId(id.Value,
                                                                cancellationToken));

        public static IRuleBuilderOptions<T, IEnumerable<Flaw>> FlawValidation<T>(
            this IRuleBuilderInitial<T, IEnumerable<Flaw>> rule,
            ITemplateValidatorService templateValidatorService) =>
            rule.Must(flaws => flaws.Select(flaw => flaw.Id).Distinct().Count() == flaws.Count())
                .WithMessage("You cannot have duplicate flaws.")
                .ForEach(flaws => flaws.MustAsync((flaw, cancellationToken) =>
                        templateValidatorService.IsValidFlawId(flaw.Id, cancellationToken))
                    .WithMessage((_, flaw) => $"Flaw with id '{flaw.Id}' doesn't exist."));

        public static IRuleBuilderOptions<T, IEnumerable<Merit>> MeritValidation<T>(
            this IRuleBuilderInitial<T, IEnumerable<Merit>> rule,
            ITemplateValidatorService templateValidatorService) =>
            rule.Must(merits => merits.Select(flaw => flaw.Id).Distinct().Count() == merits.Count())
                .WithMessage("You cannot have duplicate flaws.")
                .ForEach(merits => merits.MustAsync((flaw, cancellationToken) =>
                        templateValidatorService.IsValidMeritId(flaw.Id, cancellationToken))
                    .WithMessage((_, flaw) => $"Merit with id '{flaw.Id}' doesn't exist."));
    }
}