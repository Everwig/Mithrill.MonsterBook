using System.Collections.Generic;
using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Common.Validation
{
    public class ValidationResult : IMapFrom<FluentValidation.Results.ValidationResult>
    {
        public bool IsValid { get; set; }
        public List<ValidationFailure> Errors { get; set; } = [];
    }
}