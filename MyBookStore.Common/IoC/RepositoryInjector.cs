using Microsoft.Extensions.DependencyInjection;
using MyBookStore.DAL.Repository;
using MyBookStore.DAL.Repository.Impl;

namespace MyBookStore.Common.IoC
{
    public static class RepositoryInjector
    {
        
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}