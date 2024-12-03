using System.Collections.Generic;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Common.Validation;

public record ValidationResult(bool IsValid, List<ValidationFailure> Errors) : IMapFrom<FluentValidation.Results.ValidationResult>;