using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;

namespace Product.Infrastructure.Persistence.DbContexts
{
    public class MssqlsEfContext : IdentityDbContext<AppUser, IdentityRole<int>, int>

    {
        public MssqlsEfContext(DbContextOptions<MssqlsEfContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Uniques

            modelBuilder.Entity<Domain.Entities.Product>()
                .HasIndex(e => e.ManufactureEmail)
                .IsUnique();
            modelBuilder.Entity<Domain.Entities.Product>()
                .HasIndex(e => e.ProduceDate)
                .IsUnique();

            #endregion
        }

        public DbSet<Domain.Entities.Product> Products { get; set; }
    }
}
