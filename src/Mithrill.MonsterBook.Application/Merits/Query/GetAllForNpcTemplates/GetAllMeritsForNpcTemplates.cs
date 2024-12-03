using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Merits.Query.GetAllForNpcTemplates;

public sealed record GetAllMeritsForNpcTemplatesQuery : IRequest<IEnumerable<Merit>>;