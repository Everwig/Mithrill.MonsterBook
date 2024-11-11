using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

namespace Mithrill.MonsterBook.Application.Common.Validation;

public static class SkillValidatorExtensions
{
    public const int MinLevel = 1;
    public const int MaxLevel = 15;
    public const int MinSuccess = 0;
    public const int MaxSuccess = 5;

    public static IRuleBuilderOptions<Skill, Skill> LevelValidation(
        this IRuleBuilderInitial<Skill, Skill> rule) =>
        rule.Must(skill => skill.MinLevel <= skill.MaxLevel)
            .WithErrorCode("SkillLevelValidator")
            .WithMessage("'Min Level' must be lower or equal to 'Max Level'");

    public static IRuleBuilderOptions<T, int> LevelValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(MinLevel, MaxLevel)
            .WithErrorCode("SkillLevelValidator");

    public static IRuleBuilderOptions<T, int> GuaranteedSuccessValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(MinSuccess, MaxSuccess)
            .WithErrorCode("SkillSuccessValidator");

    public static IRuleBuilderOptions<T, int> SkillIdValidation<T>(
        this IRuleBuilderInitial<T, int> rule,
        ITemplateValidatorService templateValidatorService) =>
        rule.MustAsync(templateValidatorService.IsValidSkillId)
            .WithErrorCode("SkillIdValidator")
            .WithMessage((_, id) => $"Skill with id '{id}' doesn't exist.");
}