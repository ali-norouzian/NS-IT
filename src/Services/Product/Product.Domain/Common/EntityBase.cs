using System.ComponentModel.DataAnnotations;

namespace Product.Domain.Common
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; protected set; }
    }
}
