using AutoMapper;
using eshop.Models.DataTransferObjects.Requests;
using eshop.Models.DataTransferObjects.Responses;
using eshop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Services.Extensions
{
   public static class ConverterExtensions
    {
        public static IEnumerable<ProductSimpleResponse> ConvertToSimpleResponseListDto(this IEnumerable<Product> products, IMapper mapper)
        {
            //List<ProductSimpleResponse> productSimpleResponses = new List<ProductSimpleResponse>();
            //products.ToList().ForEach(pro => productSimpleResponses.Add(new ProductSimpleResponse
            //{
            //    Description = pro.Description,
            //    Id = pro.Id,
            //    Image = pro.ImageUrl,
            //    Name = pro.Name,
            //    Price = pro.Price
            //}));
            var responses =  mapper.Map<IEnumerable<ProductSimpleResponse>>(products);
            return responses;


        }

        public static ProductDetailedResponse ConvertToDetailedProductResponse(this Product product, IMapper mapper)
        {
            var response = mapper.Map<ProductDetailedResponse>(product);
         
            return response;

        }

        public static Product ConvertToEntity(this AddProductRequest addProductRequest, IMapper mapper)
        {
            return mapper.Map<Product>(addProductRequest);
        }
    }
}
