using AutoMapper;
using MediatR;
using Product.Application.Contracts.Persistence;
using Product.Domain.Entities;

namespace Product.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllProductsDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = new List<Domain.Entities.Product>();
            if (request.Id != null)
            {
                products.Add(await _productRepository.GetByIdAsync((int)request.Id));
            }
            else
            {
                products.AddRange(await _productRepository.GetAllAsync());
            }

            var dto = _mapper.Map<List<GetAllProductsDto>>(products);

            return dto;
        }
    }
}
