using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    // Represents mapping profiles for AutoMapper
    public class MappingProfiles : Profile
    {
        // Initializes a new instance of the MappingProfiles class
        public MappingProfiles()
        {
            // Create a mapping from Product to ProductToReturnDto
            CreateMap<Product, ProductToReturnDto>()
                // Map ProductBrand property from Product to ProductToReturnDto
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                // Map ProductType property from Product to ProductToReturnDto
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                // Use ProductUrlResolver to map PictureUrl property from Product to ProductToReturnDto
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
