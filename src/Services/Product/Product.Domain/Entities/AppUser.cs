using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Product.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
    }
}
