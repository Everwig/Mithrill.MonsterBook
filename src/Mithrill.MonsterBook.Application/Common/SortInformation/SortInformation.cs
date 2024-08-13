namespace Mithrill.MonsterBook.Application.Common.SortInformation
{
    public sealed class SortInformation<TSortProperty>
        where TSortProperty : struct
    {
        public TSortProperty? SortProperty { get; set; }
        public SortDirection? SortDirection { get; set; }
    }
}