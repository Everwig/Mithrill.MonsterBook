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

        [HttpGet("Generate")]
        public async Task<GeneratedNpc> GetGeneratedNpc(int id, [FromQuery]bool isUndead, [FromQuery]Difficulty difficulty, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetGeneratedNpcQuery { Id = id, IsUndead = isUndead, Difficulty = difficulty }, cancellationToken);
        }

        [HttpGet("GenerateWithKarma")]
        public async Task<GeneratedNpcWithKarma> GetGeneratedNpcWithKarma(int id, [FromQuery]bool isEvil, [FromQuery]bool isUndead, [FromQuery]Difficulty difficulty, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetGeneratedNpcWithKarmaQuery { Id = id, IsEvil = isEvil, IsUndead = isUndead, Difficulty = difficulty }, cancellationToken);
        }

        [HttpGet("GenerateProminent")]
        public async Task<GeneratedProminentNpc> GetGeneratedProminent(int id, [FromQuery]bool isEvil, [FromQuery]bool isUndead, [FromQuery]Difficulty difficulty, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetGeneratedProminentNpcQuery { Id = id, IsEvil = isEvil, IsUndead = isUndead, Difficulty = difficulty }, cancellationToken);
        }
    }
}