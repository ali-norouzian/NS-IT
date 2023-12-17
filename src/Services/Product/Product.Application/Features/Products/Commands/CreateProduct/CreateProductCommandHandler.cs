using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Application.Contracts.Persistence;
using Product.Application.Exceptions;

namespace Product.Application.Features.Products.Commands.CreateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Product>(request);
            Domain.Entities.Product? newEntity = null;
            try
            {
                newEntity = await _productRepository.AddAsync(entity);
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException.Message.Contains("Cannot insert duplicate key row in object 'dbo.Products' with unique index 'IX_Products_ManufactureEmail'"))
                    throw new BusinessLogicException("ManufactureEmail can't be duplicated");
                else if (e.InnerException.Message.Contains("Cannot insert duplicate key row in object 'dbo.Products' with unique index 'IX_Products_ProduceDate'"))
                    throw new BusinessLogicException("ProduceDate can't be duplicated");
            }

            return newEntity.Id;
        }
    }
}
