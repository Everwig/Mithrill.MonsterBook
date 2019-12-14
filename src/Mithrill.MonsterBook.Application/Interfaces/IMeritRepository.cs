using Mithrill.MonsterBook.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mithrill.MonsterBook.Application.Interfaces
{
    interface IMeritRepository
    {
        Task AddMeritAsync(Merit merit, CancellationToken cancellationToken);
        Task<IEnumerable<Merit>> GetAllMeritsAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Merit>> GetMeritsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
        Task UpdateMeritAsync(Merit merit, CancellationToken cancellationToken);
        Task DeleteMeritAsync(int id, CancellationToken cancellationToken);
    }
}