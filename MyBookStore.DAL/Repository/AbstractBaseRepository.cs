using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBookStore.DAL.DataSource;
using MyBookStore.Domain;

namespace MyBookStore.DAL.Repository
{
    /**
     * author xiaotian li
     *
     * Base repository contains basic CRUD for all kind of entities
     */
    public abstract class AbstractBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : AbstractBaseEntity
    {
        protected readonly DbContextManager _dbContext;

        protected AbstractBaseRepository(DbContextManager dbContext)
        {
            _dbContext = dbContext;
        }

        /**
         * Insert an entity. Not recommended to call it directly.
         * Use commands instead!
         */
        public virtual async Task Insert(TEntity entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        /**
         * Find an entity by primary key
         */
        public virtual async Task<TEntity> FindById(long? id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        /**
         * Find all entity
         */
        public virtual async Task<IEnumerable<TEntity>> FindAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        /**
         * update the entity
         */
        public virtual async Task Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        /**
         * physical delete an entity
         */
        public virtual async Task Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        /**
         * GC
         */
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }

}