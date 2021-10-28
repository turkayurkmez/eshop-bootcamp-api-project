using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Models.DataTransferObjects.Responses
{
   public class ProductSimpleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price{ get; set; }
        public string ImageUrl { get; set; }

        public string CategoryName { get; set; }

    }
}
