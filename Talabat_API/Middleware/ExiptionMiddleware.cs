using System.Text.Json;
using Talabat.API.Errors;

namespace Talabat.API.Middleware
{
    public class ExiptionMiddleware : IMiddleware
    {
        private readonly Logger<ExiptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExiptionMiddleware( Logger<ExiptionMiddleware> logger , IWebHostEnvironment env )

        {
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {

                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var response = new APIExiptionResponse(ex.StackTrace.ToString());
                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }

}

