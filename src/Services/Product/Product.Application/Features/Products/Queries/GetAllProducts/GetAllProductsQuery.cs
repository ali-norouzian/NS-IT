using MediatR;

namespace Product.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<GetAllProductsDto>>
    {
    }
}
