using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Models.Entities
{
   public class Product :IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int StockCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        public List<string> Properties { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

    }
}
