using Mithrill.MonsterBook.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mithrill.MonsterBook.Application.Interfaces
{
    public interface ISkillRepository
    {
        Task AddSkillAsync(Skill skill, CancellationToken cancellationToken);
        Task<IEnumerable<Skill>> GetAllSkillsAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Skill>> GetSkillsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
        Task UpdateSkillAsync(Skill skill, CancellationToken cancellationToken);
        Task DeleteSkillAsync(int id, CancellationToken cancellationToken);
    }
}