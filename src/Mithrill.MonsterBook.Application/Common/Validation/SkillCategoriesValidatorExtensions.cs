using FluentValidation;

namespace Mithrill.MonsterBook.Application.Common.Validation;

public static class SkillCategoriesValidatorExtensions
{
    public static IRuleBuilderOptions<T, SkillCategories?> SkillCategoriesValidation<T>(
        this IRuleBuilderInitial<T, SkillCategories?> rule) =>
        rule.Must(skillCategory => skillCategory.Primary != skillCategory.FirstSecondary &&
                                   skillCategory.Primary != skillCategory.SecondSecondary &&
                                   skillCategory.Primary != skillCategory.Tertiary &&
                                   skillCategory.FirstSecondary != skillCategory.SecondSecondary &&
                                   skillCategory.FirstSecondary != skillCategory.Tertiary &&
                                   skillCategory.SecondSecondary != skillCategory.Tertiary)
            .When(
                template => template.GetType().GetProperty(nameof(SkillCategories)).GetValue(template) is not null,
                ApplyConditionTo.CurrentValidator)
            .WithErrorCode("SkillCategoryValidator")
            .WithMessage("All skill category ranks must be unique or 'SkillCategories' must be null.");
}