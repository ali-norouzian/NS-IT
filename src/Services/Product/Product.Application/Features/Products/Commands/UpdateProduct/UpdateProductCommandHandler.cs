using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Application.Contracts.Persistence;
using Product.Application.Exceptions;
using Product.Application.Features.Products.Commands.CreateProduct;

namespace Product.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _productRepository.GetByIdAsync(request.Id);
            if (entityToUpdate == null)
                throw new NotFoundException("Product not found");
            if (request.UpdatorUserId != entityToUpdate.CreatorUserId)
                throw new ForbiddenException("This product is not yours!");


            _mapper.Map(request, entityToUpdate, typeof(UpdateProductCommand), typeof(Domain.Entities.Product));

            try
            {
                await _productRepository.UpdateAsync(entityToUpdate);
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException.Message.Contains("Cannot insert duplicate key row in object 'dbo.Products' with unique index 'IX_Products_ManufactureEmail'"))
                    throw new BusinessLogicException("ManufactureEmail can't be duplicated");
                else if (e.InnerException.Message.Contains("Cannot insert duplicate key row in object 'dbo.Products' with unique index 'IX_Products_ProduceDate'"))
                    throw new BusinessLogicException("ProduceDate can't be duplicated");
            }

            return Unit.Value;
        }
    }
}
