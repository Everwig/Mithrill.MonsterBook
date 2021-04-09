using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mithrill.MonsterBook.Application.Creature.Query.GetCreature;
using Mithrill.MonsterBook.Application.Creature.Query.GetCreatures;
using Mithrill.MonsterBook.WebApi.Controllers.Common;

namespace Mithrill.MonsterBook.WebApi.Controllers
{
    public class CreatureController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Application.Creature.Query.GetCreatures.Creature>> GetAll(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetCreaturesQuery(), cancellationToken);
        }

        [HttpGet("Id:int")]
        public async Task<Application.Creature.Query.GetCreature.Creature> Get(int id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetCreatureQuery{ Id = id }, cancellationToken);
        }
    }
}