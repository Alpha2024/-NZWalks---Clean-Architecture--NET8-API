using System.Net;

namespace NZWalks.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _requestDelegate;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _requestDelegate = next;
        }

        public async Task Invokeasync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                //log the exception
                _logger.LogError(ex, $"{errorId} : {ex.Message}");

                //return the c
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessahe = "something went wrong! we are looking into resoving this"
                };
                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }

    }
}
