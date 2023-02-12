using Microsoft.Extensions.DependencyInjection;
using MyBookStore.BLL.Book;
using MyBookStore.BLL.Book.Impl;
using MyBookStore.BLL.User;
using MyBookStore.BLL.User.Impl;

namespace MyBookStore.Configuration
{
    /**
     * author:xiaotian li
     * BLL dependency injector
     */
    public static class ServiceInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}