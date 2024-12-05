using FluentValidation;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Validation;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedSummon
{
    public class GetGeneratedSummonQueryValidator : AbstractValidator<GetGeneratedSummonQuery>
    {
        public GetGeneratedSummonQueryValidator(ITemplateValidatorService templateValidatorService)
        {
            RuleFor(query => query.Type).EnumValidation();
            RuleFor(query => query.TemplateId).SummonTemplateIdValidation(templateValidatorService);
        }
    }
}