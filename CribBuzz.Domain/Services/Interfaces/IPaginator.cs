using CribBuzz.Common.Models.Responses;

namespace CribBuzz.Domain.Interfaces
{
    public interface IPaginator<T>
    {
        Task<PaginatedResponse<T>> PaginateAsync(
            IQueryable<T> query, 
            int pageNumber, 
            int pageSize,
            CancellationToken cancellationToken = default);
    }
}