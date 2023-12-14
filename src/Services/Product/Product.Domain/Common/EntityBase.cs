using System.ComponentModel.DataAnnotations;

namespace Product.Domain.Common
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; protected set; }
    }
}
