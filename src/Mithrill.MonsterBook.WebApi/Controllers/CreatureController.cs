using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mithrill.MonsterBook.Application.Monsters.Query.GetMonster;
using Mithrill.MonsterBook.Application.Monsters.Query.GetMonsters;
using Monster = Mithrill.MonsterBook.Application.Monsters.Query.GetMonsters.Monster;

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
        [ProducesResponseType(typeof(IEnumerable<Monster>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Monster>> GetMonsters(CancellationToken cancellationToken)
        {
            var monsters = await _mediator.Send(new GetMonstersQuery(), cancellationToken);

            return monsters;
        }

        [HttpGet("Id:int")]
        public async Task<Application.Monsters.Query.GetMonster.Monster> GetMonster([FromQuery]GetMonsterQuery query, CancellationToken cancellationToken)
        {
            var monster = await _mediator.Send(query, cancellationToken);

            return monster;
        }
    }
}