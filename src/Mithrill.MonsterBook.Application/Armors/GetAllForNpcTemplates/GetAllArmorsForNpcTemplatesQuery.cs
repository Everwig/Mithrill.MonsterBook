using System.Collections.Generic;
using MediatR;

namespace Mithrill.MonsterBook.Application.Armors.GetAllForNpcTemplates;

public sealed record GetAllArmorsForNpcTemplatesQuery : IRequest<IEnumerable<Armor>>;