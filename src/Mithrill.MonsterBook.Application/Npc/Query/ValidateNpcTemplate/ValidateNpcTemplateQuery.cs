using MediatR;
using Mithrill.MonsterBook.Application.Common.Validation;

namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

public sealed record ValidateNpcTemplateQuery(NpcTemplate NpcTemplate, ValidationMode ValidationMode) : IRequest<ValidationResult>;