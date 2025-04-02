// CribBuzz.Infrastructure/Services/EfPaginator.cs
using CribBuzz.Domain.Interfaces;
using CribBuzz.Common.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace CribBuzz.Infrastructure.Services
{
    public class Paginator<T> : IPaginator<T>
    {
        public async Task<PaginatedResponse<T>> PaginateAsync(
            IQueryable<T> query, 
            int pageNumber, 
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            var count = await query.CountAsync(cancellationToken);
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
                
            return new PaginatedResponse<T>(items, pageNumber, pageSize, count);
        }
    }
}