using Product.Application.Contracts.Persistence;
using Product.Infrastructure.Persistence.DbContexts;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Domain.Entities.Product>, IProductRepository
    {
        public ProductRepository(MssqlsEfContext dbContext) : base(dbContext)
        {
        }
    }
}
