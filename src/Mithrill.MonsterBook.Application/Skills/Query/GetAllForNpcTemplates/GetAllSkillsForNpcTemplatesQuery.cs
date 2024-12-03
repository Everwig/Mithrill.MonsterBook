using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Skills.Query.GetAllForNpcTemplates;

public sealed record GetAllSkillsForNpcTemplatesQuery : IRequest<IEnumerable<Skill>>;