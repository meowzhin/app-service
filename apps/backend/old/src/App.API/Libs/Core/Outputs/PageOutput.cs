namespace FwksLabs.Libs.Core.Outputs;

public record PageOutput<T>(
    IEnumerable<T> Items,
    int PageNumber,
    int PageSize,
    int TotalItems)
{
    public int PageNumber { get; set; } = PageNumber;
    public int PageSize { get; set; } = PageSize;
    public int TotalItems { get; set; } = TotalItems;
    public int TotalPages => TotalItems == 0 ? 0 : (int)Math.Ceiling((double)TotalItems / PageSize);
    public IEnumerable<T> Items { get; set; } = Items;

    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    public static PageOutput<T> Create(IEnumerable<T> source, int pageNumber = 1, int pageSize = -1)
    {
        var totalItems = source.Count();

        if (totalItems == 0)
            return new PageOutput<T>([], 1, 0, 0);

        pageSize = pageSize < 1 ? totalItems : pageSize;

        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        return new PageOutput<T>(items, pageNumber, pageSize, totalItems);
    }
}
