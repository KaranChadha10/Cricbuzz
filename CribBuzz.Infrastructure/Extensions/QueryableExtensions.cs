using Microsoft.EntityFrameworkCore;
using CribBuzz.Common.Models.Responses;
public static class QueryableExtensions
{
    public static async Task<PaginatedResponse<T>> ToPaginatedListAsync<T>(
        this IQueryable<T> source,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var count = await source.CountAsync(cancellationToken);
        var items = await source
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync(cancellationToken);

        return new PaginatedResponse<T>(items, pageNumber, pageSize, count);
    }
}