using FluentValidation;

namespace Mithrill.MonsterBook.Application.Common.Validation;

public static class SkillCategoriesValidatorExtensions
{
    public static IRuleBuilderOptions<T, SkillCategories?> UniqueSkillCategoriesValidation<T>(
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
            .WithMessage("All skill category ranks must be unique or 'SkillCategories' must be null.");

    public static IRuleBuilderOptions<T, SkillCategories?> NullSkillCategories<T>(
        this IRuleBuilderInitial<T, SkillCategories?> rule) =>
        rule.Null()
            .When(template =>
                {
                    var skillCategory = (SkillCategories)template.GetType()
                        .GetProperty(nameof(SkillCategories))
                        .GetValue(template);

                    return skillCategory is not null &&
                           skillCategory.Primary == skillCategory.FirstSecondary &&
                           skillCategory.FirstSecondary == skillCategory.SecondSecondary &&
                           skillCategory.SecondSecondary == skillCategory.Tertiary;
                },
                ApplyConditionTo.CurrentValidator)
            .WithMessage("All skill category ranks must be unique or 'SkillCategories' must be null.");
}