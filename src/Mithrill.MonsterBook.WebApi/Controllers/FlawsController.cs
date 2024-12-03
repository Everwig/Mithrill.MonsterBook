using Microsoft.AspNetCore.Mvc;
using Mithrill.MonsterBook.WebApi.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Mithrill.MonsterBook.Application.Flaws.Query.GetAllForNpcTemplates;

namespace Mithrill.MonsterBook.WebApi.Controllers
{
    public class FlawsController : ApiControllerBase
    {
        [HttpGet("GetAllForNpcTemplates")]
        public async Task<IEnumerable<Flaw>> GetAllForNpcTemplates(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetAllFlawsForNpcTemplatesQuery(), cancellationToken);
        }
    }
}