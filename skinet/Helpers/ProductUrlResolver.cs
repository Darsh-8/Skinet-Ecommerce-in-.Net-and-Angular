using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    // Represents a resolver for mapping the PictureUrl property from Product to ProductToReturnDto
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration config;

        // Initializes a new instance of the ProductUrlResolver class
        public ProductUrlResolver(IConfiguration config)
        {
            this.config = config;
        }

        // Resolves the PictureUrl property from Product to ProductToReturnDto
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            // If PictureUrl is not null or empty, return the full URL
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
