using System.ComponentModel.DataAnnotations;
using Product.Domain.Common;

namespace Product.Domain.Entities
{
	public class Product : EntityBase
	{
		[MaxLength(100)]
		public string Name { get; set; }

		public DateTime ProduceDate { get; set; }

		[MaxLength(20)]
		public string ManufacturePhone { get; set; }

		[MaxLength(100)]
		public string ManufactureEmail { get; set; }

		public bool IsAvailable { get; set; }
	}
}

// Product { Name , *ProduceDate , ManufacturePhone , *ManufactureEmail , IsAvailable }