using Mithrill.MonsterBook.Domain;
using System.Threading.Tasks;

namespace Mithrill.MonsterBook.Application.Interfaces
{
    public interface IEncounterRepository
    {
        Task<int> SaveAsync(Encounter encounter);
        Task<Encounter> LoadAsync(int id);
    }
}