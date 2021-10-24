using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Models.DataTransferObjects.Requests
{
   public class AddProductRequest
    {
        [Required(ErrorMessage = "Ürün adı zorunludur")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ürün adı zorunludur")]
        public double Price { get; set; }
        public int? StockCount { get; set; }    
        public string Description { get; set; }    
        public string ImageUrl { get; set; }
        public List<string> Properties { get; set; }
        public int CategoryId { get; set; }
    }
}
