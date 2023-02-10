using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBookStore.DAL.Repository
{
    /**
     * author: xiaotian li
     *
     * Base repository interface for CRUD
     */
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Insert(TEntity entiry);

        Task<TEntity> FindById(long? id);

        Task<IEnumerable<TEntity>> FindAll();

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}