using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mithrill.MonsterBook.Application.Interfaces;
using Mithrill.MonsterBook.Domain;

namespace Mithrill.MonsterBook.Infrastructure
{
    internal sealed class MonsterRepository : IMonsterRepository
    {
        public Task AddMonsterAsync(Monster monster, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Monster>> GetAllMonstersAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Monster>> GetMonstersAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();

        }

        public Task<Monster> GetMonsterAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateMonsterAsync(Monster monster, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteMonsterAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}