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
                new Product{ Id=1, Name="Product Sample 1", Price=5, Description="Sample Desc.", ImageUrl="test"},
                new Product{ Id=2, Name="Product Sample 2", Price=5, Description="Sample Desc.", ImageUrl="deneme"},
                new Product{ Id=3, Name="Product Sample 3", Price=5, Description="Sample Desc.", ImageUrl="s a"},
                new Product{ Id=4, Name="Product Sample 4", Price=5, Description="Sample Desc.", ImageUrl="123"},

            };
        }

        public Task<int> Add(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<int> AddProduct(Product product)
        //{
        //    product.Id = products[products.Count - 1].Id+1;
        //    products.Add(product);
        //    return product.Id;

        //}

        public async Task<IEnumerable<Product>> GetAllEntities()
        {
            return await Task.FromResult(products);
        }

        public async Task<Product> GetEntityById(int id)
        {
            return await Task.FromResult(products.Find(x => x.Id == id));
        }

        public Task<IEnumerable<Product>> GetProductsByName()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProductIsExist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateEntity(Product entity)
        {
            throw new NotImplementedException();
        }

        //async Task<IEnumerable<Product>> IRepository<Product>.GetAllEntities()
        //{
        //    return await Task.FromResult(products);
        //}

        //async Task<Product> GetEntityById(int id)
        //{
        //    return await Task.FromResult(products.Find(x => x.Id == id));
        //}

        //Task<IEnumerable<Product>> GetProductsByName()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
