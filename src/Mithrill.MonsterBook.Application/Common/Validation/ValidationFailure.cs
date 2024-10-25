using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Common.Validation
{
    public class ValidationFailure : IMapFrom<FluentValidation.Results.ValidationFailure>
    {
        public string PropertyName { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}