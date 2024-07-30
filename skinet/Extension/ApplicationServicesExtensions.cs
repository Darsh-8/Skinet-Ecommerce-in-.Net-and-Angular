using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Extension
{
    // Extension methods for adding application services to the service collection
    public static class ApplicationServicesExtensions
    {
        // Extension method to add application services
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Add scoped services for product repository and generic repository
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Configure behavior for handling invalid model states
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    // Extract and format model state errors
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    // Create a response object with the errors
                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    // Return a bad request response with the error details
                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services; // Return the updated service collection
        }
    }
}
