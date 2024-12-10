using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Application.Common.Adapters;
using Mithrill.MonsterBook.Application.Domain;
using Mithrill.MonsterBook.Domain;
using Mithrill.MonsterBook.Domain.Entities;

namespace Mithrill.MonsterBook.Application.Common.Builders;

internal abstract class SummonBuilder : ISummonBuilder<GeneratedCreature>
{
    private readonly IMonsterBookDbContext _monsterBookDbContext;
    private readonly SummonType _summoningStrategy;
    protected NpcTemplate? QueriedCreature;
    protected GeneratedCreature Creature = new();
    protected readonly string MediumArms = "Medium arms";
    protected readonly string HeavyArms = "Heavy arms";

    protected SummonBuilder(IMonsterBookDbContext monsterBookDbContext, SummonType summoningStrategy)
    {
        _monsterBookDbContext = monsterBookDbContext;
        _summoningStrategy = summoningStrategy;
        Reset();
    }

    public void Reset()
    {
        Creature = new GeneratedCreature();
        QueriedCreature = new NpcTemplate();
    }

    public async Task GetMonsterFromDatabaseAsync(CancellationToken cancellationToken)
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
            .Where(m => m.IsSummon &&
                        m.SummonType.HasValue &&
                        EF.Functions.Like(m.SummonType.Value.ToString(), _summoningStrategy.ToString()))
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
            Creature.Merits.Select(merit => merit.Name));

        Creature.ManaPoint = Calculators.CalculateManaPoints(
            Creature.Intelligence,
            Creature.Willpower,
            Creature.Emotion,
            Creature.Merits);

        Creature.PowerPoint = _summoningStrategy is SummonType.Holy or SummonType.Unholy
            ? Calculators.CalculatePowerPoints(Creature.Karma)
            : 0;
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