using Microsoft.Extensions.DependencyInjection;
using Product.Infrastructure.Persistence.DbContexts;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Product.Infrastructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("MssqlsConnection");
			services.AddDbContext<MssqlsEfContext>(options =>
				options.UseSqlServer(connectionString));

			//services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
			//services.AddScoped<IOrderRepository, OrderRepository>();

			return services;
		}
	}
}
