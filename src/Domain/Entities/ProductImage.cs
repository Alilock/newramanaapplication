using Domain.Entities.Base;

namespace Domain.Entities
{
    public class ProductImage:BaseEntity
    {

        public string Path { get; set; } = null!;
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; } 
    }
}
