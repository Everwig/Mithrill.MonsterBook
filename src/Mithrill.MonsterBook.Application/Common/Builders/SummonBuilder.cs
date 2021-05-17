using System.Threading;
using System.Threading.Tasks;
using Mithrill.MonsterBook.Application.Common.Adapters;

namespace Mithrill.MonsterBook.Application.Common.Builders
{
    internal class SummonBuilder : INpcBuilder<IGeneratedCreature>
    {
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public Task GetMonsterFromDatabaseAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void SetDefaultStats(Difficulty? difficulty = null)
        {
            throw new System.NotImplementedException();
        }

        public void SetSkillCategories()
        {
            throw new System.NotImplementedException();
        }

        public void AddRacialModifiers(bool isUndead)
        {
            throw new System.NotImplementedException();
        }

        public void AddMerits(Difficulty? difficulty = null)
        {
            throw new System.NotImplementedException();
        }

        public void AddFlaws(Difficulty? difficulty = null)
        {
            throw new System.NotImplementedException();
        }

        public void AddSkills(Difficulty? difficulty = null)
        {
            throw new System.NotImplementedException();
        }

        public void AddWeapons(Difficulty? difficulty = null)
        {
            throw new System.NotImplementedException();
        }

        public void GenerateKarma(bool isEvil, Difficulty? difficulty = null)
        {
            throw new System.NotImplementedException();
        }

        public void CalculateLifeSigns(bool isUndead)
        {
            throw new System.NotImplementedException();
        }

        public IGeneratedCreature GetNpc()
        {
            throw new System.NotImplementedException();
        }
    }
}