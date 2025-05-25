namespace ByteCart.Admin.Application.Common
{
    public class PaginatedList<T>
    {
        public IReadOnlyCollection<T>? Items { get; }
        public int TotalCount { get; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public PaginatedList(IReadOnlyCollection<T>? items, int totalCount, int pageSize, int pageNumber)
        {
            Items = items;
            TotalCount = totalCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}