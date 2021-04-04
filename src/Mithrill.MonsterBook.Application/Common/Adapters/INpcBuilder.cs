using System.Threading;
using System.Threading.Tasks;

namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface INpcBuilder<out T>
    {
        void Reset();
        Task GetMonsterFromDatabaseAsync(int id, CancellationToken cancellationToken);
        void SetDefaultStats();
        void SetSkillCategories();
        void AddRacialModifiers(bool isUndead);
        void AddMerits(Difficulty? difficulty);
        void AddFlaws(Difficulty? difficulty);
        void AddSkills(Difficulty? difficulty);
        void AddWeapons(Difficulty? difficulty);
        void GenerateKarma(Difficulty? difficulty);
        void CalculateLifeSigns(bool isUndead);
        T GetNpc();
    }
}