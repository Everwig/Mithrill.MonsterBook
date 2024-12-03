using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Flaws.Query.GetAllForNpcTemplates;

public sealed record GetAllFlawsForNpcTemplatesQuery : IRequest<IEnumerable<Flaw>>;