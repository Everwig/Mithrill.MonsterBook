namespace Mithrill.MonsterBook.Domain.Common;

public class AggregateRoot<T> where T : struct
{
    public T Id { get; set; }
}