using Product.Domain.Entities;
using Product.Infrastructure.Persistence.DbContexts;

namespace Product.Infrastructure.Persistence.Seeds
{
    public static class ProductSeed
    {
        private static int userId;
        public static async Task SeedAsync<T>(MssqlsEfContext dbContext)
        {
            if (!dbContext.Products.Any())
            {
                var user = new AppUser()
                {
                    UserName = "tste",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                };
                await dbContext.Users.AddAsync(user);
                // Its for setting Id to user entity when created
                await dbContext.SaveChangesAsync();
                userId = user.Id;

                await dbContext.Products.AddRangeAsync(GetPreconfiguredOrders());
                await dbContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Domain.Entities.Product> GetPreconfiguredOrders()
        {
            return new List<Domain.Entities.Product>
            {
                new Domain.Entities.Product()
                {
                    IsAvailable = true,
                    ManufactureEmail = "tst0@tst0.tst0",
                    ManufacturePhone = "09000000000",
                    Name = "TstName0",
                    ProduceDate = DateTime.UtcNow.AddMinutes(1),
                    CreatorUserId = userId,
                },
                new Domain.Entities.Product()
                {
                    IsAvailable = true,
                    ManufactureEmail = "tst1@tst1.tst1",
                    ManufacturePhone = "09111111111",
                    Name = "TstName1",
                    ProduceDate = DateTime.UtcNow.AddMinutes(2),
                    CreatorUserId = userId,
                },
                new Domain.Entities.Product()
                {
                    IsAvailable = true,
                    ManufactureEmail = "tst2@tst2.tst2",
                    ManufacturePhone = "09222222222",
                    Name = "TstName2",
                    ProduceDate = DateTime.UtcNow.AddMinutes(3),
                    CreatorUserId = userId,
                },
            };
        }
    }
}
