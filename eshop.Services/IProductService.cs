using eshop.Models.DataTransferObjects.Responses;
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
    }
}
