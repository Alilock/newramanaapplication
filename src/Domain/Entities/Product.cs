using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int StockKeepingUnit { get; set; }
        public decimal? Price { get; set; }
        public decimal? Rate { get; set; } = 0;
        public bool? InStock { get; set; } = false;
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public virtual ICollection<ProductImage>? Images
        {
            get; set;
        }
        public ICollection<ProductColors>? Colors { get; set; }
        public ICollection<ProductMaterials>? Materials { get; set; }
    }
}
