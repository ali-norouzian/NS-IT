using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Application.Contracts.Persistence;
using Product.Application.Exceptions;

namespace Product.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entityToDelete = await _productRepository.GetByIdAsync(request.Id);
            if (entityToDelete == null)
                throw new NotFoundException("Product not found");
            if (request.DeletorId != entityToDelete.CreatorUserId)
                throw new ForbiddenException("This product is not yours!");

            await _productRepository.DeleteAsync(entityToDelete);

            return Unit.Value;
        }
    }
}
