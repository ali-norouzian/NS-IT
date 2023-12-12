using Microsoft.EntityFrameworkCore;

namespace Product.Infrastructure.Persistence.DbContexts
{
	public class MssqlsEfContext : DbContext
	{
		public MssqlsEfContext(DbContextOptions<MssqlsEfContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Domain.Entities.Product>()
				.Property(e => e.ProduceDate)
				.HasColumnType("datetime"); // Set the column type to 'datetime'
		}

		public DbSet<Domain.Entities.Product> Products { get; set; }
	}
}
