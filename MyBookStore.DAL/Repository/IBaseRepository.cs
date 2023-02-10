using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBookStore.Domain;

namespace MyBookStore.DAL.Repository
{
    /**
     * author: xiaotian li
     *
     * Base repository interface for CRUD
     */
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : AbstractBaseEntity
    {
        Task Insert(TEntity entity);
        
        /* Not recommend to find entity by auto-increment integer id
            Use uuid from businessId instead to make system adapt
            to distributed architecture.
         */ 
        Task<TEntity> FindById(long? id);

        Task<IEnumerable<TEntity>> FindAll();

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}