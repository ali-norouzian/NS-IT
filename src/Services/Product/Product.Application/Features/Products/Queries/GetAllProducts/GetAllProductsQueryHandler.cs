using AutoMapper;
using MediatR;
using Product.Application.Contracts.Persistence;
using Product.Application.Exceptions;
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
                var p = await _productRepository.GetByIdAsync((int)request.Id);
                if (p == null)
                    throw new NotFoundException("Product not found");

                products.Add(p);
            }
            else
            {
                products.AddRange(await _productRepository.GetAllAsync());
                if (products.Count < 1)
                    throw new NotFoundException("Product not found");
            }




            var dto = _mapper.Map<List<GetAllProductsDto>>(products);

            return dto;
        }
    }
}
