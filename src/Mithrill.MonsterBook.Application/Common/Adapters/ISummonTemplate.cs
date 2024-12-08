namespace Mithrill.MonsterBook.Application.Common.Adapters;

public interface ISummonTemplate
{
    bool IsSummon { get; }
    SummonType? SummonType { get; }
}

public interface IUndeadTemplate
{
    bool IsUndead { get; }
}