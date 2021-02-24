using System.Threading;
using System.Threading.Tasks;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Common.Factories
{
    public interface INpcBuilder<out T>
    {
        void Reset();
        Task GetMonsterFromDatabaseAsync(int id, CancellationToken cancellationToken);
        void SetDefaultStats();
        void AddRacialModifiers(bool isUndead);
        void AddMerits(Difficulty? difficulty);
        void AddFlaws(Difficulty? difficulty);
        void AddSkills(Difficulty? difficulty);
        void AddEquipment(Difficulty? difficulty);
        void GenerateKarma(Difficulty? difficulty);
        void CalculateLifeSigns(bool isUndead);
        T GetNpc();
    }
}