using Microsoft.Extensions.DependencyInjection;
using MyBookStore.DAL.Repository;
using MyBookStore.DAL.Repository.Impl;

namespace MyBookStore.IoC
{
    /**
     * author: xiaotian li
     *
     * configuration that performs dependency injection
     */
    public static class AutoInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}