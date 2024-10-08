using System.Threading;
using System.Threading.Tasks;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Common.Builders
{
    public class NpcDesigner<T>
    {
        private readonly INpcBuilder<T> _npcBuilder;

        public NpcDesigner(INpcBuilder<T> npcBuilder)
        {
            _npcBuilder = npcBuilder;
        }

        public async Task DesignNpcAsync(int npcTemplateId, bool isUndead, Difficulty? difficulty, CancellationToken cancellationToken)
        {
            await _npcBuilder.GetMonsterFromDatabaseAsync(npcTemplateId, cancellationToken);
            _npcBuilder.SetDefaultStats(difficulty);
            _npcBuilder.AddRacialModifiers(isUndead);
            _npcBuilder.AddSkills(difficulty);
            _npcBuilder.AddWeapons(difficulty);
            _npcBuilder.CalculateLifeSigns(isUndead);
        }

        public async Task DesignNpcWithKarmaAsync(int npcTemplateId, bool isEvil, bool isUndead, Difficulty? difficulty, CancellationToken cancellationToken)
        {
            await DesignNpcAsync(npcTemplateId, isUndead, difficulty, cancellationToken);
            _npcBuilder.GenerateKarma(isEvil, difficulty);
            _npcBuilder.CalculateLifeSigns(isUndead);
        }

        public async Task DesignProminentNpcAsync(int npcTemplateId, bool isEvil, bool isUndead, Difficulty? difficulty, CancellationToken cancellationToken)
        {
            await DesignNpcWithKarmaAsync(npcTemplateId, isEvil, isUndead, difficulty, cancellationToken);
            _npcBuilder.SetSkillCategories();
            _npcBuilder.AddMerits(difficulty);
            _npcBuilder.AddFlaws(difficulty);
            _npcBuilder.CalculateLifeSigns(isUndead);
        }

        public T GetNpc()
        {
            return _npcBuilder.GetNpc();
        }
    }
}