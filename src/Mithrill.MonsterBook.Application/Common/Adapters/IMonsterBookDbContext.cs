using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mithrill.MonsterBook.Domain.Entities;

namespace Mithrill.MonsterBook.Application.Common.Adapters;

public interface IMonsterBookDbContext
{
    DbSet<NpcTemplate> NpcTemplates { get; set; }
    DbSet<Merit> Merits { get; set; }
    DbSet<Flaw> Flaws {get; set; }
    DbSet<Skill> Skills { get; set; }
    DbSet<Weapon> Weapons { get; set; }
    DbSet<Armor> Armors { get; set; }
    DbSet<MonsterBook.Domain.Entities.AttackType> AttackTypes { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}