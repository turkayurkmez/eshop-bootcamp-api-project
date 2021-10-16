using eshop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Data.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        private List<Product> products;
        public FakeProductRepository()
        {
            products = new List<Product>
            {
                new Product{ Id=1, Name="Product Sample 1", Price=5, Description="Sample Desc.", ImageUrl=string.Empty},
                new Product{ Id=2, Name="Product Sample 2", Price=5, Description="Sample Desc.", ImageUrl=string.Empty},
                new Product{ Id=3, Name="Product Sample 3", Price=5, Description="Sample Desc.", ImageUrl=string.Empty},
                new Product{ Id=4, Name="Product Sample 4", Price=5, Description="Sample Desc.", ImageUrl=string.Empty},

            };
        }


        async Task<IEnumerable<Product>> IRepository<Product>.GetAllEntities()
        {
            return await Task.FromResult(products);
        }

        Task<Product> IRepository<Product>.GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IProductRepository.GetProductsByName()
        {
            throw new NotImplementedException();
        }
    }
}
