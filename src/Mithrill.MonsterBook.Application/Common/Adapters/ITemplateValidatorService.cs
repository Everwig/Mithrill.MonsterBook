using System.Threading;
using System.Threading.Tasks;

namespace Mithrill.MonsterBook.Application.Common.Adapters;

public interface ITemplateValidatorService
{
    Task<bool> IsValidTemplateId(int id, CancellationToken cancellationToken);
    Task<bool> IsValidFlawId(int id, CancellationToken cancellationToken);
    Task<bool> IsValidMeritId(int id, CancellationToken cancellationToken);
    Task<bool> IsValidSkillId(int id, CancellationToken cancellationToken);
    Task<bool> IsValidArmorId(int id, CancellationToken cancellationToken);
    Task<bool> IsValidWeaponId(int id, CancellationToken cancellationToken);
}