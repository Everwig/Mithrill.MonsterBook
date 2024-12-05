using FluentValidation;
using Mithrill.MonsterBook.Application.Common.Validation;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedSummon;

public class GetGeneratedSummonQueryValidator : AbstractValidator<GetGeneratedSummonQuery>
{
    public GetGeneratedSummonQueryValidator()
    {
        RuleFor(query => query.Type).EnumValidation();
    }
}