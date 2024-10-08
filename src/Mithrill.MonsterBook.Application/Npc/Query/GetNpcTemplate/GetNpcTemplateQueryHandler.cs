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
            var npcTemplate = await _monsterBookDbContext.NpcTemplates
                .Include(creature => creature.CharacterArmors)
                .ThenInclude(creatureArmor => creatureArmor.Armor)
                .Include(creature => creature.CharacterWeapons)
                .ThenInclude(creatureWeapon => creatureWeapon.Weapon)
                .ThenInclude(weapon => weapon.BaseAttackType)
                .Include(creature => creature.CharacterWeapons)
                .ThenInclude(creature => creature.AdditionalAttackTypes)
                .ThenInclude(attackTypes => attackTypes.AttackType)
                .Include(creature => creature.CharacterMerits)
                .ThenInclude(creatureMerit => creatureMerit.Merit)
                .Include(creature => creature.CharacterFlaws)
                .ThenInclude(creatureFlaw => creatureFlaw.Flaw)
                .Include(creature => creature.CharacterSkills)
                .ThenInclude(creatureSkill => creatureSkill.Skill)
                .Include(creature => creature.CharacterSkillCategories)
                .Where(m => m.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            return _mapper.Map<Npc>(npcTemplate);
        }
    }
}