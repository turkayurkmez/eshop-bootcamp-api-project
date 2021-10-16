using System;
using System.Collections.Generic;
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
        public DateTime CreatedSate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public string ImageUrl { get; set; }

        public List<string> Properties { get; set; }

    }
}
