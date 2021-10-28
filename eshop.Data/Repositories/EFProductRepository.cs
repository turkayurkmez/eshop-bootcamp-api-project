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
        public async Task<int> Add(Product product)
        {
            eshopDbContext.Products.Add(product);
            await eshopDbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Delete(int id)
        {
            var product = await eshopDbContext.Products.SingleOrDefaultAsync(product => product.Id == id);
            eshopDbContext.Products.Remove(product);
            var result = await eshopDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetAllEntities()
        {
            //1. sayfa : 0 satır atla 5 satır al
            //2. sayfa: 5 satır atla 5 satır al
            //3. sayfa: 10 
            // return await eshopDbContext.Products.Skip(0).Take(5).ToListAsync();
            var result = await eshopDbContext.Products.Include(p=>p.Category).ThenInclude(c=>c.Products).ToListAsync();
            return result;
        }

        public async Task<Product> GetEntityById(int id)
        {
            return await eshopDbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            return await eshopDbContext.Products.Where(product => product.CategoryId == categoryId).ToListAsync();

        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {

            //var queryable = eshopDbContext.Products.AsQueryable();
            

            return await eshopDbContext.Products.Where(
                product => product.Name.ToLower()
                                       .Contains(name.ToLower()))
                                       .ToListAsync();

        }

        public async Task<bool> ProductIsExist(int id)
        {
            return await eshopDbContext.Products.AnyAsync(product => product.Id == id);
        }

        public async Task<Product> UpdateEntity(Product entity)
        {
            eshopDbContext.Update(entity);
            await eshopDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
