namespace Mithrill.MonsterBook.Application.Common.SortInformation;

public sealed record SortInformation<TSortProperty>(TSortProperty? SortProperty, SortDirection? SortDirection)
    where TSortProperty : struct;