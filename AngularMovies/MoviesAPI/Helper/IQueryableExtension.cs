using MoviesAPI.ModelDTOs;

namespace MoviesAPI.Helper
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Paginate<T>(this IQueryable <T> queryable, PaginationDTO pagination)
        {
            return queryable.Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize);
        }
    }
}
