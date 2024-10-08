using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate
{
    internal sealed class GetNpcTemplateQueryHandler : IRequestHandler<GetNpcTemplateQuery, Npc>
    {
        private readonly IMapper _mapper;
        private readonly IMonsterBookDbContext _monsterBookDbContext;

        public GetNpcTemplateQueryHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
        {
            _mapper = mapper;
            _monsterBookDbContext = monsterBookDbContext;
        }

        public async Task<Npc> Handle(GetNpcTemplateQuery request, CancellationToken cancellationToken)
        {
            var npcTemplate = await _monsterBookDbContext.Creatures
                .Include(creature => creature.CreatureArmors)
                .ThenInclude(creatureArmor => creatureArmor.Armor)
                .Include(creature => creature.CreatureWeapons)
                .ThenInclude(creatureWeapon => creatureWeapon.Weapon)
                .ThenInclude(weapon => weapon.BaseAttackType)
                .Include(creature => creature.CreatureWeapons)
                .ThenInclude(creature => creature.AdditionalAttackTypes)
                .ThenInclude(attackTypes => attackTypes.AttackType)
                .Include(creature => creature.CreatureMerits)
                .ThenInclude(creatureMerit => creatureMerit.Merit)
                .Include(creature => creature.CreatureFlaws)
                .ThenInclude(creatureFlaw => creatureFlaw.Flaw)
                .Include(creature => creature.CreatureSkills)
                .ThenInclude(creatureSkill => creatureSkill.Skill)
                .Include(creature => creature.CreatureSkillCategories)
                .Where(m => m.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            return _mapper.Map<Npc>(npcTemplate);
        }
    }
}