using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Common.Validation;

public record ValidationFailure(string PropertyName, string ErrorCode, string ErrorMessage) :
    IMapFrom<FluentValidation.Results.ValidationFailure>;