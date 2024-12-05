using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Common.Validation;

internal sealed class TemplateValidatorService : ITemplateValidatorService
{
    private readonly IMonsterBookDbContext _monsterBookDbContext;
    private const string WizardingUniversity = "Wizarding university";

    public TemplateValidatorService(IMonsterBookDbContext monsterBookDbContext)
    {
        _monsterBookDbContext = monsterBookDbContext;
    }

    public async Task<bool> IsValidTemplateId(int id, CancellationToken cancellationToken) =>
        await _monsterBookDbContext.NpcTemplates.SingleOrDefaultAsync(
                template => template.Id == id,
                cancellationToken)
            is not null;

    public async Task<bool> IsValidFlawId(int id, CancellationToken cancellationToken) =>
        await _monsterBookDbContext.Flaws.SingleOrDefaultAsync(flaw => flaw.Id == id, cancellationToken)
            is not null;

    public async Task<bool> IsValidMeritId(int id, CancellationToken cancellationToken) =>
        await _monsterBookDbContext.Merits.SingleOrDefaultAsync(merit => merit.Id == id, cancellationToken)
            is not null;

    public async Task<bool> IsValidSkillId(int id, CancellationToken cancellationToken) =>
        await _monsterBookDbContext.Skills.SingleOrDefaultAsync(merit => merit.Id == id, cancellationToken)
            is not null;

    public async Task<bool> IsValidArmorId(int id, CancellationToken cancellationToken) =>
        await _monsterBookDbContext.Armors.SingleOrDefaultAsync(merit => merit.Id == id, cancellationToken)
            is not null;

    public async Task<bool> IsValidWeaponId(int id, CancellationToken cancellationToken) =>
        await _monsterBookDbContext.Weapons.SingleOrDefaultAsync(merit => merit.Id == id, cancellationToken)
            is not null;

    public async Task<bool> HasWizardingUniversityMerit(IEnumerable<AggregateRoot<int>> merits, CancellationToken cancellationToken) =>
        await _monsterBookDbContext.Merits
            .Where(merit => merits.Any(m => merit.Id == m.Id))
            .AnyAsync(merit => merit.Name == WizardingUniversity, cancellationToken);

    public async Task<bool> IsValidSummonTemplateId(int id, CancellationToken cancellationToken) =>
        (await _monsterBookDbContext.NpcTemplates.SingleAsync(template => template.Id == id, cancellationToken))
        .IsSummonTemplate;
}