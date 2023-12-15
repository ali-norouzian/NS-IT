using Microsoft.Extensions.DependencyInjection;
using Product.Infrastructure.Persistence.DbContexts;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Product.Application.Contracts.Persistence;
using Product.Domain.Entities;
using Product.Infrastructure.Repositories;

namespace Product.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MssqlsConnection");
            services.AddDbContext<MssqlsEfContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            #region Identity

            services.AddIdentityCore<AppUser>(opt =>
                {
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequiredUniqueChars = 0;
                    opt.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<MssqlsEfContext>();

            #endregion

            return services;
        }
    }
}
