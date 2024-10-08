using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Flaws.Query.GetAllForNpcTemplates
{
    public class GetAllFlawsForNpcTemplatesQuery : IRequest<IEnumerable<Flaw>>
    {
    }
}