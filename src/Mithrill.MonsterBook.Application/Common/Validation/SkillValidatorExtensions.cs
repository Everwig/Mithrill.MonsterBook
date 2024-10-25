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

    public static IRuleBuilderOptions<T, IEnumerable<Skill>> SkillValidation<T>(
        this IRuleBuilderInitial<T, IEnumerable<Skill>> rule,
        ITemplateValidatorService templateValidatorService) =>
        rule.Must(skills => skills.Select(skill => skill.Id).Distinct().Count() == skills.Count())
            .WithMessage("You cannot have duplicate skills.");

    public static IRuleBuilderOptions<T, int> LevelValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(MinLevel, MaxLevel);

    public static IRuleBuilderOptions<T, int> GuaranteedSuccessValidation<T>(this IRuleBuilderInitial<T, int> rule) =>
        rule.InclusiveBetween(MinSuccess, MaxSuccess);

    public static IRuleBuilderOptions<T, int> SkillIdValidation<T>(
        this IRuleBuilderInitial<T, int> rule,
        ITemplateValidatorService templateValidatorService) =>
        rule.MustAsync(templateValidatorService.IsValidSkillId);
}