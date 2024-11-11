using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

public record Flaw(int Id, bool IsOptional) : AggregateRoot<int>(Id);