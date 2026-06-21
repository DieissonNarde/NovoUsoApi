using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using NovoUsoApi.Middleawre.Errors;

namespace NovoUsoApi.Middleawre
{
    public class ExceptionMiddleawre
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleawre> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleawre(RequestDelegate next, ILogger<ExceptionMiddleawre> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                int statusCode = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    BadRequestException => StatusCodes.Status400BadRequest,
                    UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError
                };

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = statusCode;

                var response = _env.IsDevelopment()
                    ? new ApiException(statusCode.ToString(), ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(statusCode.ToString(), ex.Message, "Internal Server Error");

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);

                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}