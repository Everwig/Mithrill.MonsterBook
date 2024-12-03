using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Npc;

namespace Mithrill.MonsterBook.Application.Common.Validation;

public static class ArcanumRankValidators
{
    public static IRuleBuilderOptions<T, ArcanumRanks?> ArcanumRanksValidation<T>(
        this IRuleBuilderInitial<T, ArcanumRanks?> rule,
        ITemplateValidatorService templateValidatorService) where T : IRanks =>
        rule.Must(arcanumRanks => arcanumRanks!.Quaternary == null && arcanumRanks.Quinary == null)
            .WhenAsync(
                async (template, cancellationToken) =>
                    template.ArcanumRanks is not null &&
                    await templateValidatorService.HasWizardingUniversityMerit(
                        template.GetType().GetProperty("Merits").GetValue(template) as IEnumerable<AggregateRoot<int>>,
                        cancellationToken),
                ApplyConditionTo.CurrentValidator)
            .WithErrorCode("ArcanumRankValidator")
            .WithMessage("Template has Magic University Merit therefor it cannot have Quaternary and Quinary rank arcanums.")

            .Must(arcanumRanks => arcanumRanks.Tertiaries.Count() == 1)
            .WhenAsync(
                async (template, cancellationToken) =>
                    template.ArcanumRanks is not null &&
                    !await templateValidatorService.HasWizardingUniversityMerit(
                        template.GetType().GetProperty("Merits").GetValue(template) as IEnumerable<AggregateRoot<int>>,
                        cancellationToken),
                ApplyConditionTo.CurrentValidator)
            .WithErrorCode("ArcanumRankValidator")
            .WithMessage("Template does not have Magic University Merit therefor it cannot have more then one Tertiary arcanum.");
}