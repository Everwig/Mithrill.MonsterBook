using Mithrill.MonsterBook.Application.Common.Adapters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Mithrill.MonsterBook.Application.Common.Builders
{
    public class SummonDesigner<T> where T : new()
    {
        private readonly IEnumerable<ISummonBuilder<T>> _summonBuilders;
        private ISummonBuilder<T>? _summonBuilder;

        public SummonDesigner(IEnumerable<ISummonBuilder<T>> summonBuilders)
        {
            _summonBuilders = summonBuilders;
        }

        public async Task DesignSummonAsync(SummonType summonType, int level, CancellationToken cancellationToken)
        {
            var summonBuilder = _summonBuilders.Single(summonBuilder => summonBuilder.CanHandleGeneration(summonType));
            await summonBuilder.GetMonsterFromDatabaseAsync(cancellationToken);
            summonBuilder.SetDefaultValues(level);
            summonBuilder.CalculateLifeSigns();
            _summonBuilder = summonBuilder;
        }

        public T GetSummon()
        {
            return _summonBuilder is null
                ? new T()
                : _summonBuilder.GetSummon();
        }
    }
}