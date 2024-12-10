using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Common.Exceptions;
using Mithrill.MonsterBook.Domain.Entities;
using Mithrill.MonsterBook.Domain.ValueObjects;

namespace Mithrill.MonsterBook.Application.Npc.Command.UpdateNpcTemplate;

internal sealed class UpdateNpcTemplateCommandHandler : IRequestHandler<UpdateNpcTemplateCommand>
{
    private readonly IMapper _mapper;
    private readonly IMonsterBookDbContext _monsterBookDbContext;

    public UpdateNpcTemplateCommandHandler(IMapper mapper, IMonsterBookDbContext monsterBookDbContext)
    {
        _mapper = mapper;
        _monsterBookDbContext = monsterBookDbContext;
    }

    public async Task Handle(UpdateNpcTemplateCommand request, CancellationToken cancellationToken)
    {
        var template = await _monsterBookDbContext.NpcTemplates
            .Include(template => template.CharacterSkillCategories)
            .Include(template => template.CharacterMerits)
            .Include(template => template.CharacterFlaws)
            .Include(template => template.CharacterSkills)
            .Include(template => template.CharacterWeapons)
            .ThenInclude(template => template.AdditionalAttackTypes)
            .Include(template => template.CharacterArmors)
            .SingleOrDefaultAsync(template => template.Id == request.Id, cancellationToken);

        if (template is null)
        {
            throw new NotFoundException("Template not found", request.Id);
        }

        _mapper.Map(request.NpcTemplate, template);
        UpdateWeapons(request.NpcTemplate.Weapons, template.CharacterWeapons, request.Id);
        _monsterBookDbContext.NpcTemplates.Update(template);
        await _monsterBookDbContext.SaveChangesAsync(cancellationToken);
    }

    private static void UpdateWeapons(IEnumerable<Weapon> weapons, IEnumerable<CharacterWeapon> characterWeapons, int templateId)
    {
        foreach (var weapon in characterWeapons)
        {
            var currentWeapon = weapons.Single(w => w.Id == weapon.WeaponId);

            if (weapon.AdditionalAttackTypes is null)
            {
                if (!currentWeapon.AdditionalAttackTypes.Any())
                {
                    continue;
                }

                weapon.AdditionalAttackTypes = currentWeapon.AdditionalAttackTypes.Select(attackType =>
                    new CharacterWeaponAttackType
                    {
                        AttackType = new AttackType
                        {
                            DamageType = (DamageType)attackType.DamageType,
                            GuaranteedDamage = attackType.GuaranteedDamage,
                            NumberOfDices = attackType.NumberOfDices
                        },
                        WeaponId = weapon.WeaponId,
                        NpcTemplateId = templateId
                    }).ToList();

                continue;
            }

            weapon.AdditionalAttackTypes = weapon.AdditionalAttackTypes
                .Where(attackType => currentWeapon.AdditionalAttackTypes.Any(aT => (DamageType)aT.DamageType == attackType.AttackType.DamageType))
                .ToList();

            foreach (var additionalAttackType in weapon.AdditionalAttackTypes)
            {
                var attackType = currentWeapon.AdditionalAttackTypes.Single(aT =>
                    (DamageType)aT.DamageType == additionalAttackType.AttackType.DamageType);

                additionalAttackType.AttackType.GuaranteedDamage = attackType.GuaranteedDamage;
                additionalAttackType.AttackType.NumberOfDices = attackType.NumberOfDices;
            }
        }
    }
}