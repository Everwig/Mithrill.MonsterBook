using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mithrill.MonsterBook.Application.Skills.Query.GetAllForNpcTemplates;
using Mithrill.MonsterBook.WebApi.Common;

namespace Mithrill.MonsterBook.WebApi.Controllers
{
    public class SkillsController : ApiControllerBase
    {
        [HttpGet("GetAllForNpcTemplates")]
        public async Task<IEnumerable<Skill>> GetAllForNpcTemplates(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetAllSkillsForNpcTemplatesQuery(), cancellationToken);
        }
    }
}