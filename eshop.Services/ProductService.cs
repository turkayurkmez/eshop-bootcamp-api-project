using eshop.Data.Repositories;
using eshop.Models.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eshop.Services.Extensions;
using AutoMapper;
using eshop.Models.Entities;
using eshop.Models.DataTransferObjects.Requests;

namespace eshop.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;


        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
           
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<int> AddNewProduct(AddProductRequest addProductRequest)
        {
            var product = addProductRequest.ConvertToEntity(mapper);
            int id = await productRepository.Add(product);

            return id;

        }

        public async Task<int> DeleteProduct(int id)
        {
            return await productRepository.Delete(id);

        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await productRepository.GetAllEntities();

        }

        public async Task<ProductDetailedResponse> GetProduct(int id)
        {
            Product product = await productRepository.GetEntityById(id);
            var dto = product.ConvertToDetailedProductResponse(mapper);
            dto.ImageUrls = new List<string>
            {
                 "img1.jpg", "img2.png"
            };
            return dto;

        }

        public async Task<IEnumerable<ProductSimpleResponse>> GetProducts()
        {
            var products = await productRepository.GetAllEntities();
            var productSimpleResponses = products.ConvertToSimpleResponseListDto(mapper);
            return productSimpleResponses;
        }

        public async Task<IEnumerable<ProductSimpleResponse>> GetProductsByCategory(int categoryId)
        {
            IEnumerable<Product> products = await productRepository.GetProductsByCategory(categoryId);
            var response = products.ConvertToSimpleResponseListDto(mapper);
            return response;
        }

        public async Task<IEnumerable< ProductSimpleResponse>> GetProductsByName(string name)
        {
            var products = await productRepository.GetProductsByName(name);
            var response = products.ConvertToSimpleResponseListDto(mapper);
            return response;
        }

        public async Task<bool> ProductIsExist(int id)
        {
            return await productRepository.ProductIsExist(id);
        }

        public async Task<ProductSimpleResponse> UpdateProduct(UpdateProductRequest request)
        {

            var entity = request.ConvertToEntity(mapper);
            var product = await productRepository.UpdateEntity(entity);
            return product.ConvertToEntity(mapper);
        }
    }
}
