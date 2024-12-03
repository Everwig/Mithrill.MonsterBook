using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

public sealed record Armor(
    int Id,
    Material Material,
    int AdditionalArmorClass,
    int AdditionalMovementInhibitoryFactor,
    bool IsOptional);