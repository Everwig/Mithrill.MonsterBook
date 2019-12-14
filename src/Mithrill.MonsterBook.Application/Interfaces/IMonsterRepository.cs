using Mithrill.MonsterBook.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mithrill.MonsterBook.Application.Interfaces
{
    public interface IMonsterRepository
    {
        Task AddMonsterAsync(Monster monster, CancellationToken cancellationToken);
        Task<IEnumerable<Monster>> GetAllMonstersAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Monster>> GetMonstersAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
        Task UpdateMonsterAsync(Monster monster, CancellationToken cancellationToken);
        Task DeleteMonsterAsync(int id, CancellationToken cancellationToken);
    }
}