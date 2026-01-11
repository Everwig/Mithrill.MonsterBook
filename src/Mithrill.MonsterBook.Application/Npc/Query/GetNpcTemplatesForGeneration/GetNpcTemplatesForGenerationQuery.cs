using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplatesForGeneration
{
    public record GetNpcTemplatesForGenerationQuery : IRequest<IEnumerable<NpcTemplate>>;

    public class GetNpcTemplatesForGenerationQueryHandler(IMonsterBookDbContext monsterBookDbContext)
        : IRequestHandler<GetNpcTemplatesForGenerationQuery, IEnumerable<NpcTemplate>>
    {
        public async Task<IEnumerable<NpcTemplate>> Handle(GetNpcTemplatesForGenerationQuery request, CancellationToken cancellationToken)
        {
            var templates = await monsterBookDbContext.NpcTemplates
                .Where(npcTemplate => !npcTemplate.IsSummon)
                .Select(npcTemplate => new { npcTemplate.Id, npcTemplate.Name, npcTemplate.IsUndead, npcTemplate.Race, npcTemplate.KarmaMin })
                .ToListAsync(cancellationToken);

            return templates.Select(template => new NpcTemplate(template.Id, template.Name, (Race)template.Race, template.IsUndead, template.KarmaMin));
        }
    }

    public record NpcTemplate(int Id, string Name, Race Race, bool IsUndead, int KarmaMin);
}