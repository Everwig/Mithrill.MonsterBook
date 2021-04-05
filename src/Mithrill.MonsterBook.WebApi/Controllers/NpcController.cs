using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpc;
using Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedNpcWithKarma;
using Mithrill.MonsterBook.Application.Npc.Query.GetGeneratedProminentNpc;
using Mithrill.MonsterBook.WebApi.Controllers.Common;

namespace Mithrill.MonsterBook.WebApi.Controllers
{
    public class NpcController : ApiControllerBase
    {

        [HttpGet("{Id:int}/Generate")]
        public async Task<GeneratedNpc> GetGeneratedNpc(int id, [FromQuery]bool isUndead, [FromQuery]Difficulty? difficulty, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetGeneratedNpcQuery { Id = id, IsUndead = isUndead, Difficulty = difficulty }, cancellationToken);
        }

        [HttpGet("{Id:int}/GenerateWithKarma")]
        public async Task<GeneratedNpcWithKarma> GetGeneratedNpcWithKarma([FromQuery]GetGeneratedNpcWithKarmaQuery query, CancellationToken cancellationToken)
        {
            return await Mediator.Send(query, cancellationToken);
        }

        [HttpGet("{Id:int}/GenerateProminent")]
        public async Task<GeneratedProminentNpc> GetGeneratedProminent([FromQuery]GetGeneratedProminentNpcQuery query, CancellationToken cancellationToken)
        {
            return await Mediator.Send(query, cancellationToken);
        }
    }
}