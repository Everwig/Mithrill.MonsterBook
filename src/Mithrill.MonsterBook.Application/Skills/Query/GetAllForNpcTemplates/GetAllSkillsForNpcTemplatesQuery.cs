using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Skills.Query.GetAllForNpcTemplates
{
    public sealed class GetAllSkillsForNpcTemplatesQuery : IRequest<IEnumerable<Skill>>
    {
    }
}