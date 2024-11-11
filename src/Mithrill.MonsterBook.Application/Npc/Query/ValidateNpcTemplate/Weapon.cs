using System.Collections.Generic;
using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

public record Weapon(
     int Id,
     Material Material,
     int AdditionalAttackModifier,
     int AdditionalDefenseModifier,
     int AdditionalInitiativeModifier,
     bool IsOptional,
     HashSet<AttackType> AdditionalAttackTypes);