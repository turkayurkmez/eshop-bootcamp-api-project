using eshop.Models.DataTransferObjects.Requests;
using eshop.Models.DataTransferObjects.Responses;
using eshop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductSimpleResponse>> GetProducts();
        //Dikkat hatalı yaklaşım:
        Task<IEnumerable<Product>> GetAllProducts();
        Task<ProductDetailedResponse> GetProduct(int id);
        Task<int> AddNewProduct(AddProductRequest addProductRequest);

        Task<IEnumerable<ProductSimpleResponse>> GetProductsByName(string name);
        Task<bool> ProductIsExist(int id);
        Task<ProductSimpleResponse> UpdateProduct(UpdateProductRequest request);
        Task<int> DeleteProduct(int id);
        Task<IEnumerable<ProductSimpleResponse>> GetProductsByCategory(int categoryId);

    }
}
