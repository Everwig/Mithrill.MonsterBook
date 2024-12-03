using Mithrill.MonsterBook.Application.Common.Mappings;

namespace Mithrill.MonsterBook.Application.Armors.GetAllForNpcTemplates;

public sealed record Armor(int Id, string Name, int BaseArmorClass, int BaseMovementInhibitoryFactor) : IMapFrom<MonsterBook.Domain.Armor>;