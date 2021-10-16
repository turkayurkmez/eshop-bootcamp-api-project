using eshop.Data.Repositories;
using eshop.Models.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eshop.Services.Extensions;

namespace eshop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductSimpleResponse>> GetProducts()
        {
            var products = await productRepository.GetAllEntities();
            var productSimpleResponses = products.ConvertToSimpleResponseListDto();
            return productSimpleResponses;
        }
    }
}
