using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mithrill.MonsterBook.Application.Common.SortInformation;
using Mithrill.MonsterBook.Application.Npc.Command.DeleteNpcTemplate;
using Mithrill.MonsterBook.Application.Npc.Query.GetHitPointMinMaxValues;
using Mithrill.MonsterBook.Application.Npc.Query.GetManaPointMinMaxValues;
using Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate;
using Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplates;
using Mithrill.MonsterBook.Application.Npc.Query.GetPowerPointMinMaxValues;
using Mithrill.MonsterBook.WebApi.Common;
using GetNpcTemplateQuery = Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate.GetNpcTemplateQuery;

namespace Mithrill.MonsterBook.WebApi.Controllers
{
    public class NpcsController : ApiControllerBase
    {
        /*
        [HttpGet("Generate")]
        public async Task<GeneratedNpc> GetGeneratedNpc(int id, [FromQuery]bool isUndead, [FromQuery]Difficulty difficulty, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetGeneratedNpcQuery { Id = id, IsUndead = isUndead, Difficulty = difficulty }, cancellationToken);
        }[HttpGet("GenerateWithKarma")]
        public async Task<GeneratedNpcWithKarma> GetGeneratedNpcWithKarma(int id, [FromQuery]bool isEvil, [FromQuery]bool isUndead, [FromQuery]Difficulty difficulty, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetGeneratedNpcWithKarmaQuery { Id = id, IsEvil = isEvil, IsUndead = isUndead, Difficulty = difficulty }, cancellationToken);
        }

        [HttpGet("GenerateProminent")]
        public async Task<GeneratedProminentNpc> GetGeneratedProminent(int id, [FromQuery]bool isEvil, [FromQuery]bool isUndead, [FromQuery]Difficulty difficulty, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetGeneratedProminentNpcQuery { Id = id, IsEvil = isEvil, IsUndead = isUndead, Difficulty = difficulty }, cancellationToken);
        }*/



        [HttpGet("GetTemplates")]
        public async Task<GetNpcTemplatesQueryResult> GetAll(
            SortDirection sortDirection,
            SortProperty sortProperty,
            int pageIndex,
            int pageSize,
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(
                new GetNpcTemplatesQuery
                {
                    SortProperty = sortProperty,
                    SortDirection = sortDirection,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                },
                cancellationToken);
        }

        [HttpGet("GetTemplate/{id:int}")]
        public async Task<NpcTemplate> Get(int id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetNpcTemplateQuery { Id = id }, cancellationToken);
        }

        /*[HttpPost("CreateTemplate")]
        public async Task<int> CreateTemplate(Npc npc, CancellationToken cancellationToken)
        {
            return 0;
        }

        [HttpPatch("UpdateTemplate/{id:int}")]
        public async Task UpdateTemplate(int id, Npc npc, CancellationToken cancellationToken)
        {

        }*/

        [HttpDelete("DeleteTemplate/{id:int}")]
        public async Task DeleteTemplate(int id, CancellationToken cancellationToken)
        {
            await Mediator.Send(
                new DeleteNpcTemplateCommand
                {
                    TemplateId = id,
                    IsSoftDelete = false
                },
                cancellationToken);
        }

        [HttpGet("GetHitPointMinMaxValues")]
        public async Task<(int HitPointMin, int HitPointMax)> GetHitPointMinMaxValues(
            int strengthMin,
            int strengthMax,
            int bodyMin,
            int bodyMax,
            bool isUndead,
            IEnumerable<int> meritIds,
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetHitPointMinMaxValuesQuery
            {
                BodyMax = bodyMax,
                BodyMin = bodyMin,
                IsUndead = isUndead,
                MeritIds = meritIds,
                StrengthMin = strengthMin,
                StrengthMax = strengthMax
            }, cancellationToken);
        }

        [HttpGet("GetManaPointMinMaxValues")]
        public async Task<(int ManaPointMin, int ManaPointMax)> GetManaPointMinMaxValues(
            int intelligenceMin,
            int intelligenceMax,
            int willpowerMin,
            int willpowerMax,
            int emotionMin,
            int emotionMax,
            IEnumerable<int> meritIds,
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetManaPointMinMaxValuesQuery
            {
                MeritIds = meritIds,
                EmotionMax = emotionMax,
                EmotionMin = emotionMin,
                IntelligenceMax = intelligenceMax,
                IntelligenceMin = intelligenceMin,
                WillpowerMax = willpowerMax,
                WillpowerMin = willpowerMin
            }, cancellationToken);
        }


        [HttpGet("GetPowerPointMinMaxValues")]
        public async Task<(int PowerPointMin, int PowerPointMax)> GetPowerPointMinMaxValues(
            int karmaMin,
            int karmaMax,
            CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetPowerPointMinMaxValuesQuery
            {
                KarmaMin = karmaMin,
                KarmaMax = karmaMax,
            }, cancellationToken);
        }
    }
}