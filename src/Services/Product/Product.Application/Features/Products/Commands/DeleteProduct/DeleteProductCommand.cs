using MediatR;

namespace Product.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }

        public int DeletorId { get; set; }
    }
}
