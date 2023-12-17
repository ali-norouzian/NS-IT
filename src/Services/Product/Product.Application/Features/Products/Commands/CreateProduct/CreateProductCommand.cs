using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Product.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<long>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime ProduceDate { get; set; }

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


        public int? CreatorUserId { get; set; }
    }
}
