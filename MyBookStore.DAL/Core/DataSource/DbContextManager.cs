using Microsoft.EntityFrameworkCore;
using MyBookStore.DAL.Core.Mapper;
using MyBookStore.Domain;
using MyBookStore.Domain.Entity;

namespace MyBookStore.DAL.DataSource
{
    /**
     * author: xiaotian li
     * ORM and data source access.
     * Unit of Work pattern.
     */
    public class DbContextManager : DbContext
    {
        /**
         * Unit of work pattern data set for one transaction
         */
        public DbSet<Book> BookSet { get; set; }
        public DbSet<User> UserSet { get; set; }
        
        public DbContextManager(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // apply data mappers to the ORM mapping
            modelBuilder.ApplyConfiguration(new BookMapper());
            modelBuilder.ApplyConfiguration(new UserMapper());
        }
    }
}