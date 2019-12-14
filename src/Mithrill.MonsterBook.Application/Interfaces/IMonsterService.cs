using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Application.Interfaces
{
    public interface IMonsterService
    {
        Task<IEnumerable<Monster>> GenerateMonsterAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Monster>> GetAllMonsterAsync(CancellationToken cancellationToken);
    }
}