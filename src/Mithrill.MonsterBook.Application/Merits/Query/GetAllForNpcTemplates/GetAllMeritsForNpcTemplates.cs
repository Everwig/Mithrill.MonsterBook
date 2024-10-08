using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Merits.Query.GetAllForNpcTemplates
{
    public class GetAllMeritsForNpcTemplatesQuery : IRequest<IEnumerable<Merit>>
    {
    }
}