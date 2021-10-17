using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Models.DataTransferObjects.Responses
{
    public class ProductDetailedResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int StockCount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<string> Properties { get; set; }
    }
}
