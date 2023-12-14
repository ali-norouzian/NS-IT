using AutoMapper;
using Product.Application.Features.Products.Queries.GetAllProducts;

namespace Product.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Product, GetAllProductsDto>().ReverseMap();
        }
    }
}
