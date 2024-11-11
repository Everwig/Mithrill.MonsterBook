using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Mithrill.MonsterBook.Application.Common.Validation;

namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

internal sealed class ValidateNpcTemplateQueryHandler : IRequestHandler<ValidateNpcTemplateQuery, ValidationResult>
{
    private readonly IMapper _mapper;
    private readonly IValidator<ValidateNpcTemplateQuery> _validator;

    public ValidateNpcTemplateQueryHandler(IMapper mapper, IValidator<ValidateNpcTemplateQuery> validator)
    {
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<ValidationResult> Handle(ValidateNpcTemplateQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(
            request,
            options => options.IncludeRuleSets(BaseStatValidatorExtensions.DefaultRuleSetName, request.ValidationMode.ToString()),
            cancellationToken);

        return _mapper.Map<ValidationResult>(validationResult);
    }
}