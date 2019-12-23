using System.Threading.Tasks;
using Mithrill.MonsterBook.Application.Interfaces;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure
{
    internal sealed class EncounterRepository : IEncounterRepository
    {
        public Task<int> SaveAsync(Encounter encounter)
        {
            throw new System.NotImplementedException();
        }

        public Task<Encounter> LoadAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}