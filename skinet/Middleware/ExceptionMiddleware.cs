using API.Errors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Middleware
{
    // Middleware for handling exceptions and returning appropriate responses
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IWebHostEnvironment env;

        // Initializes a new instance of the ExceptionMiddleware class
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        // Invokes the middleware
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Continue to the next middleware
                await next(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                logger.LogError(ex, ex.Message);

                // Set the response content type and status code
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Create an error response based on the environment
                var response = env.IsDevelopment()
                    ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new ApiException((int)HttpStatusCode.InternalServerError);

                // Configure JSON serialization options
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                // Serialize the response object to JSON
                var json = JsonSerializer.Serialize(response, options);

                // Write the JSON response to the client
                await context.Response.WriteAsync(json);
            }
        }
    }
}
