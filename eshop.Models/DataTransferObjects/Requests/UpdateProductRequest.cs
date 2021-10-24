using System.ComponentModel.DataAnnotations;

namespace eshop.Models.DataTransferObjects.Requests
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Olmaz bu! İsim yaz buraya")]
        public string Name { get; set; }
        public double Price { get; set; }
        public int StockCount { get; set; }     
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }       
        public int CategoryId { get; set; }
    }
}