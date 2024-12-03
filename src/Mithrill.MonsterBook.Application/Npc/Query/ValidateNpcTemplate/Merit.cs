using Mithrill.MonsterBook.Application.Common;

namespace Mithrill.MonsterBook.Application.Npc.Query.ValidateNpcTemplate;

public sealed record Merit (int Id, bool IsOptional) : AggregateRoot<int>(Id);