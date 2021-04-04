using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;
using Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpcWithKarma;
using Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedProminentNpc;

namespace Mithrill.MonsterBook.WebApi.Controllers
{
    public class NpcController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NpcController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id:int}/Generate")]
        public async Task<GeneratedNpc> GetGeneratedNpc([FromQuery]GetGeneratedNpcQuery query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpGet("{Id:int}/GenerateWithKarma")]
        public async Task<GeneratedNpcWithKarma> GetGeneratedNpcWithKarma([FromQuery]GetGeneratedNpcWithKarmaQuery query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query, cancellationToken);
        }

        [HttpGet("{Id:int}/GenerateProminent")]
        public async Task<GeneratedProminentNpc> GetGeneratedProminent([FromQuery]GetGeneratedProminentNpcQuery query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query, cancellationToken);
        }
    }
}