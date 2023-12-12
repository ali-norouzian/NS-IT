using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.Persistence.DbContexts;
using Product.Infrastructure.Persistence.Seeds;

namespace Product.API.Extensions
{
	public static class MigrateAndSeedDbExtensions
	{
		public static async Task<WebApplication> MigrateAndSeedDb(this WebApplication app)
		{
			await using var scope = app.Services.CreateAsyncScope();
			var services = scope.ServiceProvider;
			var logger = services.GetRequiredService<ILogger<Program>>();
			try
			{
				var dbContext = services.GetRequiredService<MssqlsEfContext>();
				//var userManager = services.GetRequiredService<UserManager<AppUser>>();

				await dbContext.Database.MigrateAsync();
				await ProductSeed.SeedAsync<Program>(dbContext);

				logger.LogInformation($"Seed database associated with context {nameof(dbContext)}");
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "An error occured during migration database. Retry in 5 seccond...");

				// Retry
				await Task.Delay(5000);
				await app.MigrateAndSeedDb();
			}

			return app;
		}
	}
}
