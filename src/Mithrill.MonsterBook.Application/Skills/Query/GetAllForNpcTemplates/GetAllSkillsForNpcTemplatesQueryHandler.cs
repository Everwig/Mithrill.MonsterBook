using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Skills.Query.GetAllForNpcTemplates;

internal sealed class GetAllSkillsForNpcTemplatesQueryHandler : IRequestHandler<GetAllSkillsForNpcTemplatesQuery, IEnumerable<Skill>>
{
    private readonly IMapper _mapper;
    private readonly IMonsterBookDbContext _monsterBookDbContext;

    public GetAllSkillsForNpcTemplatesQueryHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
    {
        _mapper = mapper;
        _monsterBookDbContext = monsterBookDbContext;
    }

    public async Task<IEnumerable<Skill>> Handle(GetAllSkillsForNpcTemplatesQuery request, CancellationToken cancellationToken)
    {
        var skills = await _monsterBookDbContext.Skills.ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<Skill>>(skills);
    }
}