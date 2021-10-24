using eshop.Data.Context;
using eshop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Data.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private EshopDbContext eshopDbContext;
        public EFProductRepository(EshopDbContext eshopDbContext)
        {
            this.eshopDbContext = eshopDbContext;
        }
        public Task<int> AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllEntities()
        {
            return await eshopDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetEntityById(int id)
        {
            return await eshopDbContext.Products.FindAsync(id);
        }

        public Task<IEnumerable<Product>> GetProductsByName()
        {
            throw new NotImplementedException();
        }
    }
}
