using Microsoft.AspNetCore.Mvc.Filters;

namespace MoviesAPI.Filters
{
    public class MyExceptions : ExceptionFilterAttribute
    {
        private readonly ILogger<MyExceptions> logger;

        public MyExceptions(ILogger<MyExceptions> logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception, context.Exception.Message);

            base.OnException(context);
        }
    }
}
