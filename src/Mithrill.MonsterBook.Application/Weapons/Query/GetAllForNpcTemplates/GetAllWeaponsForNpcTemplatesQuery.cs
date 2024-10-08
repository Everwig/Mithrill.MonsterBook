using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Weapons.Query.GetAllForNpcTemplates
{
    public class GetAllWeaponsForNpcTemplatesQuery : IRequest<IEnumerable<Weapon>>
    {
    }
}