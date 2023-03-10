using System;
namespace Domain.Entities
{
	public class ProductImage
	{
        public int Id { get; set; }
        public string Path { get; set; } = null!;
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}

