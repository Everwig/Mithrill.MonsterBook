using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface IMonsterBookDbContext
    {
        DbSet<MonsterBook.Domain.Creature> Creatures { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}