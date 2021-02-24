using System.Threading;
using System.Threading.Tasks;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Common.Factories
{
    public class NpcDesigner<T>
    {
        private readonly INpcBuilder<T> _npcBuilder;

        public NpcDesigner(INpcBuilder<T> npcBuilder)
        {
            _npcBuilder = npcBuilder;
        }

        public async Task DesignSkeletonNpcAsync(int creatureId, bool isUndead, Difficulty? difficulty, CancellationToken cancellationToken)
        {
            await _npcBuilder.GetMonsterFromDatabaseAsync(creatureId, cancellationToken);
            _npcBuilder.SetDefaultStats();
            _npcBuilder.AddRacialModifiers(isUndead);
            _npcBuilder.AddSkills(difficulty);
            _npcBuilder.AddEquipment(difficulty);
            _npcBuilder.CalculateLifeSigns(isUndead);
        }

        public T GetNpc()
        {
            return _npcBuilder.GetNpc();
        }
    }
}