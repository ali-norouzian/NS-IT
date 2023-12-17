using Microsoft.AspNetCore.Identity;

namespace Product.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {


        public List<Product> Products { get; set; }
    }
}
