using AirParkProductions.Domain.Request;

namespace AirParkProductions.Infrastructure.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<TSource> Pageable<TSource>(this IQueryable<TSource> queryable, PageRequest pageRequest)
        {
            return queryable.Skip(pageRequest.LineToSkip()).Take(pageRequest.PageSize);
        }
    }
}
