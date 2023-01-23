using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Gender :BaseEntity
    {
        public string Name { get; set; } = null!;
        public string ImagePath { get; set; } = String.Empty;
        public ICollection<Category> Categories { get; set; } = null!;

        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
