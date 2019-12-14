using System.Threading;
using System.Threading.Tasks;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Interfaces
{
    public interface IEncounterService
    {
        Task<Encounter> GenerateEncounterAsync(Difficulty difficulty, CancellationToken cancellationToken);
        Task SaveEncounterAsync(Encounter encounter, CancellationToken cancellationToken);
        Task LoadEncounterAsync(int encounterId, CancellationToken cancellationToken);
    }
}