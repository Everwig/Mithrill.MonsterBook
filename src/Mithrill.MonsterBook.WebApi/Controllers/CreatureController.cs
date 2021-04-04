using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mithrill.MonsterBook.Application.Creature.Query.GetCreature;
using Mithrill.MonsterBook.Application.Creature.Query.GetCreatures;
using Creature = Mithrill.MonsterBook.Application.Creature.Query.GetCreatures.Creature;

namespace Mithrill.MonsterBook.WebApi.Controllers
{
    public class CreatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Creature>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Creature>> GetMonsters(CancellationToken cancellationToken)
        {
            var monsters = await _mediator.Send(new GetCreaturesQuery(), cancellationToken);

            return monsters;
        }

        [HttpGet("Id:int")]
        public async Task<Application.Creature.Query.GetCreature.Creature> GetMonster([FromQuery]GetCreatureQuery query, CancellationToken cancellationToken)
        {
            var monster = await _mediator.Send(query, cancellationToken);

            return monster;
        }
    }
}