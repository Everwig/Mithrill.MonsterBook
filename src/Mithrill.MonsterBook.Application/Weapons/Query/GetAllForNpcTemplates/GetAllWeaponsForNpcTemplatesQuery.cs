using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Weapons.Query.GetAllForNpcTemplates;

public sealed record GetAllWeaponsForNpcTemplatesQuery : IRequest<IEnumerable<Weapon>>;