using System.Threading;
using System.Threading.Tasks;

namespace Mithrill.MonsterBook.Application.Common.Adapters;

public interface ISummonBuilder<out T>
{
    void Reset();
    Task GetMonsterFromDatabaseAsync(int id, CancellationToken cancellationToken);
    void SetDefaultValues(int level);
    void CalculateLifeSigns();
    bool CanHandleGeneration(SummonType summonType);
    T GetSummon();
}