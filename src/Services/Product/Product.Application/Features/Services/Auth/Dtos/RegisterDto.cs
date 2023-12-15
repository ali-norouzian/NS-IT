using System.ComponentModel.DataAnnotations;

namespace Product.Application.Features.Services.Auth.Dtos
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        //[RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password most be complex")]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }
    }
}
