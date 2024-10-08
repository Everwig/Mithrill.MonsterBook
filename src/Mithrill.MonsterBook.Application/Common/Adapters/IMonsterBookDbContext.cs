using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mithrill.MonsterBook.Application.Common.Adapters
{
    public interface IMonsterBookDbContext
    {
        DbSet<MonsterBook.Domain.Creature> Creatures { get; set; }
        DbSet<MonsterBook.Domain.Merit> Merits { get; set; }
        DbSet<MonsterBook.Domain.Flaw> Flaws {get; set; }
        DbSet<MonsterBook.Domain.Skill> Skills { get; set; }
        DbSet<MonsterBook.Domain.Weapon> Weapons { get; set; }
        DbSet<MonsterBook.Domain.Armor> Armors { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}