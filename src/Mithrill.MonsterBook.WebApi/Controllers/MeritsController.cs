using Microsoft.AspNetCore.Mvc;
using Mithrill.MonsterBook.WebApi.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Mithrill.MonsterBook.Application.Merits.Query.GetAllForNpcTemplates;

namespace Mithrill.MonsterBook.WebApi.Controllers
{
    public class MeritsController : ApiControllerBase
    {
        [HttpGet("GetAllForNpcTemplates")]
        public async Task<IEnumerable<Merit>> GetAllForNpcTemplates(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetAllMeritsForNpcTemplatesQuery(), cancellationToken);
        }
    }
}