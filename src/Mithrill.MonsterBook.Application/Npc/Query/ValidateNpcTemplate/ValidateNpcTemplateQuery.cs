using MediatR;
using Mithrill.MonsterBook.Application.Common.Validation;

namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate
{
    public class ValidateNpcTemplateQuery : IRequest<ValidationResult>
    {
        public NpcTemplate NpcTemplate { get; set; }
        public ValidationMode ValidationMode { get; set; }
    }
}