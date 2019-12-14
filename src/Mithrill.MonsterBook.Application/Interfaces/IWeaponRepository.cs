using Mithrill.MonsterBook.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mithrill.MonsterBook.Application.Interfaces
{
    interface IWeaponRepository
    {
        Task AddWeaponAsync(Weapon weapon, CancellationToken cancellationToken);
        Task<IEnumerable<Weapon>> GetAllWeaponsAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Weapon>> GetWeaponsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
        Task UpdateWeaponAsync(Weapon weapon, CancellationToken cancellationToken);
        Task DeleteWeaponAsync(int id, CancellationToken cancellationToken);
    }
}