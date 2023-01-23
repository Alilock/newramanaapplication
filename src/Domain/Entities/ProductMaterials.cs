using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductMaterials
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public Material? Material { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
