using Microsoft.AspNetCore.Mvc;
using Mithrill.MonsterBook.WebApi.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Mithrill.MonsterBook.Application.Armors.GetAllForNpcTemplates;

namespace Mithrill.MonsterBook.WebApi.Controllers
{
    public class ArmorsController : ApiControllerBase
    {
        [HttpGet("GetAllForNpcTemplates")]
        public async Task<IEnumerable<Armor>> GetAllForNpcTemplates(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetAllArmorsForNpcTemplatesQuery(), cancellationToken);
        }
    }
}