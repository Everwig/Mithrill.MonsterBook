using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.PageInformation;
using Mithrill.MonsterBook.Application.Common.SortInformation;

namespace Mithrill.MonsterBook.Application.Creature.Query.GetCreatures;

internal sealed class GetCreaturesHandler : IRequestHandler<GetCreaturesQuery, GetCreaturesQueryResult>
{
    private readonly IMonsterBookDbContext _monsterBookDbContext;

    public GetCreaturesHandler(IMonsterBookDbContext monsterBookDbContext)
    {
        _monsterBookDbContext = monsterBookDbContext;
    }

    public async Task<GetCreaturesQueryResult> Handle(GetCreaturesQuery request, CancellationToken cancellationToken)
    {
        var creatures = await _monsterBookDbContext.Creatures
            .Include(creature => creature.CreatureMerits)
            .ThenInclude(creatureMerit => creatureMerit.Merit)
            .Include(creature => creature.CreatureFlaws)
            .ThenInclude(creatureFlaw => creatureFlaw.Flaw)
            .Include(creature => creature.CreatureSkills)
            .ThenInclude(creatureSkill => creatureSkill.Skill)
            .Include(creature => creature.CreatureArmors)
            .ThenInclude(creatureArmor => creatureArmor.Armor)
            .Include(creature => creature.CreatureWeapons)
            .ThenInclude(creatureWeapon => creatureWeapon.Weapon)
            .ThenInclude(weapon => weapon.BaseAttackType)
            .Include(creature => creature.CreatureWeapons)
            .ThenInclude(creatureWeapon => creatureWeapon.AdditionalAttackTypes)
            .ToListAsync(cancellationToken);

        var npcs = new List<Creature>();

        return new GetCreaturesQueryResult
        {
            Creatures = npcs,
            SortInformation = new SortInformation<SortProperty>
            {
                SortDirection = request.SortDirection,
                SortProperty = request.SortProperty
            },
            PageInformation = new PageInformation
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalCount = npcs.Count
            }
        };
    }
}