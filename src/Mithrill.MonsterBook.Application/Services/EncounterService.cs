using System.Threading;
using System.Threading.Tasks;
using Mithrill.MonsterBook.Application.Interfaces;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Services
{
    internal sealed class EncounterService : IEncounterService
    {
        private readonly IEncounterRepository _encounterRepository;

        public EncounterService(IEncounterRepository encounterRepository)
        {
            _encounterRepository = encounterRepository;
        }

        public Task<Encounter> GenerateEncounterAsync(Difficulty difficulty, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveEncounterAsync(Encounter encounter, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task LoadEncounterAsync(int encounterId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}