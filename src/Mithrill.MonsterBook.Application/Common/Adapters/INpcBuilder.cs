using System.Threading;
using System.Threading.Tasks;

namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface INpcBuilder<out T>
    {
        void Reset();
        Task GetMonsterFromDatabaseAsync(int id, CancellationToken cancellationToken);
        void SetDefaultStats(Difficulty? difficulty = null);
        void SetSkillCategories();
        void AddRacialModifiers(bool isUndead);
        void AddMerits(Difficulty? difficulty = null);
        void AddFlaws(Difficulty? difficulty = null);
        void AddSkills(Difficulty? difficulty = null);
        void AddWeapons(Difficulty? difficulty = null);
        void GenerateKarma(bool isEvil, Difficulty? difficulty = null);
        void CalculateLifeSigns(bool isUndead);
        T GetNpc();
    }
}