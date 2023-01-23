using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Color : BaseEntity
    {
        public string? Name { get; set; }
        public string? HexCode { get; set; }
        public ICollection<ProductColors>? Colors { get; set; }

    }
}
