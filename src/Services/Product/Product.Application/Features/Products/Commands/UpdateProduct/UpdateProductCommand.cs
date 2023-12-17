using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Product.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        [Phone]
        public string ManufacturePhone { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [EmailAddress]
        public string ManufactureEmail { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public int? UpdatorUserId { get; set; }
    }
}
