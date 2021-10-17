using AutoMapper;
using eshop.Models.DataTransferObjects.Requests;
using eshop.Models.DataTransferObjects.Responses;
using eshop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Services.Mapping
{
  public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductSimpleResponse>().ReverseMap();
            CreateMap<Product, ProductDetailedResponse>().ReverseMap();
            CreateMap<AddProductRequest, Product>().ReverseMap();
        }

    }
}
