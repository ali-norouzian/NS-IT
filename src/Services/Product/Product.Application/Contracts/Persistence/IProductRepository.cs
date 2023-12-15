namespace Product.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Domain.Entities.Product>
    {
    }
}
