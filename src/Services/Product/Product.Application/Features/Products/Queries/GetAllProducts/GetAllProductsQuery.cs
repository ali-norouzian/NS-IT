using MediatR;

namespace Product.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<GetAllProductsDto>>
    {
        public GetAllProductsQuery()
        {
        }
        public GetAllProductsQuery(int id)
        {
            Id = id;
        }

        public int? Id { get; set; }
    }
}
