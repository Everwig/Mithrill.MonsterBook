namespace Mithrill.MonsterBook.Application.Common;

public record AggregateRoot<T>(T Id) where T : struct;