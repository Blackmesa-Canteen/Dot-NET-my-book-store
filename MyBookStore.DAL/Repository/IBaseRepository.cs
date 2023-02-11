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
        
        /*
         
         Find an entity by primary key, NOT business uuid.
         
         Note: Not recommend to find entity by auto-increment integer id,
            Use uuid from businessId instead to make system adapt
            to distributed architecture.
         */ 
        Task<TEntity> FindById(long? id);

        /**
         * return all entities.
         */
        Task<IEnumerable<TEntity>> FindAll();

        /**
         * update an entity
         */
        Task Update(TEntity entity);

        /**
         * delete an entity.
         *
         * Physical delete. Logical delete is not implemented yet.
         */
        Task Delete(TEntity entity);
    }
}