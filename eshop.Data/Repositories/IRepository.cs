using eshop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Data.Repositories
{
   public interface IRepository<T> where T:class, IEntity,new()
    {
        Task<IEnumerable<T>> GetAllEntities();
        Task<T> GetEntityById(int id);
        Task<int> Add(T entity);
        Task<T> UpdateEntity(T entity);
        Task<int> Delete(int id);


    }
}
