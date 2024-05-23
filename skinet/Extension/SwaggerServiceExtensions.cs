using Microsoft.OpenApi.Models;

namespace API.Extension
{
    public static class SwaggerServiceExtensions
    {
        // Extension method to add Swagger documentation to the service collection
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                // Configure the Swagger document
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Skinet API",
                    Version = "v1"
                });
            });

            return services; // Return the updated service collection
        }

        // Extension method to use Swagger documentation in the HTTP request pipeline
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            // Enable Swagger middleware
            app.UseSwagger();

            // Configure Swagger UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skinet API v1");
            });

            return app; // Return the updated application builder
        }
    }
}
