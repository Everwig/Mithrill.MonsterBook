using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Domain;

namespace Mithrill.MonsterBook.Application.Common.Builders;

internal abstract class SummonBuilder : ISummonBuilder<GeneratedCreature>
{
    private readonly IMonsterBookDbContext _monsterBookDbContext;
    private readonly SummonType _summoningStrategy;
    protected MonsterBook.Domain.NpcTemplate? QueriedCreature;
    protected GeneratedCreature Creature = new();

    protected SummonBuilder(IMonsterBookDbContext monsterBookDbContext, SummonType summoningStrategy)
    {
        _monsterBookDbContext = monsterBookDbContext;
        _summoningStrategy = summoningStrategy;
        Reset();
    }

    public void Reset()
    {
        Creature = new GeneratedCreature();
        QueriedCreature = new MonsterBook.Domain.NpcTemplate();
    }

    public async Task GetMonsterFromDatabaseAsync(int id, CancellationToken cancellationToken)
    {
        QueriedCreature = await _monsterBookDbContext.NpcTemplates
            .Include(c => c.CharacterFlaws)
            .ThenInclude(cf => cf.Flaw)
            .Include(c => c.CharacterMerits)
            .ThenInclude(cm => cm.Merit)
            .Include(c => c.CharacterSkills)
            .ThenInclude(cs => cs.Skill)
            .Include(c => c.CharacterWeapons)
            .ThenInclude(cw => cw.Weapon)
            .ThenInclude(w => w.BaseAttackType)
            .Include(c => c.CharacterWeapons)
            .ThenInclude(cw => cw.AdditionalAttackTypes)
            .Where(m => m.Id == id)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public abstract void SetDefaultValues(int level);

    public void CalculateLifeSigns()
    {
        if (QueriedCreature is null)
            return;

        Creature.HitPoint = Calculators.CalculateHitPoints(
            Creature.Strength,
            Creature.Body,
            false,
            Creature.Merits);

        Creature.ManaPoint = Calculators.CalculateManaPoints(
            Creature.Intelligence,
            Creature.Willpower,
            Creature.Emotion,
            Creature.Merits);

        Creature.PowerPoint = 0;
    }

    public GeneratedCreature GetSummon()
    {
        if (QueriedCreature is null)
        {
            return GeneratedCreature.NullCreature();
        }

        var summon = Creature;
        Reset();

        return summon;
    }

    protected static int GetGuaranteedSuccess(int level) => (level - 5) / 2;

    public bool CanHandleGeneration(SummonType summonType) => summonType == _summoningStrategy;
}