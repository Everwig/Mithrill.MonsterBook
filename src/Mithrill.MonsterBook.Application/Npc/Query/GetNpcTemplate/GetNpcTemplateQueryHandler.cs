using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Builders;
using Mithrill.MonsterBook.Application.Common.Exceptions;

namespace Mithrill.MonsterBook.Application.Npc.Query.GetNpcTemplate
{
    internal sealed class GetNpcTemplateQueryHandler : IRequestHandler<GetNpcTemplateQuery, NpcTemplate>
    {
        private readonly IMapper _mapper;
        private readonly IMonsterBookDbContext _monsterBookDbContext;

        public GetNpcTemplateQueryHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
        {
            _mapper = mapper;
            _monsterBookDbContext = monsterBookDbContext;
        }

        public async Task<NpcTemplate> Handle(GetNpcTemplateQuery request, CancellationToken cancellationToken)
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
                .Where(template => template.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (npcTemplate == null)
            {
                throw new NotFoundException("Template not found", request.Id);
            }

            var merits = npcTemplate.CharacterMerits.Select(characterMerit => characterMerit.Merit);
            var mappedTemplate = _mapper.Map<NpcTemplate>(npcTemplate);
            GetCalculatedValues(mappedTemplate, npcTemplate, merits);

            return mappedTemplate;
        }

        private static void GetCalculatedValues(
            NpcTemplate mappedTemplate,
            MonsterBook.Domain.NpcTemplate npcTemplate,
            IEnumerable<MonsterBook.Domain.Merit> merits)
        {
            mappedTemplate.HitPointMin = Calculators.CalculateHitPoints(
                npcTemplate.StrengthMin,
                npcTemplate.BodyMin,
                npcTemplate.IsUndead,
                merits);

            mappedTemplate.HitPointMax = Calculators.CalculateHitPoints(
                npcTemplate.StrengthMax,
                npcTemplate.BodyMax,
                npcTemplate.IsUndead,
                merits);

            mappedTemplate.ManaPointMin = Calculators.CalculateManaPoints(
                npcTemplate.IntelligenceMin,
                npcTemplate.WillpowerMin,
                npcTemplate.EmotionMin,
                merits);

            mappedTemplate.ManaPointMax = Calculators.CalculateManaPoints(
                npcTemplate.IntelligenceMax,
                npcTemplate.WillpowerMax,
                npcTemplate.EmotionMax,
                merits);

            mappedTemplate.PowerPointMin = Calculators.CalculatePowerPoints(npcTemplate.KarmaMin);
            mappedTemplate.PowerPointMax = Calculators.CalculatePowerPoints(npcTemplate.KarmaMax);
        }
    }
}