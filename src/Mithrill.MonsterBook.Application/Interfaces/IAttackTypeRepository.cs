using Mithrill.MonsterBook.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mithrill.MonsterBook.Application.Interfaces
{
    interface IAttackTypeRepository
    {
        Task AddAttackTypeAsync(AttackType attackType, CancellationToken cancellationToken);
        Task<IEnumerable<AttackType>> GetAllAttackTypesAsync(CancellationToken cancellationToken);
        Task<IEnumerable<AttackType>> GetAttackTypesAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
        Task UpdateAttackTypeAsync(AttackType attackType, CancellationToken cancellationToken);
        Task DeleteAttackTypeAsync(int id, CancellationToken cancellationToken);
    }
}