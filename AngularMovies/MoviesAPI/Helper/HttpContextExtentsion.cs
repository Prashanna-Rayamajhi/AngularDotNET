using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Helper
{
    public static class HttpContextExtentsion
    {
        public async static Task InsertParametersPaginationInHeader<T>(this HttpContext context, IQueryable<T> queryable)
        {
            if(context == null) throw new ArgumentNullException(nameof(context));

            double count = await queryable.CountAsync();

            context.Response.Headers.Add("totalAmountOfRecords", count.ToString());
        }
    }
}
