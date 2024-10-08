using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mithrill.MonsterBook.Application.Weapons.Query.GetAllForNpcTemplates;
using Mithrill.MonsterBook.WebApi.Common;

namespace Mithrill.MonsterBook.WebApi.Controllers
{
    public class WeaponsController : ApiControllerBase
    {
        [HttpGet("GetAllForNpcTemplates")]
        public async Task<IEnumerable<Weapon>> GetAllForNpcTemplates(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetAllWeaponsForNpcTemplatesQuery(), cancellationToken);
        }
    }
}