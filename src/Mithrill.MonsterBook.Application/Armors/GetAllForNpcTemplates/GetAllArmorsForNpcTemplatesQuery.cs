using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Armors.GetAllForNpcTemplates
{
    public sealed class GetAllArmorsForNpcTemplatesQuery : IRequest<IEnumerable<Armor>>
    {
    }
}