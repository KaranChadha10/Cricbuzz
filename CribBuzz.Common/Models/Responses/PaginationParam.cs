namespace CribBuzz.Common.Models.Responses;
public class PaginationParam
{
    private const int MaxPageSize = 100;
    private int _pageSize = 10;

    public int pageNumber { get; set; } = 1;

    public int pageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
}