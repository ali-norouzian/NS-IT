using System.ComponentModel.DataAnnotations;

namespace Product.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsDto
    {
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }
    }
}
